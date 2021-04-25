using System;
using System.Drawing;
using System.Windows.Forms;
using SolidworksWrapper.General;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.ListView;

namespace AutomationDesigner.Forms
{
    public partial class SolidworksSettingsForm : SfForm
    {
        private UnitTypes selectedUnits;

        public SolidworksSettingsForm()
        {
            InitializeComponent();

            Styling();

            solidworksSettingUnitSelector.DataSource = UnitManager.MeasurementUnits;

            solidworksSettingUnitSelector.SelectedIndex = (int)UnitManager.UnitTypes;
        }

        private void Styling()
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
            this.Style.TitleBar.Font = this.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.Style.TitleBar.TextHorizontalAlignment = HorizontalAlignment.Center;
            this.Style.TitleBar.TextVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
        }

        // save the settings
        private void settingsOkbutton_Click(object sender, EventArgs e)
        {
            UnitManager.UnitTypes = selectedUnits;
            Settings.Default.SelectedUnits = (int)selectedUnits;
            Settings.Default.Save();
            this.Close();
        }

        private void settingsCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void solidworksSettingUnitSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as SfComboBox;

            if (comboBox != null)
            {
                selectedUnits = (UnitTypes)comboBox.SelectedIndex;
            }
        }
    }
}
