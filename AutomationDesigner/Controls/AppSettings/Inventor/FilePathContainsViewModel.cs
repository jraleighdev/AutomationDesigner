using AutomationDesigner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDesigner.Controls.AppSettings.Inventor
{
    public class FilePathContainsViewModel : BaseViewModel
    {
        private bool _edit;

        private string _name;

        public bool IsReadOnly
        {
            get => _edit;
            set
            {
                _edit = value;
                OnPropertyChanged(nameof(IsReadOnly));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}
