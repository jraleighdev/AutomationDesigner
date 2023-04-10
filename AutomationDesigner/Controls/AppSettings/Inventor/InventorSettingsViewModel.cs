using AutomationDesigner.Helpers;
using AutomationDesigner.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AutomationDesigner.Controls.AppSettings.Inventor
{
    public class InventorSettingsViewModel : BaseViewModel
    {
        #region Fields

        private LengthUnits _selectedLengthUnits;

        private AngularUnits _selectedAngularUnits;

        private ObservableCollection<LengthUnits> _lengthUnits;

        private ObservableCollection<AngularUnits> _angularUnits;

        private ObservableCollection<FilePathContainsViewModel> _filePathContains;

        private FilePathContainsViewModel _selectedPath;

        private readonly InventorSettingsControl _inventorSettingsControl;

        private string _newPath;

        #endregion

        #region Properties

        public FilePathContainsViewModel SelectedPath
        {
            get => _selectedPath;
            set
            {
                _selectedPath = value;
                OnPropertyChanged(nameof(SelectedPath));
            }
        }


        public string NewPath
        {
            get => _newPath;
            set
            {
                _newPath = value;
                OnPropertyChanged(nameof(NewPath));
            }
        }

        public ObservableCollection<FilePathContainsViewModel> FilePathContains
        {
            get => _filePathContains;
            set
            {
                _filePathContains = value;
                OnPropertyChanged(nameof(FilePathContains));
            }
        }

        public LengthUnits SelectedLengthUnit
        {
            get => _selectedLengthUnits;
            set
            {
                _selectedLengthUnits = value;
                OnPropertyChanged(nameof(SelectedLengthUnit));
            }
        }

        public AngularUnits SelectedAngularUnit
        {
            get => _selectedAngularUnits;
            set
            {
                _selectedAngularUnits = value;
                OnPropertyChanged(nameof(SelectedAngularUnit));
            }
        }

        public ObservableCollection<LengthUnits> LengthUnits
        {
            get => _lengthUnits;
            set
            {
                _lengthUnits = value;
                OnPropertyChanged(nameof(LengthUnits));
            }
        }

        public ObservableCollection<AngularUnits> AngularUnits
        {
            get => _angularUnits;
            set
            {
                _angularUnits = value;
                OnPropertyChanged(nameof(AngularUnits));
            }
        }

        #endregion

        #region Commands

        public ICommand SaveCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        #endregion

        public InventorSettingsViewModel(InventorSettingsControl inventorSettingsControl)
        {
            // Collections
            LengthUnits = new ObservableCollection<LengthUnits>();
            AngularUnits = new ObservableCollection<AngularUnits>();
            FilePathContains = new ObservableCollection<FilePathContainsViewModel>();

            // Add Data
            LengthUnits.AddRange(UnitManager.MeasurementUnits);
            AngularUnits.AddRange(UnitManager.AngularMeasurementUnits);
            SelectedLengthUnit = (LengthUnits)Settings.Default.SelectedUnits;
            SelectedAngularUnit = (AngularUnits)Settings.Default.AngularUnits;

            // Commands
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Close);
            DeleteCommand = new RelayParamCommand(Delete);
            AddCommand = new RelayCommand(Add);

            // Fields
            _inventorSettingsControl = inventorSettingsControl;

            // Setup Methods
            SetupFileSettings();
        }

        public void Save()
        {
            Settings.Default.PathsToAvoid.Clear();
            Settings.Default.SelectedUnits = (int)SelectedLengthUnit;
            Settings.Default.AngularUnits = (int)SelectedAngularUnit;
            UnitManager.LengthUnits = SelectedLengthUnit;
            UnitManager.AngularUnits = SelectedAngularUnit;
            foreach (var c in FilePathContains)
            {
                Settings.Default.PathsToAvoid.Add(c.Name);
            }

            Settings.Default.Save();

            Close();
        }

        private void SetupFileSettings()
        {
            foreach (var s in Settings.Default.PathsToAvoid)
            {
                FilePathContains.Add(new FilePathContainsViewModel { IsReadOnly = true, Name = s });
            }
        }

        private void Add()
        {
            FilePathContains.Add(new FilePathContainsViewModel { IsReadOnly = true, Name = NewPath });
        }

        private void Delete(object value)
        {
            var pathToDelete = value as FilePathContainsViewModel;

            if (pathToDelete != null)
            {
                FilePathContains.Remove(pathToDelete);
            }
        }

        public void Close()
        {
            _inventorSettingsControl.EmitClose();
        }
    }
}
