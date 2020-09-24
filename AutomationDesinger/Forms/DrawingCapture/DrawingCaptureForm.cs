using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutomationDesinger.Helpers;
using InventorWrapper;
using InventorWrapper.CaptureDto.DrawingCapture;
using InventorWrapper.CaptureDto.DrawingCapture.Enums;
using InventorWrapper.Documents;
using InventorWrapper.Drawings;
using InventorWrapper.General;
using InventorWrapper.Helpers;
using Microsoft.Office.Interop.Excel;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;

namespace AutomationDesinger.Forms.DrawingCapture
{
    public partial class DrawingCaptureForm : SfForm
    {

        private DrawingCaptureDto captureDto;

        private SheetCaptureDto _selectedSheet;

        private ViewCaptureDto _selectedView;

        private DimensionCaptureDto _selectedDim;

        public ViewCaptureDto SelectedView
        {
            get => _selectedView;
            set
            {
                _selectedView = value;

                CreateDimBtn.Enabled = _selectedView != null;
            }
        }

        public DrawingCaptureForm() 
        {
            InitializeComponent();

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

            SetupCapture();
        }

        private void SetupCapture()
        {
            var drawingDoc = InventorApplication.ActiveDocument.GetDrawingDocument();

            captureDto = new DrawingCaptureDto(drawingDoc);

            ViewTree.DataSource = captureDto.Sheets;

            ViewTree.DisplayMember = "Name\\Name";

            ViewTree.ChildMember = "SheetCaptureDto\\ViewCaptureDto";

            CreateDimBtn.Enabled = false;
        }

        private void ViewTree_AfterSelect(object sender, EventArgs e)
        {
            foreach (TreeNodeAdv node in ViewTree.Nodes)
            {
                if (node.HasChildren)
                {
                    foreach (TreeNodeAdv subNode in node.Nodes)
                    {
                        if (subNode.IsSelected)
                        {
                            _selectedSheet = captureDto.Sheets.FirstOrDefault(x => x.Name == subNode.Parent.Text);

                            SelectedView = _selectedSheet.Views.FirstOrDefault(x => x.Name == subNode.Text);

                            viewNameLabel.Text = _selectedView.Name;

                            viewScaleLabel.Text = "Scale: " + ConvererHelpers.Round(UnitManager.UnitsFromInventor(_selectedView.Scale), 200).ToString();

                            viewXLabel.Text = "X: " + ConvererHelpers.Round(UnitManager.UnitsFromInventor(_selectedView.X), 16).ToString();

                            viewYLabel.Text = "Y: " + ConvererHelpers.Round(UnitManager.UnitsFromInventor(_selectedView.Y), 16).ToString();
                        }
                    }
                }

                viewDimGrid.DataSource = _selectedView?.Dimensions;   
            }
        }

        private void CreateDimBtn_Click(object sender, EventArgs e)
        {
            _selectedView.Dimensions.Add(new DimensionCaptureDto { Name = "Test" });
        }

        private void viewDimGrid_AutoGeneratingColumn(object sender, Syncfusion.WinForms.DataGrid.Events.AutoGeneratingColumnArgs e)
        {
            if (e.Column.MappingName == "Direction")
            {
                e.Column = new GridComboBoxColumn();

                e.Column.MappingName = "Direction";

                e.Column.HeaderText = "Direction";

                ((GridComboBoxColumn)e.Column).DataSource = EnumHelpers.EnumToList<DimensionDirectionEnum>();
            }
            else if (e.Column.MappingName == "Type")
            {
                e.Column = new GridComboBoxColumn();

                e.Column.MappingName = "Type";

                e.Column.HeaderText = "Direction";

                ((GridComboBoxColumn)e.Column).DataSource = EnumHelpers.EnumToList<DimensionTypeEnum>();
            }
        }

        private void viewDimGrid_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            if (e.AddedItems == null || e.AddedItems.Count == 0) return;

            _selectedDim = e.AddedItems[0] as DimensionCaptureDto;

            DimCaptureGrid.DataSource = _selectedDim.Points;
        }

        private void startCaptureButton_Click(object sender, EventArgs e)
        {
            InventorApplication.ActiveDocument.ClearSelection();
        }

        private void endCaptureButton_Click(object sender, EventArgs e)
        {
            var selectedCurves = InventorApplication.ActiveDocument.GetDrawingDocument().SelectedCurves();

            foreach (var s in selectedCurves)
            {
                _selectedDim.Points.Add(new PointCaptureDto { Name = "Enter Name", OccurencePath = s.PathString, PointLocation = PointLocationEnum.MaxX });
            }

            InventorApplication.ActiveDocument.ClearSelection();
        }

        private void saveDimensions_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets.Add();

            Worksheet sheet = Globals.ThisAddIn.Application.ActiveSheet;

            sheet.Name = "Test GA Capture";

            sheet.Range["A1"].Value = captureDto.FileName;
            sheet.Range["B1"].Value = captureDto.Name;

            //sheet.Range["A3"].Value = 

            foreach (var s in captureDto.Sheets)
            {

            }
            
        }
    }
}
