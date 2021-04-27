using AutomationDesigner.Helpers;
using AutomationDesigner.ViewModels.Base;
using SolidworksWrapper.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationDesigner.Controls.AppSettings.Solidworks
{
    public class SolidworksSettingsViewModel : BaseViewModel
    {
        private SolidworksSettingsControl _solidworksSettingsControl;

        private UnitTypes _selectedUnitType;

        private ObservableCollection<UnitTypes> _lengthUnits;

        public UnitTypes SelectedUnitType
        {
            get => _selectedUnitType;
            set
            {
                _selectedUnitType = value;
                OnPropertyChanged(nameof(SelectedUnitType));
            }
        }

        public ObservableCollection<UnitTypes> LengthUnits
        {
            get => _lengthUnits;
            set
            {
                _lengthUnits = value;
                OnPropertyChanged(nameof(LengthUnits));
            }
        }

        public ICommand SaveCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public SolidworksSettingsViewModel(SolidworksSettingsControl solidworksSettingsControl)
        {
            _solidworksSettingsControl = solidworksSettingsControl;

            LengthUnits = new ObservableCollection<UnitTypes>();

            LengthUnits.AddRange(UnitManager.MeasurementUnits);

            SelectedUnitType = (UnitTypes)Settings.Default.SelectedUnits;

            // Commands
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Close);
        }

        public void Save()
        {
            Settings.Default.PathsToAvoid.Clear();
            Settings.Default.SelectedUnits = (int)SelectedUnitType;
            UnitManager.UnitTypes = SelectedUnitType;

            Settings.Default.Save();

            Close();
        }

        public void Close()
        {
            _solidworksSettingsControl.EmitClose();
        }

    }
}
