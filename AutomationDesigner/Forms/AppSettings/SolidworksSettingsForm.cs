using AutomationDesigner.Controls.AppSettings.Solidworks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomationDesigner.Forms.AppSettings
{
    public partial class SolidworksSettingsForm : Form
    {
        public SolidworksSettingsForm()
        {
            InitializeComponent();

            SolidworksSettingsControl.CloseForm += CloseForm;
        }

        private void CloseForm()
        {
            this.Close();
        }

        private void SolidworksSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SolidworksSettingsControl.CloseForm -= CloseForm;
        }
    }
}
