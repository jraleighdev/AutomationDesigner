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

namespace AutomationDesigner.Controls.AppSettings.Inventor
{
    /// <summary>
    /// Interaction logic for InventorSettinsControl.xaml
    /// </summary>
    public partial class InventorSettingsControl : UserControl
    {
        private InventorSettingsViewModel _viewModel;

        public InventorSettingsControl()
        {
            InitializeComponent();

            _viewModel = new InventorSettingsViewModel(this);

            this.DataContext = _viewModel;
        }

        public delegate void CloseFormHandler();

        public static event CloseFormHandler CloseForm;

        public void EmitClose()
        {
            CloseForm();
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ViewModelFinder(sender).IsReadOnly = false;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ViewModelFinder(sender).IsReadOnly = true;
        }

        private FilePathContainsViewModel ViewModelFinder(object sender)
        {
            if (sender is TextBox text)
            {
                return text.DataContext as FilePathContainsViewModel;
            }

            return null;
        }
    }
}
