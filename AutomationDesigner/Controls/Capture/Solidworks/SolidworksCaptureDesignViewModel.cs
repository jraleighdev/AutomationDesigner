using AutomationDesigner.Constants;
using AutomationDesigner.Helpers;
using AutomationDesigner.ViewModels.Base;
using AutomationDesigner.ViewModels.Interfaces.Capture;
using Microsoft.Office.Interop.Excel;
using SolidworksWrapper;
using SolidworksWrapper.CaptureDtos;
using SolidworksWrapper.Constants;
using SolidworksWrapper.Documents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;

namespace AutomationDesigner.Controls.Capture.Solidworks
{
    public class SolidworksCaptureDesignViewModel : BaseViewModel, IDimensionCapture, IUpdateExcel, IDisposable
    {
        #region Fields

        private Excel.Worksheet _workSheet;

        private Excel.Range _selectedRange;

        private UserControl _userControl;

        #endregion

        #region view fields

        private DimensionCapture _selectedDimension;

        private FeatureCapture _selectedFeature;

        private ObservableCollection<DimensionCapture> _dimensions;

        private ObservableCollection<FeatureCapture> _features;

        private string _selectedCellName;

        private bool _loading;

        #endregion

        #region Handlers

        public SolidworksApplication.DocumentChangedHandler DocumentChangedHandler;

        #endregion

        #region Properties

        public SolidworksDocument _workingDocument;

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

        public DimensionCapture SelectedDimension
        {
            get => _selectedDimension;
            set
            {
                _selectedDimension = value;
                DimensionSelectionChanged();
                OnPropertyChanged(nameof(SelectedDimension));
            }
        }

        public FeatureCapture SelectedFeature
        {
            get => _selectedFeature;
            set
            {
                _selectedFeature = value;
                FeatureSelectionChanged();
                OnPropertyChanged(nameof(SelectedFeature));
            }
        }

        public ObservableCollection<DimensionCapture> Dimensions
        {
            get => _dimensions;
            set
            {
                _dimensions = value;
                OnPropertyChanged(nameof(Dimensions));
            }
        }

        public ObservableCollection<FeatureCapture> Features
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

        public SolidworksCaptureDesignViewModel(UserControl userControl )
        {
            Dimensions = new ObservableCollection<DimensionCapture>();

            Features = new ObservableCollection<FeatureCapture>();

            _userControl = userControl;

            CaptureDesignCommand = new RelayCommand(async () => await CaptureDimensions());

            AddDimensionCommand = new RelayCommand(AddDimension);

            AddFeatureCommand = new RelayCommand(AddFeature);

            UpdateSelectedSheet(Globals.ThisAddIn.Application.ActiveSheet);

            Setup();
        }

        #region Setup methods

        private void Setup()
        {
            if (!SolidworksApplication.Attached)
            {
                SolidworksApplication.Attach();
            }

            SolidworksApplication.Listen();

            DocumentChangedHandler = new SolidworksApplication.DocumentChangedHandler(UpdateWorkingDocument);

            SolidworksApplication.DocumentChanged += DocumentChangedHandler;

            Globals.ThisAddIn.Application.ActiveWorkbook.SheetActivate += UpdateSelectedSheet;

            UpdateWorkingDocument();
        }

        #endregion

        #region public methods

