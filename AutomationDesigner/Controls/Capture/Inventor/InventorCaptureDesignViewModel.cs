using AutomationDesigner.ViewModels.Base;
using AutomationDesigner.ViewModels.Interfaces.Capture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;
using AutomationDesigner.Helpers;
using InventorWrapper.Documents;
using InventorWrapper;
using System.Collections.ObjectModel;
using InventorWrapper.CaptureDto;
using InventorWrapper.CaptureDto.Enums;
using AutomationDesigner.Constants;
using System.Windows.Input;
using InventorWrapper.Parameters;
using InventorWrapper.Features;

namespace AutomationDesigner.Controls.Capture.Inventor
{
    public class InventorCaptureDesignViewModel : BaseViewModel, IDimensionCapture, IUpdateExcel, IDisposable
    {
        #region Fields

        private Excel.Worksheet _workSheet;

        private Excel.Range _selectedRange;

        #endregion

        #region view fields

        private ParameterCaptureDto _selectedParameter;

        private FeatureCaptureDto _selectedFeature;

        private ObservableCollection<ParameterCaptureDto> _parameters;

        private ObservableCollection<FeatureCaptureDto> _features;

        private string _selectedCellName;

        private bool _loading;

        #endregion

        #region Handlers

        public InventorApplication.DocumentChangedHandler DocumentChangedHandler;

        #endregion

        #region Properties

        public InventorDocument _workingDocument;

        #endregion

        #region View properties
        public string SelectedCellName 
        { 
            get => _selectedCellName;
            set
            {
                _selectedCellName = value;
                OnPropertyChanged(nameof(SelectedCellName));
            }
        }

        public ParameterCaptureDto SelectedParameter
        {
            get => _selectedParameter;
            set
            {
                _selectedParameter = value;
                OnPropertyChanged(nameof(SelectedParameter));
            }
        }

        public FeatureCaptureDto SelectedFeature
        {
            get => _selectedFeature;
            set
            {
                _selectedFeature = value;
                OnPropertyChanged(nameof(SelectedFeature));
            }
        }

        public ObservableCollection<ParameterCaptureDto> Parameters 
        { 
            get => _parameters;
            set
            {
                _parameters = value;
                OnPropertyChanged(nameof(Parameters));
            }
        }

        public ObservableCollection<FeatureCaptureDto> Features
        {
            get => _features;
            set
            {
                _features = value;
                OnPropertyChanged(nameof(Features));
            }
        }

        public bool Loading
        {
            get => _loading;
            set
            {
                _loading = value;
                OnPropertyChanged(nameof(Loading));
            }
        }

        #endregion

        #region Commands

        public ICommand CaptureDesignCommand { get; set; }

        public ICommand AddDimensionCommand { get; set; }

        public ICommand AddFeatureCommand { get; set; }

        #endregion

        public InventorCaptureDesignViewModel()
        {
            Parameters = new ObservableCollection<ParameterCaptureDto>();

            Features = new ObservableCollection<FeatureCaptureDto>();

            CaptureDesignCommand = new RelayCommand(async () => await CaptureDimensions());

            AddDimensionCommand = new RelayCommand(AddDimension);

            AddFeatureCommand = new RelayCommand(AddFeature);

            UpdateSelectedSheet(Globals.ThisAddIn.Application.ActiveSheet);

            Setup();
        }

        #region Setup methods

        private void Setup()
        {
            if (!InventorApplication.Attached)
            {
                InventorApplication.Attach();
            }

            InventorApplication.Listen();

            DocumentChangedHandler = new InventorApplication.DocumentChangedHandler(UpdateWorkingDocument);

            InventorApplication.DocumentChanged += DocumentChangedHandler;

            Globals.ThisAddIn.Application.ActiveWorkbook.SheetActivate += UpdateSelectedSheet;

            UpdateWorkingDocument();
        }

        #endregion

        #region public methods

