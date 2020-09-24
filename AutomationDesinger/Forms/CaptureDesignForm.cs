using System;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Events;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using AutomationDesinger.Helpers;
using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using System.Globalization;

namespace AutomationDesinger.Forms
{
    /// <summary>
    /// Base class for data capture for cad systems
    /// </summary>
    public partial class CaptureDesignForm : SfForm
    {
        protected Excel.Worksheet _workSheet;

        protected Excel.Range _selectedRange;

        // set up the styling and tool tips
        public CaptureDesignForm()
        {
            InitializeComponent();

            UpdateSelectedSheet(Globals.ThisAddIn.Application.ActiveSheet);

            SetupToolTips();

            SetupStyle();
        }

        #region Inherited methods

        /// <summary>
        /// Add the dim to the sheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void addDim_Click(object sender, CellButtonClickEventArgs e) { }

        /// <summary>
        /// Adds the selected feature to the selected range on the active sheet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void addFeature_Click(object sender, CellButtonClickEventArgs e) { }

        /// <summary>
        /// Capture the dims in the selected cad model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void buttonCaptureDims_Click(object sender, EventArgs e) { }
        
        /// <summary>
        /// When the select changes in the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void dimensionCaptureGrid_SelectChanged(object sender, SelectionChangedEventArgs e) { }

        /// <summary>
        /// When the select changes in the feature grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void featureCaptureGrid_SelectChanged(object sender, SelectionChangedEventArgs e) { }

        #endregion

        #region Methods

        /// <summary>
        /// When the user or the application switches the selected sheet in the excel
        /// </summary>
        /// <param name="range"></param>
        protected void UpdateSelectedCell(Range range)
        {
            _selectedRange = range;

            this.selectedRangeTextBox.Text = $"{ExcelHelpers.GetColumnName(range.Column)}{range.Row}";
        }

        /// <summary>
        /// When the active sheet changes
        /// </summary>
        /// <param name="sender"></param>
        protected void UpdateSelectedSheet(object sender)
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

        #endregion

        #region Setup

        private void SetupToolTips()
        {
            var captureToolTip = new SfToolTip();

            captureToolTip.SetToolTip(buttonCaptureDims, "Capture dimensions and features of the active document");

            buttonCaptureDims.Style.Border = new Pen(Color.Gray, 1);
        }

        #endregion

        #region Styling

        private void SetupStyle()
        {
            this.Style.TitleBar.Height = 26;
            this.Style.TitleBar.BackColor = Color.White;
            this.Style.TitleBar.IconBackColor = Color.FromArgb(15, 161, 212);
            this.BackColor = Color.White;
            this.Style.TitleBar.ForeColor = ColorTranslator.FromHtml("#343434");
            this.Style.TitleBar.CloseButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.MaximizeButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.MinimizeButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.HelpButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.IconHorizontalAlignment = HorizontalAlignment.Left;
            this.Style.TitleBar.Font = this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Style.TitleBar.TextHorizontalAlignment = HorizontalAlignment.Center;
            this.Style.TitleBar.TextVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
        }

        private void dimensionCaptureGrid_AutoGeneratingColumn(object sender, AutoGeneratingColumnArgs e)
        {
            if (e.Column is GridNumericColumn)
            {
                NumberFormatInfo numberFormat = System.Windows.Forms.Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
                numberFormat.NumberDecimalDigits = 3;

                (e.Column as GridNumericColumn).NumberFormatInfo = numberFormat;
            }
        }

        #endregion

        /// <summary>
        /// Remove all event listeners
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void CaptureDesignFormn_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.dimensionCaptureGrid.CellButtonClick -= addDim_Click;

            this.featureCaptureGrid.CellButtonClick -= addFeature_Click;

            this.dimensionCaptureGrid.SelectionChanged -= dimensionCaptureGrid_SelectChanged;

            this.featureCaptureGrid.SelectionChanged -= featureCaptureGrid_SelectChanged;

            _workSheet.SelectionChange -= UpdateSelectedCell;
            Globals.ThisAddIn.Application.ActiveWorkbook.SheetActivate -= UpdateSelectedSheet;
        }

        private void featureCaptureGrid_AutoGeneratingColumn(object sender, AutoGeneratingColumnArgs e)
        {
            if (e.Column.MappingName == "FeatureSource")
            {
                e.Cancel = true;
            }
        }
    }
}