        public void AddDimension()
        {
            var parameter = SelectedDimension;

            if (parameter != null)
            {
                _selectedRange.Value = Commands.Dimension;
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 1)}{_selectedRange.Row}"].Value = parameter.Name;
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 2)}{_selectedRange.Row}"].Value = SolidworksApplication.ActiveDocument.Name;
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 3)}{_selectedRange.Row}"].Value = parameter.Value;
            }

            _workSheet.Range[$"{ ExcelHelpers.GetColumnName(_selectedRange.Column)}{_selectedRange.Row + 1}"].Select();
        }

        public void AddFeature()
        {
            var feature = SelectedFeature;

            // if the feature is null then continue
            if (feature != null)
            {
                // create a variable to store the command
                string command;

                // if the active doc is an assembly doc
                if (SolidworksApplication.ActiveDocument.IsAssemblyDoc)
                {
                    // if the feature is pattern type then set to component pattern
                    if (feature.FeatureType.Contains("Pattern"))
                    {
                        command = Commands.PatternActivity;
                    }
                    else
                    {
                        // if the feature is a component then set to component reference
                        if (feature.FeatureType == FeatureSubTypes.Reference)
                        {
                            command = Commands.ComponentActivity;
                        }
                        // set to feature reference
                        else
                        {
                            command = Commands.FeatureActivity;
                        }
                    }
                }
                // set command to feature reference
                else
                {
                    command = Commands.FeatureActivity;
                }

                // write the command in
                _selectedRange.Value = command;

                // set the name of the feature
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 1)}{_selectedRange.Row}"].Value = feature.Name;

                // set the name of the active document
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 2)}{_selectedRange.Row}"].Value = SolidworksApplication.ActiveDocument.Name;

                // if the feature is suppressed then set the value
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 3)}{_selectedRange.Row}"].Value = feature.Suppressed ? "S" : "U";
            }

            // move the selection down to the next cell.
            _workSheet.Range[$"{ ExcelHelpers.GetColumnName(_selectedRange.Column)}{_selectedRange.Row + 1}"].Select();
        }

        public void DimensionSelectionChanged()
        {
            if (SelectedDimension == null) return;

            var capturedDim = SelectedDimension;

            SolidworksApplication.ActiveDocument.ClearSelection();

            SolidworksApplication.ActiveDocument.Select(capturedDim.Name, FeatureTypes.Dimension);
        }

        public void FeatureSelectionChanged()
        {
            if (SelectedFeature == null) return;

            var featureCapture = SelectedFeature;

            if (featureCapture != null)
            {
                SolidworksApplication.ActiveDocument.ClearSelection();

                string featureType;

                if (featureCapture.FeatureType == FeatureSubTypes.Reference)
                {
                    featureType = FeatureTypes.Component;
                }
                else if (SolidworksApplication.ActiveDocument.IsAssemblyDoc && featureCapture.FeatureType.Contains("Pattern"))
                {
                    featureType = FeatureTypes.ComponentPattern;
                }
                else
                {
                    featureType = FeatureTypes.BodyFeature;
                }

                SolidworksApplication.ActiveDocument.Select(featureCapture.Name, featureType);
            }
        }

        public async Task CaptureDimensions()
        {
            this.Dimensions.Clear();
            this.Features.Clear();

            var dimensions = new List<DimensionCapture>();
            var features = new List<FeatureCapture>();

            await RunCommand(() => Loading, async () =>
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var dims = SolidworksApplication.ActiveDocument.GetDimensions();

                        foreach (var d in dims.Dimensions)
                        {
                            dimensions.Add(new DimensionCapture(SolidworksFormatters.RemoveDocumentNameFromDimension(d.Name), ConverterHelpers.Round(d.Value, 16)));
                        }

                        foreach (var f in dims.Features)
                        {
                            features.Add(new FeatureCapture(f.Name, f.FeatureType, f.Suppressed));
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });

            this.Features.AddRange(features);
            this.Dimensions.AddRange(dimensions);
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
            _workingDocument = SolidworksApplication.ActiveDocument;

            _userControl.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (System.Action)delegate ()
            {
                Dimensions.Clear();
                Features.Clear();
            });
        }

        #endregion

        public void Dispose()
        {
            _workSheet.SelectionChange -= UpdateSelectedCell;
            Globals.ThisAddIn.Application.ActiveWorkbook.SheetActivate -= UpdateSelectedSheet;
            SolidworksApplication.StopListening();
            SolidworksApplication.DocumentChanged -= DocumentChangedHandler;
        }
    }
}
