namespace AutomationDesigner.Forms
{
    partial class SettingsForm
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
            this.settingsTabs = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.generalSettingsTab = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.inventorUnitsSelector = new Syncfusion.WinForms.ListView.SfComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.copySettingsTab = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.FilePathsToAvoidGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.settingsOkbutton = new Syncfusion.WinForms.Controls.SfButton();
            this.settingsCancelButton = new Syncfusion.WinForms.Controls.SfButton();
            this.label2 = new System.Windows.Forms.Label();
            this.inventorAngularUnitSelector = new Syncfusion.WinForms.ListView.SfComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.settingsTabs)).BeginInit();
            this.settingsTabs.SuspendLayout();
            this.generalSettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventorUnitsSelector)).BeginInit();
            this.copySettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilePathsToAvoidGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventorAngularUnitSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsTabs
            // 
            this.settingsTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsTabs.BeforeTouchSize = new System.Drawing.Size(325, 199);
            this.settingsTabs.Controls.Add(this.generalSettingsTab);
            this.settingsTabs.Controls.Add(this.copySettingsTab);
            this.settingsTabs.FocusOnTabClick = false;
            this.settingsTabs.Location = new System.Drawing.Point(2, 0);
            this.settingsTabs.Name = "settingsTabs";
            this.settingsTabs.Size = new System.Drawing.Size(325, 199);
            this.settingsTabs.TabIndex = 0;
            this.settingsTabs.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererMetro);
            this.settingsTabs.ThemeName = "TabRendererMetro";
            // 
            // generalSettingsTab
            // 
            this.generalSettingsTab.Controls.Add(this.inventorAngularUnitSelector);
            this.generalSettingsTab.Controls.Add(this.label2);
            this.generalSettingsTab.Controls.Add(this.inventorUnitsSelector);
            this.generalSettingsTab.Controls.Add(this.label1);
            this.generalSettingsTab.Image = null;
            this.generalSettingsTab.ImageSize = new System.Drawing.Size(16, 16);
            this.generalSettingsTab.Location = new System.Drawing.Point(1, 22);
            this.generalSettingsTab.Name = "generalSettingsTab";
            this.generalSettingsTab.ShowCloseButton = true;
            this.generalSettingsTab.Size = new System.Drawing.Size(322, 175);
            this.generalSettingsTab.TabIndex = 2;
            this.generalSettingsTab.Text = "General";
            this.generalSettingsTab.ThemesEnabled = false;
            // 
            // inventorUnitsSelector
            // 
            this.inventorUnitsSelector.Location = new System.Drawing.Point(92, 3);
            this.inventorUnitsSelector.Name = "inventorUnitsSelector";
            this.inventorUnitsSelector.Size = new System.Drawing.Size(121, 28);
            this.inventorUnitsSelector.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.inventorUnitsSelector.TabIndex = 6;
            this.inventorUnitsSelector.SelectedIndexChanged += new System.EventHandler(this.inventorUnitsSelector_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Length Units";
            // 
            // copySettingsTab
            // 
            this.copySettingsTab.Controls.Add(this.FilePathsToAvoidGrid);
            this.copySettingsTab.Image = null;
            this.copySettingsTab.ImageSize = new System.Drawing.Size(16, 16);
            this.copySettingsTab.Location = new System.Drawing.Point(1, 22);
            this.copySettingsTab.Name = "copySettingsTab";
            this.copySettingsTab.ShowCloseButton = true;
            this.copySettingsTab.Size = new System.Drawing.Size(322, 175);
            this.copySettingsTab.TabIndex = 1;
            this.copySettingsTab.Text = "Copy";
            this.copySettingsTab.ThemesEnabled = false;
            // 
            // FilePathsToAvoidGrid
            // 
            this.FilePathsToAvoidGrid.AccessibleName = "Table";
            this.FilePathsToAvoidGrid.AllowDeleting = true;
            this.FilePathsToAvoidGrid.AllowFiltering = true;
            this.FilePathsToAvoidGrid.AllowResizingColumns = true;
            this.FilePathsToAvoidGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            this.FilePathsToAvoidGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilePathsToAvoidGrid.Location = new System.Drawing.Point(0, 0);
            this.FilePathsToAvoidGrid.Name = "FilePathsToAvoidGrid";
            this.FilePathsToAvoidGrid.Size = new System.Drawing.Size(322, 175);
            this.FilePathsToAvoidGrid.TabIndex = 0;
            this.FilePathsToAvoidGrid.Text = "sfDataGrid1";
            this.FilePathsToAvoidGrid.AutoGeneratingColumn += new Syncfusion.WinForms.DataGrid.Events.AutoGeneratingColumnEventHandler(this.FilePathsToAvoidGrid_AutoGeneratingColumn);
            // 
            // settingsOkbutton
            // 
            this.settingsOkbutton.AccessibleName = "Button";
            this.settingsOkbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsOkbutton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.settingsOkbutton.Location = new System.Drawing.Point(169, 210);
            this.settingsOkbutton.Name = "settingsOkbutton";
            this.settingsOkbutton.Size = new System.Drawing.Size(75, 25);
            this.settingsOkbutton.TabIndex = 1;
            this.settingsOkbutton.Text = "Ok";
            this.settingsOkbutton.Click += new System.EventHandler(this.settingsOkbutton_Click);
            // 
            // settingsCancelButton
            // 
            this.settingsCancelButton.AccessibleName = "Button";
            this.settingsCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsCancelButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.settingsCancelButton.Location = new System.Drawing.Point(250, 210);
            this.settingsCancelButton.Name = "settingsCancelButton";
            this.settingsCancelButton.Size = new System.Drawing.Size(75, 25);
            this.settingsCancelButton.TabIndex = 2;
            this.settingsCancelButton.Text = "Cancel";
            this.settingsCancelButton.Click += new System.EventHandler(this.settingsCancelButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Angular Units";
            // 
            // inventorAngularUnitSelector
            // 
            this.inventorAngularUnitSelector.Location = new System.Drawing.Point(92, 46);
            this.inventorAngularUnitSelector.Name = "inventorAngularUnitSelector";
            this.inventorAngularUnitSelector.Size = new System.Drawing.Size(121, 28);
            this.inventorAngularUnitSelector.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.inventorAngularUnitSelector.TabIndex = 8;
            this.inventorAngularUnitSelector.SelectedIndexChanged += new System.EventHandler(this.inventorAngularUnitSelector_SelectedIndexChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 240);
            this.Controls.Add(this.settingsCancelButton);
            this.Controls.Add(this.settingsOkbutton);
            this.Controls.Add(this.settingsTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "Inventor Build Settings";
            ((System.ComponentModel.ISupportInitialize)(this.settingsTabs)).EndInit();
            this.settingsTabs.ResumeLayout(false);
            this.generalSettingsTab.ResumeLayout(false);
            this.generalSettingsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventorUnitsSelector)).EndInit();
            this.copySettingsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FilePathsToAvoidGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventorAngularUnitSelector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv settingsTabs;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv copySettingsTab;
        private Syncfusion.WinForms.DataGrid.SfDataGrid FilePathsToAvoidGrid;
        private Syncfusion.WinForms.Controls.SfButton settingsOkbutton;
        private Syncfusion.WinForms.Controls.SfButton settingsCancelButton;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv generalSettingsTab;
        private System.Windows.Forms.Label label1;
        private Syncfusion.WinForms.ListView.SfComboBox inventorUnitsSelector;
        private Syncfusion.WinForms.ListView.SfComboBox inventorAngularUnitSelector;
        private System.Windows.Forms.Label label2;
    }
}