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

namespace AutomationDesigner.Controls.Capture.Solidworks
{
    /// <summary>
    /// Interaction logic for SolidworksCaptureControl.xaml
    /// </summary>
    public partial class SolidworksCaptureControl : UserControl
    {
        public SolidworksCaptureControl()
        {
            InitializeComponent();

            var viewModel = new SolidworksCaptureDesignViewModel(this);

            this.DataContext = viewModel;
        }
    }
}
