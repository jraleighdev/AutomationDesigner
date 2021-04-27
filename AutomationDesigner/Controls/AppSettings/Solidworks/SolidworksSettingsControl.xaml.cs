using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomationDesigner.Controls.AppSettings.Solidworks
{
    /// <summary>
    /// Interaction logic for SolidworksSettingsControl.xaml
    /// </summary>
    public partial class SolidworksSettingsControl : UserControl
    {
        private SolidworksSettingsViewModel _viewModel;

        public SolidworksSettingsControl()
        {
            InitializeComponent();

            _viewModel = new SolidworksSettingsViewModel(this);

            this.DataContext = _viewModel;
        }

        public delegate void CloseFormHandler();

        public static event CloseFormHandler CloseForm;

        public void EmitClose()
        {
            CloseForm();
        }
    }
}
