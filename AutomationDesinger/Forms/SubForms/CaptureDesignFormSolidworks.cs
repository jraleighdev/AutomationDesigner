using AutomationDesinger.Constants;
using AutomationDesinger.Helpers;
using SolidworksWrapper;
using SolidworksWrapper.CaptureDtos;
using SolidworksWrapper.Constants;
using SolidworksWrapper.Documents;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace AutomationDesinger.Forms.SubForms
{
    public class CaptureDesignFormSolidworks : CaptureDesignForm
    {
        public SolidworksDocument _workingDocument;

        public SolidworksApplication.DocumentChangedHandler DocumentChangedHandler;

        public ObservableCollection<DimensionCapture> Dimensions { get; set; }

        public ObservableCollection<FeatureCapture> Features { get; set; }

        public CaptureDesignFormSolidworks()
        {
            Dimensions = new ObservableCollection<DimensionCapture>();

            Features = new ObservableCollection<FeatureCapture>();

            SetUp();

            SetupDimGrid();

            SetupFeatureGrid();
        }

        private void SetUp()
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

        private void UpdateWorkingDocument()
        {
            _workingDocument = SolidworksApplication.ActiveDocument;

            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.Text = _workingDocument?.FileName;
                }));
            }
            else
            {
                this.Text = _workingDocument?.FileName;
            }

            Dimensions.Clear();
            Features.Clear();
        }

        protected override void buttonCaptureDims_Click(object sender, EventArgs e)
        {
            var dims = SolidworksApplication.ActiveDocument.GetDimensions();

            foreach (var d in dims.Dimensions)
            {
                this.Dimensions.Add(new DimensionCapture(SolidworksFormatters.RemoveDocumentNameFromDimension(d.Name), ConvererHelpers.Round(d.Value, 16)));
            }

            foreach (var f in dims.Features)
            {
                this.Features.Add(new FeatureCapture(f.Name, f.FeatureType, f.Suppressed));
            }
        }

        protected override void dimensionCaptureGrid_SelectChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems == null || e.AddedItems.Count == 0) return;

            var dimCapture = e.AddedItems[0] as DimensionCapture;

            if (dimCapture != null)
            {
                SolidworksApplication.ActiveDocument.ClearSelection();

                SolidworksApplication.ActiveDocument.Select(dimCapture.Name, FeatureTypes.Dimension);
            }

            base.dimensionCaptureGrid_SelectChanged(sender, e);
        }

        protected override void featureCaptureGrid_SelectChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems == null || e.AddedItems.Count == 0) return;

            var featureCapture = e.AddedItems[0] as FeatureCapture;

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

            base.featureCaptureGrid_SelectChanged(sender, e);
        }

        protected override void CaptureDesignFormn_FormClosing(object sender, FormClosingEventArgs e)
        {
            SolidworksApplication.StopListening();

            SolidworksApplication.DocumentChanged -= DocumentChangedHandler;

            base.CaptureDesignFormn_FormClosing(sender, e);
        }

        protected override void addDim_Click(object sender, CellButtonClickEventArgs e)
        {
            var dim = this.dimensionCaptureGrid.SelectedItem as DimensionCapture;

            if (dim != null)
            {
                _selectedRange.Value = Commands.Dimension;
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 1)}{_selectedRange.Row}"].Value = dim.Name;
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 2)}{_selectedRange.Row}"].Value = SolidworksApplication.ActiveDocument.Name;
                _workSheet.Range[$"{ExcelHelpers.GetColumnName(_selectedRange.Column + 3)}{_selectedRange.Row}"].Value = dim.Value;
            }

            _workSheet.Range[$"{ ExcelHelpers.GetColumnName(_selectedRange.Column)}{_selectedRange.Row + 1}"].Select();

            base.addDim_Click(sender, e);
        }

        protected override void addFeature_Click(object sender, CellButtonClickEventArgs e)
        {
            // get the feature from the datagrid
            var feature = this.featureCaptureGrid.SelectedItem as FeatureCapture;

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

            base.addFeature_Click(sender, e);
        }

        private void SetupDimGrid()
        {
            this.dimensionCaptureGrid.DataSource = Dimensions;

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
