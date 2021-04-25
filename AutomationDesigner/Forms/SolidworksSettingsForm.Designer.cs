namespace AutomationDesigner.Forms
{
    partial class SolidworksSettingsForm
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
            this.settingsOkbutton = new Syncfusion.WinForms.Controls.SfButton();
            this.settingsCancelButton = new Syncfusion.WinForms.Controls.SfButton();
            this.solidworksSettingUnitSelector = new Syncfusion.WinForms.ListView.SfComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.solidworksSettingUnitSelector)).BeginInit();
            this.SuspendLayout();
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
            // solidworksSettingUnitSelector
            // 
            this.solidworksSettingUnitSelector.Location = new System.Drawing.Point(95, 5);
            this.solidworksSettingUnitSelector.Name = "solidworksSettingUnitSelector";
            this.solidworksSettingUnitSelector.Size = new System.Drawing.Size(121, 28);
            this.solidworksSettingUnitSelector.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.solidworksSettingUnitSelector.TabIndex = 3;
            this.solidworksSettingUnitSelector.SelectedIndexChanged += new System.EventHandler(this.solidworksSettingUnitSelector_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Document Units";
            // 
            // SolidworksSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 240);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.solidworksSettingUnitSelector);
            this.Controls.Add(this.settingsCancelButton);
            this.Controls.Add(this.settingsOkbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SolidworksSettingsForm";
            this.ShowIcon = false;
            this.Text = "Solidworks Build Settings";
            ((System.ComponentModel.ISupportInitialize)(this.solidworksSettingUnitSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton settingsOkbutton;
        private Syncfusion.WinForms.Controls.SfButton settingsCancelButton;
        private Syncfusion.WinForms.ListView.SfComboBox solidworksSettingUnitSelector;
        private System.Windows.Forms.Label label1;
    }
}