using AutomationDesinger.Constants;
using AutomationDesinger.Helpers;
using InventorWrapper;
using InventorWrapper.CaptureDto;
using InventorWrapper.CaptureDto.Enums;
using InventorWrapper.Documents;
using InventorWrapper.General;
using InventorWrapper.Parameters;
using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace AutomationDesinger.Forms.SubForms
{
    public class CaptureDesignFormInventor : CaptureDesignForm
    {
        public InventorDocument _workingDocument;

        public InventorApplication.DocumentChangedHandler DocumentChangedHandler;

        public ObservableCollection<ParameterCaptureDto> Parameters { get; set; }

        public ObservableCollection<FeatureCaptureDto> Features { get; set; }

        public CaptureDesignFormInventor()
        {
            Parameters = new ObservableCollection<ParameterCaptureDto>();

            Features = new ObservableCollection<FeatureCaptureDto>();

            SetUp();

            SetupDimGrid();

            SetupFeatureGrid();
        }

        private void SetUp()
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

        private void UpdateWorkingDocument()
        {
            _workingDocument = InventorApplication.ActiveDocument;

            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.Text = _workingDocument?.Name;
                }));
            }
            else
            {
                this.Text = _workingDocument?.Name;
            }

            Parameters.Clear();
            Features.Clear();
        }

        protected override void buttonCaptureDims_Click(object sender, EventArgs e)
        {
            var param = InventorApplication.ActiveDocument.Parameters;

            var features = InventorApplication.ActiveDocument.Features;

            foreach (var p in param)
            {
                this.Parameters.Add(new ParameterCaptureDto(p.Name, p.IsUser, p.Units.ToUpper() == "IN" ? UnitManager.UnitsFromInventor(p.Value) : p.Value));
            }

            foreach (var f in features)
            {
                this.Features.Add(new FeatureCaptureDto(f, f.Name, FeatureCaptureType.Feature, f.Suppressed));
            }

            if (InventorApplication.ActiveDocument.IsAssemblyDoc)
            {
                var adoc = InventorApplication.ActiveDocument.GetAssemblyDocument();

                foreach (var c in adoc.Components)
                {
                    if (c.IsPatternElement) continue;

                    this.Features.Add(new FeatureCaptureDto(c, c.Name, FeatureCaptureType.Component, c.Suppressed));
                }

                foreach (var p in adoc.Patterns)
                {
                    if (p.IsPatternElement) continue;

                    this.Features.Add(new FeatureCaptureDto(p, p.Name, FeatureCaptureType.Pattern, p.IsSuppressed));
                }
            }
        }

        protected override void dimensionCaptureGrid_SelectChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        protected override void featureCaptureGrid_SelectChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems == null || e.AddedItems.Count == 0) return;

            var featureCapture = e.AddedItems[0] as FeatureCaptureDto;

            if (featureCapture != null)
            {
                InventorApplication.ActiveDocument.ClearSelection();

                InventorApplication.ActiveDocument.Select(featureCapture);
            }
        }

        protected override void CaptureDesignFormn_FormClosing(object sender, FormClosingEventArgs e)
        {
            InventorApplication.StopListening();

            InventorApplication.DocumentChanged -= DocumentChangedHandler;

            base.CaptureDesignFormn_FormClosing(sender, e);
        }

        protected override void addDim_Click(object sender, CellButtonClickEventArgs e)
        {
            var parameter = this.dimensionCaptureGrid.SelectedItem as ParameterCaptureDto;

            if (parameter != null)
            {
                _selectedRange.Value = Commands.Parameter;
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 1)}{_selectedRange.Row}"].Value = parameter.Name;
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 2)}{_selectedRange.Row}"].Value = InventorApplication.ActiveDocument.Name;
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 3)}{_selectedRange.Row}"].Value = parameter.Value;
            }

            _workSheet.Range[$"{ ExcelHelpers.GetColumnName(_selectedRange.Column)}{_selectedRange.Row + 1}"].Select();

            base.addDim_Click(sender, e);
        }

        protected override void addFeature_Click(object sender, CellButtonClickEventArgs e)
        {
            var feature = this.featureCaptureGrid.SelectedItem as FeatureCaptureDto;

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

            base.addFeature_Click(sender, e);
        }

        private void SetupDimGrid()
        {
            this.dimensionCaptureGrid.DataSource = Parameters;

            this.dimensionCaptureGrid.CellButtonClick += addDim_Click;

            this.dimensionCaptureGrid.SelectionChanged += dimensionCaptureGrid_SelectChanged;
        }

        private void SetupFeatureGrid()
        {
            this.featureCaptureGrid.DataSource = Features;

            this.featureCaptureGrid.CellButtonClick += addFeature_Click;

            this.featureCaptureGrid.SelectionChanged += featureCaptureGrid_SelectChanged;
        }
    }
}
