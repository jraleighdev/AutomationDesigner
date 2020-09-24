namespace AutomationDesinger.Forms.DrawingCapture
{
    partial class DrawingCaptureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Syncfusion.Windows.Forms.Tools.TreeNodeAdvStyleInfo treeNodeAdvStyleInfo1 = new Syncfusion.Windows.Forms.Tools.TreeNodeAdvStyleInfo();
            this.drawingNameTextBox = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.ViewTree = new Syncfusion.Windows.Forms.Tools.TreeViewAdv();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.viewNameLabel = new System.Windows.Forms.Label();
            this.viewScaleLabel = new System.Windows.Forms.Label();
            this.viewXLabel = new System.Windows.Forms.Label();
            this.viewYLabel = new System.Windows.Forms.Label();
            this.viewDimGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.DimCaptureGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.CreateDimBtn = new Syncfusion.WinForms.Controls.SfButton();
            this.startCaptureButton = new Syncfusion.WinForms.Controls.SfButton();
            this.endCaptureButton = new Syncfusion.WinForms.Controls.SfButton();
            this.saveDimensions = new Syncfusion.WinForms.Controls.SfButton();
            ((System.ComponentModel.ISupportInitialize)(this.drawingNameTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewTree)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewDimGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DimCaptureGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // drawingNameTextBox
            // 
            this.drawingNameTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.drawingNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawingNameTextBox.Location = new System.Drawing.Point(12, 5);
            this.drawingNameTextBox.Name = "drawingNameTextBox";
            this.drawingNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.drawingNameTextBox.TabIndex = 0;
            this.drawingNameTextBox.Text = "textBoxExt1";
            this.drawingNameTextBox.ThemeName = "Metro";
            // 
            // ViewTree
            // 
            this.ViewTree.AccelerateScrolling = Syncfusion.Windows.Forms.AccelerateScrollingBehavior.Immediate;
            this.ViewTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ViewTree.BackColor = System.Drawing.Color.White;
            treeNodeAdvStyleInfo1.CheckBoxTickThickness = 1;
            treeNodeAdvStyleInfo1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            treeNodeAdvStyleInfo1.EnsureDefaultOptionedChild = true;
            treeNodeAdvStyleInfo1.IntermediateCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            treeNodeAdvStyleInfo1.OptionButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            treeNodeAdvStyleInfo1.SelectedOptionButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            treeNodeAdvStyleInfo1.ShowCheckBox = false;
            treeNodeAdvStyleInfo1.ShowOptionButton = false;
            treeNodeAdvStyleInfo1.ShowPlusMinus = true;
            treeNodeAdvStyleInfo1.TextColor = System.Drawing.Color.Black;
            this.ViewTree.BaseStylePairs.AddRange(new Syncfusion.Windows.Forms.Tools.StyleNamePair[] {
            new Syncfusion.Windows.Forms.Tools.StyleNamePair("Standard", treeNodeAdvStyleInfo1)});
            this.ViewTree.BeforeTouchSize = new System.Drawing.Size(100, 462);
            this.ViewTree.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.ViewTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.ViewTree.HelpTextControl.BaseThemeName = null;
            this.ViewTree.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ViewTree.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.ViewTree.HelpTextControl.Name = "";
            this.ViewTree.HelpTextControl.Size = new System.Drawing.Size(15, 15);
            this.ViewTree.HelpTextControl.TabIndex = 0;
            this.ViewTree.HelpTextControl.Visible = true;
            this.ViewTree.InactiveSelectedNodeForeColor = System.Drawing.SystemColors.ControlText;
            this.ViewTree.Location = new System.Drawing.Point(12, 31);
            this.ViewTree.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.ViewTree.Name = "ViewTree";
            this.ViewTree.SelectedNodeBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220))))));
            this.ViewTree.SelectedNodeForeColor = System.Drawing.SystemColors.HighlightText;
            this.ViewTree.ShowFocusRect = false;
            this.ViewTree.ShowLines = false;
            this.ViewTree.Size = new System.Drawing.Size(100, 462);
            this.ViewTree.Style = Syncfusion.Windows.Forms.Tools.TreeStyle.Metro;
            this.ViewTree.TabIndex = 1;
            this.ViewTree.Text = "treeViewAdv1";
            this.ViewTree.ThemeName = "Metro";
            this.ViewTree.ThemeStyle.TreeNodeAdvStyle.CheckBoxTickThickness = 0;
            this.ViewTree.ThemeStyle.TreeNodeAdvStyle.EnsureDefaultOptionedChild = true;
            // 
            // 
            // 
            this.ViewTree.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            this.ViewTree.ToolTipControl.BaseThemeName = null;
            this.ViewTree.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ViewTree.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.ViewTree.ToolTipControl.Name = "";
            this.ViewTree.ToolTipControl.Size = new System.Drawing.Size(15, 15);
            this.ViewTree.ToolTipControl.TabIndex = 0;
            this.ViewTree.ToolTipControl.Visible = true;
            this.ViewTree.AfterSelect += new System.EventHandler(this.ViewTree_AfterSelect);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.viewNameLabel);
            this.flowLayoutPanel1.Controls.Add(this.viewScaleLabel);
            this.flowLayoutPanel1.Controls.Add(this.viewXLabel);
            this.flowLayoutPanel1.Controls.Add(this.viewYLabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(118, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(230, 20);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // viewNameLabel
            // 
            this.viewNameLabel.AutoSize = true;
            this.viewNameLabel.Location = new System.Drawing.Point(3, 0);
            this.viewNameLabel.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.viewNameLabel.Name = "viewNameLabel";
            this.viewNameLabel.Size = new System.Drawing.Size(29, 13);
            this.viewNameLabel.TabIndex = 1;
            this.viewNameLabel.Text = "hello";
            // 
            // viewScaleLabel
            // 
            this.viewScaleLabel.AutoSize = true;
            this.viewScaleLabel.Location = new System.Drawing.Point(40, 0);
            this.viewScaleLabel.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.viewScaleLabel.Name = "viewScaleLabel";
            this.viewScaleLabel.Size = new System.Drawing.Size(35, 13);
            this.viewScaleLabel.TabIndex = 2;
            this.viewScaleLabel.Text = "label3";
            // 
            // viewXLabel
            // 
            this.viewXLabel.AutoSize = true;
            this.viewXLabel.Location = new System.Drawing.Point(83, 0);
            this.viewXLabel.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.viewXLabel.Name = "viewXLabel";
            this.viewXLabel.Size = new System.Drawing.Size(35, 13);
            this.viewXLabel.TabIndex = 3;
            this.viewXLabel.Text = "label4";
            // 
            // viewYLabel
            // 
            this.viewYLabel.AutoSize = true;
            this.viewYLabel.Location = new System.Drawing.Point(126, 0);
            this.viewYLabel.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.viewYLabel.Name = "viewYLabel";
            this.viewYLabel.Size = new System.Drawing.Size(35, 13);
            this.viewYLabel.TabIndex = 0;
            this.viewYLabel.Text = "label1";
            // 
            // viewDimGrid
            // 
            this.viewDimGrid.AccessibleName = "Table";
            this.viewDimGrid.AllowFiltering = true;
            this.viewDimGrid.AllowResizingColumns = true;
            this.viewDimGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.viewDimGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            this.viewDimGrid.Location = new System.Drawing.Point(118, 61);
            this.viewDimGrid.Name = "viewDimGrid";
            this.viewDimGrid.Size = new System.Drawing.Size(230, 432);
            this.viewDimGrid.TabIndex = 3;
            this.viewDimGrid.Text = "sfDataGrid1";
            this.viewDimGrid.AutoGeneratingColumn += new Syncfusion.WinForms.DataGrid.Events.AutoGeneratingColumnEventHandler(this.viewDimGrid_AutoGeneratingColumn);
            this.viewDimGrid.SelectionChanged += new Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventHandler(this.viewDimGrid_SelectionChanged);
            // 
            // DimCaptureGrid
            // 
            this.DimCaptureGrid.AccessibleName = "Table";
            this.DimCaptureGrid.AllowFiltering = true;
            this.DimCaptureGrid.AllowResizingColumns = true;
            this.DimCaptureGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DimCaptureGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            this.DimCaptureGrid.Location = new System.Drawing.Point(354, 31);
            this.DimCaptureGrid.Name = "DimCaptureGrid";
            this.DimCaptureGrid.ShowToolTip = true;
            this.DimCaptureGrid.Size = new System.Drawing.Size(679, 462);
            this.DimCaptureGrid.TabIndex = 4;
            this.DimCaptureGrid.Text = "sfDataGrid1";
            // 
            // CreateDimBtn
            // 
            this.CreateDimBtn.AccessibleName = "Button";
            this.CreateDimBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.CreateDimBtn.Location = new System.Drawing.Point(118, 35);
            this.CreateDimBtn.Name = "CreateDimBtn";
            this.CreateDimBtn.Size = new System.Drawing.Size(96, 20);
            this.CreateDimBtn.TabIndex = 5;
            this.CreateDimBtn.Text = "Add New Dim";
            this.CreateDimBtn.ThemeName = "";
            this.CreateDimBtn.Click += new System.EventHandler(this.CreateDimBtn_Click);
            // 
            // startCaptureButton
            // 
            this.startCaptureButton.AccessibleName = "Button";
            this.startCaptureButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.startCaptureButton.Location = new System.Drawing.Point(354, 5);
            this.startCaptureButton.Name = "startCaptureButton";
            this.startCaptureButton.Size = new System.Drawing.Size(96, 20);
            this.startCaptureButton.TabIndex = 6;
            this.startCaptureButton.Text = "Start Capture";
            this.startCaptureButton.ThemeName = "";
            this.startCaptureButton.Click += new System.EventHandler(this.startCaptureButton_Click);
            // 
            // endCaptureButton
            // 
            this.endCaptureButton.AccessibleName = "Button";
            this.endCaptureButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.endCaptureButton.Location = new System.Drawing.Point(456, 5);
            this.endCaptureButton.Name = "endCaptureButton";
            this.endCaptureButton.Size = new System.Drawing.Size(96, 20);
            this.endCaptureButton.TabIndex = 7;
            this.endCaptureButton.Text = "End Capture";
            this.endCaptureButton.ThemeName = "";
            this.endCaptureButton.Click += new System.EventHandler(this.endCaptureButton_Click);
            // 
            // saveDimensions
            // 
            this.saveDimensions.AccessibleName = "Button";
            this.saveDimensions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveDimensions.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.saveDimensions.Location = new System.Drawing.Point(937, 5);
            this.saveDimensions.Name = "saveDimensions";
            this.saveDimensions.Size = new System.Drawing.Size(96, 20);
            this.saveDimensions.TabIndex = 8;
            this.saveDimensions.Text = "Save Capture";
            this.saveDimensions.ThemeName = "";
            this.saveDimensions.Click += new System.EventHandler(this.saveDimensions_Click);
            // 
            // DrawingCaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 498);
            this.Controls.Add(this.saveDimensions);
            this.Controls.Add(this.ViewTree);
            this.Controls.Add(this.endCaptureButton);
            this.Controls.Add(this.startCaptureButton);
            this.Controls.Add(this.CreateDimBtn);
            this.Controls.Add(this.DimCaptureGrid);
            this.Controls.Add(this.viewDimGrid);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.drawingNameTextBox);
            this.Name = "DrawingCaptureForm";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Text = "DrawingCaptureForm";
            ((System.ComponentModel.ISupportInitialize)(this.drawingNameTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewTree)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewDimGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DimCaptureGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.TreeViewAdv ViewTree;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt drawingNameTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label viewNameLabel;
        private System.Windows.Forms.Label viewScaleLabel;
        private System.Windows.Forms.Label viewXLabel;
        private System.Windows.Forms.Label viewYLabel;
        private Syncfusion.WinForms.DataGrid.SfDataGrid viewDimGrid;
        private Syncfusion.WinForms.DataGrid.SfDataGrid DimCaptureGrid;
        private Syncfusion.WinForms.Controls.SfButton CreateDimBtn;
        private Syncfusion.WinForms.Controls.SfButton startCaptureButton;
        private Syncfusion.WinForms.Controls.SfButton endCaptureButton;
        private Syncfusion.WinForms.Controls.SfButton saveDimensions;
    }
}