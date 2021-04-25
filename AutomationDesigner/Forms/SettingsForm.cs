using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using AutomationDesigner.Models;
using InventorWrapper.General;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.ListView;

namespace AutomationDesigner.Forms
{
    public partial class SettingsForm : SfForm
    {
        #region Fields

        private LengthUnits _lengthUnits;

        private AngularUnits _angularUnits;

        #endregion

        #region Properties

        public ObservableCollection<FilePathContains> FilePathContains { get; set; }

        #endregion

        public SettingsForm()
        {
            InitializeComponent();

            Styling();

            SetupFileSettings();

            SetUpUnitSelector();

            SetUpAngularUnitSelector();

            SetupContextMenu();
        }

        #region Setup Methods

        private void SetUpUnitSelector()
        {
            inventorUnitsSelector.DataSource = UnitManager.MeasurementUnits;

            inventorUnitsSelector.SelectedIndex = (int)UnitManager.LengthUnits;
        }

        private void SetUpAngularUnitSelector()
        {
            inventorAngularUnitSelector.DataSource = UnitManager.AngularMeasurementUnits;

            inventorAngularUnitSelector.SelectedIndex = (int)UnitManager.AngularUnits;
        }

        /// <summary>
        /// Set up the file filter page
        /// </summary>
        private void SetupFileSettings()
        {
            FilePathContains = new ObservableCollection<FilePathContains>();

            foreach (var s in Settings.Default.PathsToAvoid)
            {
                FilePathContains.Add(new FilePathContains { Name = s });
            }

            this.FilePathsToAvoidGrid.DataSource = FilePathContains;

            this.FilePathsToAvoidGrid.AddNewRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;
        }

        /// <summary>
        /// Sets up the form styling
        /// </summary>
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
            this.Style.TitleBar.Font = this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Style.TitleBar.TextHorizontalAlignment = HorizontalAlignment.Center;
            this.Style.TitleBar.TextVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
        }

        /// <summary>
        /// Sets up the context menu
        /// </summary>
        private void SetupContextMenu()
        {
            FilePathsToAvoidGrid.RecordContextMenu = new ContextMenuStrip();

            OnDeleteClicked += DeleteRow;

            FilePathsToAvoidGrid.RecordContextMenu.Items.Add("Delete", null, OnDeleteClicked);
        }

        #endregion

        #region Events

        private EventHandler OnDeleteClicked;

        #endregion

        #region methods

        private void settingsOkbutton_Click(object sender, System.EventArgs e)
        {
            Settings.Default.PathsToAvoid.Clear();
            Settings.Default.SelectedUnits = (int)_lengthUnits;
            Settings.Default.AngularUnits = (int)_angularUnits;
            UnitManager.LengthUnits = _lengthUnits;
            UnitManager.AngularUnits = _angularUnits;
            foreach (var c in FilePathContains)
            {
                Settings.Default.PathsToAvoid.Add(c.Name);
            }

            Settings.Default.Save();

            this.Close();
        }

        private void settingsCancelButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void DeleteRow(object sender, EventArgs e)
        {
            FilePathsToAvoidGrid.DeleteSelectedRecords();
        }

        private void FilePathsToAvoidGrid_AutoGeneratingColumn(object sender, Syncfusion.WinForms.DataGrid.Events.AutoGeneratingColumnArgs e)
        {
            if (e.Column.MappingName == "Name")
            {
                e.Column.HeaderText = "Enter a file path or part of path. \nIf the document contains this value it will not be copied.";
            }
        }

        private void inventorUnitsSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as SfComboBox;

            if (comboBox != null)
            {
                _lengthUnits = (LengthUnits)comboBox.SelectedIndex;
            }
        }

        private void inventorAngularUnitSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as SfComboBox;

            if (comboBox != null)
            {
                _angularUnits = (AngularUnits)comboBox.SelectedIndex;
            }
        }

        #endregion


    }
}
