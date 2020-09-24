namespace AutomationDesinger.Forms
{
    partial class CaptureDesignForm
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
            Syncfusion.WinForms.DataGrid.GridButtonColumn gridButtonColumn1 = new Syncfusion.WinForms.DataGrid.GridButtonColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureDesignForm));
            Syncfusion.WinForms.DataGrid.GridButtonColumn gridButtonColumn2 = new Syncfusion.WinForms.DataGrid.GridButtonColumn();
            this.dimensionCaptureGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.selectedRangeTextBox = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCaptureDims = new Syncfusion.WinForms.Controls.SfButton();
            this.captureTabs = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.dimensionTab = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.featureTab = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.featureCaptureGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dimensionCaptureGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedRangeTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.captureTabs)).BeginInit();
            this.captureTabs.SuspendLayout();
            this.dimensionTab.SuspendLayout();
            this.featureTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.featureCaptureGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dimensionCaptureGrid
            // 
            this.dimensionCaptureGrid.AccessibleName = "Table";
            this.dimensionCaptureGrid.AllowEditing = false;
            this.dimensionCaptureGrid.AllowFiltering = true;
            this.dimensionCaptureGrid.AllowResizingColumns = true;
            this.dimensionCaptureGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridButtonColumn1.AllowDefaultButtonText = false;
            gridButtonColumn1.AllowEditing = false;
            gridButtonColumn1.AllowFiltering = true;
            gridButtonColumn1.AllowResizing = true;
            gridButtonColumn1.ButtonSize = new System.Drawing.Size(0, 0);
            gridButtonColumn1.CellStyle.HorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            gridButtonColumn1.DefaultButtonText = "";
            gridButtonColumn1.HeaderText = "Add";
            gridButtonColumn1.Image = ((System.Drawing.Image)(resources.GetObject("gridButtonColumn1.Image")));
            gridButtonColumn1.ImageSize = new System.Drawing.Size(0, 0);
            gridButtonColumn1.MappingName = "submitColumn";
            this.dimensionCaptureGrid.Columns.Add(gridButtonColumn1);
            this.dimensionCaptureGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dimensionCaptureGrid.Location = new System.Drawing.Point(0, 0);
            this.dimensionCaptureGrid.Name = "dimensionCaptureGrid";
            this.dimensionCaptureGrid.Size = new System.Drawing.Size(271, 177);
            this.dimensionCaptureGrid.TabIndex = 0;
            this.dimensionCaptureGrid.Text = "sfDataGrid1";
            this.dimensionCaptureGrid.AutoGeneratingColumn += new Syncfusion.WinForms.DataGrid.Events.AutoGeneratingColumnEventHandler(this.dimensionCaptureGrid_AutoGeneratingColumn);
            // 
            // selectedRangeTextBox
            // 
            this.selectedRangeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedRangeTextBox.Location = new System.Drawing.Point(179, 5);
            this.selectedRangeTextBox.Name = "selectedRangeTextBox";
            this.selectedRangeTextBox.Size = new System.Drawing.Size(100, 20);
            this.selectedRangeTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selected Range";
            // 
            // buttonCaptureDims
            // 
            this.buttonCaptureDims.AccessibleName = "Button";
            this.buttonCaptureDims.BackColor = System.Drawing.SystemColors.Window;
            this.buttonCaptureDims.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.buttonCaptureDims.ImageSize = new System.Drawing.Size(32, 32);
            this.buttonCaptureDims.Location = new System.Drawing.Point(5, 5);
            this.buttonCaptureDims.Name = "buttonCaptureDims";
            this.buttonCaptureDims.Size = new System.Drawing.Size(47, 44);
            this.buttonCaptureDims.Style.BackColor = System.Drawing.SystemColors.Window;
            this.buttonCaptureDims.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.buttonCaptureDims.TabIndex = 3;
            this.buttonCaptureDims.UseVisualStyleBackColor = false;
            this.buttonCaptureDims.Click += new System.EventHandler(this.buttonCaptureDims_Click);
            // 
            // captureTabs
            // 
            this.captureTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.captureTabs.BeforeTouchSize = new System.Drawing.Size(274, 201);
            this.captureTabs.Controls.Add(this.dimensionTab);
            this.captureTabs.Controls.Add(this.featureTab);
            this.captureTabs.FocusOnTabClick = false;
            this.captureTabs.Location = new System.Drawing.Point(5, 55);
            this.captureTabs.Name = "captureTabs";
            this.captureTabs.Size = new System.Drawing.Size(274, 201);
            this.captureTabs.TabIndex = 4;
            this.captureTabs.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererMetro);
            this.captureTabs.ThemeName = "TabRendererMetro";
            // 
            // dimensionTab
            // 
            this.dimensionTab.Controls.Add(this.dimensionCaptureGrid);
            this.dimensionTab.Image = null;
            this.dimensionTab.ImageSize = new System.Drawing.Size(16, 16);
            this.dimensionTab.Location = new System.Drawing.Point(1, 22);
            this.dimensionTab.Name = "dimensionTab";
            this.dimensionTab.ShowCloseButton = true;
            this.dimensionTab.Size = new System.Drawing.Size(271, 177);
            this.dimensionTab.TabIndex = 1;
            this.dimensionTab.Text = "Dimensions";
            this.dimensionTab.ThemesEnabled = false;
            // 
            // featureTab
            // 
            this.featureTab.Controls.Add(this.featureCaptureGrid);
            this.featureTab.Image = null;
            this.featureTab.ImageSize = new System.Drawing.Size(16, 16);
            this.featureTab.Location = new System.Drawing.Point(1, 22);
            this.featureTab.Name = "featureTab";
            this.featureTab.ShowCloseButton = true;
            this.featureTab.Size = new System.Drawing.Size(271, 177);
            this.featureTab.TabIndex = 2;
            this.featureTab.Text = "Features";
            this.featureTab.ThemesEnabled = false;
            // 
            // featureCaptureGrid
            // 
            this.featureCaptureGrid.AccessibleName = "Table";
            this.featureCaptureGrid.AllowEditing = false;
            this.featureCaptureGrid.AllowFiltering = true;
            this.featureCaptureGrid.AllowResizingColumns = true;
            this.featureCaptureGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridButtonColumn2.AllowDefaultButtonText = false;
            gridButtonColumn2.AllowEditing = false;
            gridButtonColumn2.AllowFiltering = true;
            gridButtonColumn2.AllowResizing = true;
            gridButtonColumn2.ButtonSize = new System.Drawing.Size(0, 0);
            gridButtonColumn2.CellStyle.HorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            gridButtonColumn2.DefaultButtonText = "";
            gridButtonColumn2.HeaderText = "Add";
            gridButtonColumn2.Image = ((System.Drawing.Image)(resources.GetObject("gridButtonColumn2.Image")));
            gridButtonColumn2.ImageSize = new System.Drawing.Size(0, 0);
            gridButtonColumn2.MappingName = "submitColumn";
            this.featureCaptureGrid.Columns.Add(gridButtonColumn2);
            this.featureCaptureGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.featureCaptureGrid.Location = new System.Drawing.Point(0, 0);
            this.featureCaptureGrid.Name = "featureCaptureGrid";
            this.featureCaptureGrid.Size = new System.Drawing.Size(271, 177);
            this.featureCaptureGrid.TabIndex = 1;
            this.featureCaptureGrid.Text = "sfDataGrid1";
            this.featureCaptureGrid.AutoGeneratingColumn += new Syncfusion.WinForms.DataGrid.Events.AutoGeneratingColumnEventHandler(this.featureCaptureGrid_AutoGeneratingColumn);
            // 
            // CaptureDesignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.captureTabs);
            this.Controls.Add(this.buttonCaptureDims);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectedRangeTextBox);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "CaptureDesignForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CaptureDesignFormn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CaptureDesignFormn_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dimensionCaptureGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedRangeTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.captureTabs)).EndInit();
            this.captureTabs.ResumeLayout(false);
            this.dimensionTab.ResumeLayout(false);
            this.featureTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.featureCaptureGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Syncfusion.WinForms.DataGrid.SfDataGrid dimensionCaptureGrid;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt selectedRangeTextBox;
        private System.Windows.Forms.Label label1;
        private Syncfusion.WinForms.Controls.SfButton buttonCaptureDims;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv captureTabs;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv dimensionTab;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv featureTab;
        protected Syncfusion.WinForms.DataGrid.SfDataGrid featureCaptureGrid;
    }
}