        public void AddDimension()
        {
            var parameter = SelectedParameter;

            if (parameter != null)
            {
                _selectedRange.Value = Commands.Parameter;
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 1)}{_selectedRange.Row}"].Value = parameter.Name;
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 2)}{_selectedRange.Row}"].Value = InventorApplication.ActiveDocument.Name;
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 3)}{_selectedRange.Row}"].Value = parameter.Value;
            }

            _workSheet.Range[$"{ ExcelHelpers.GetColumnName(_selectedRange.Column)}{_selectedRange.Row + 1}"].Select();
        }

        public void AddFeature()
        {
            var feature = SelectedFeature;

            if (feature != null)
            {
                var command = "";

                switch (feature.Type)
                {
                    case FeatureCaptureType.Component:
                        command = Commands.ComponentActivity;
                        break;
                    case FeatureCaptureType.Feature:
                        command = Commands.FeatureActivity;
                        break;
                    case FeatureCaptureType.Pattern:
                        command = Commands.PatternActivity;
                        break;
                    case FeatureCaptureType.Constraint:
                        command = Commands.ConstraintActivity;
                        break;
                    default:
                        break;
                }

                // write the command in
                _selectedRange.Value = command;

                // set the name of the feature
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 1)}{_selectedRange.Row}"].Value = feature.Name;

                // set the name of the active document
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 2)}{_selectedRange.Row}"].Value = InventorApplication.ActiveDocument.Name;

                // if the feature is suppressed then set the value
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 3)}{_selectedRange.Row}"].Value = feature.Suppressed ? "S" : "U";
            }

            // move the selection down to the next cell.
            _workSheet.Range[$"{ ExcelHelpers.GetColumnName(_selectedRange.Column)}{_selectedRange.Row + 1}"].Select();
        }

        public void DimensionSelectionChanged()
        {
            throw new NotImplementedException();
        }

        public void FeatureSelectionChanged()
        {
            if (SelectedFeature == null) return;

            var featureCapture = SelectedFeature;

            if (featureCapture != null)
            {
                InventorApplication.ActiveDocument.ClearSelection();

                InventorApplication.ActiveDocument.Select(featureCapture);
            }
        }

        public async Task CaptureDimensions()
        {
            this.Parameters.Clear();
            this.Features.Clear();

            var parameters = new List<ParameterCaptureDto>();
            var features = new List<FeatureCaptureDto>();

            await RunCommand(() => Loading, async () =>
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var param = InventorApplication.ActiveDocument.Parameters;

                        var feature = InventorApplication.ActiveDocument.Features;

                        foreach (var p in param)
                        {
                            parameters.Add(new ParameterCaptureDto(p.Name, p.IsUser, p.ConvertedValue));
                        }

                        foreach (var f in feature)
                        {
                            features.Add(new FeatureCaptureDto(f, f.Name, FeatureCaptureType.Feature, f.Suppressed));
                        }

                        if (InventorApplication.ActiveDocument.IsAssemblyDoc)
                        {
                            var adoc = InventorApplication.ActiveDocument.GetAssemblyDocument();

                            foreach (var c in adoc.Components)
                            {
                                if (c.IsPatternElement) continue;

                                features.Add(new FeatureCaptureDto(c, c.Name, FeatureCaptureType.Component, c.Suppressed));
                            }

                            foreach (var p in adoc.Patterns)
                            {
                                if (p.IsPatternElement) continue;

                                features.Add(new FeatureCaptureDto(p, p.Name, FeatureCaptureType.Pattern, p.IsSuppressed));
                            }
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });

            this.Features.AddRange(features);
            this.Parameters.AddRange(parameters);
        }

        public void UpdateSelectedCell(Range range)
        {
            _selectedRange = range;

            SelectedCellName = $"{ExcelHelpers.GetColumnName(range.Column)}{range.Row}";
        }

        public void UpdateSelectedSheet(object sender)
        {
            if (_workSheet != null)
            {
                _workSheet.SelectionChange -= UpdateSelectedCell;
            }

            _workSheet = sender as Worksheet;

            if (_workSheet == null)
            {
                return;
            }

            _workSheet.SelectionChange += UpdateSelectedCell;

            UpdateSelectedCell(_workSheet.Application.Selection as Range);
        }

        public void UpdateWorkingDocument()
        {
            _workingDocument = InventorApplication.ActiveDocument;

            //if (InvokeRequired)
            //{
            //    this.Invoke(new MethodInvoker(delegate ()
            //    {
            //        this.Text = _workingDocument?.Name;
            //    }));
            //}
            //else
            //{
            //    this.Text = _workingDocument?.Name;
            //}

            Parameters.Clear();
            Features.Clear();
        }

        #endregion

        public void Dispose()
        {
            _workSheet.SelectionChange -= UpdateSelectedCell;
            Globals.ThisAddIn.Application.ActiveWorkbook.SheetActivate -= UpdateSelectedSheet;
            InventorApplication.StopListening();
            InventorApplication.DocumentChanged -= DocumentChangedHandler;
        }
    }
}
