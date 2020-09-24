using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using AutomationDesinger.Models;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.Controls;

namespace AutomationDesinger.Forms
{
    public partial class SettingsForm : SfForm
    {
        public ObservableCollection<FilePathContains> FilePathContains { get; set; }

        public SettingsForm()
        {
            InitializeComponent();

            Styling();

            Setup();

            SetupContextMenu();
        }

        private void Setup()
        {
            FilePathContains = new ObservableCollection<FilePathContains>();

            foreach (var s in Settings.Default.PathsToAvoid)
            {
                FilePathContains.Add(new FilePathContains { Name = s });
            }

            this.FilePathsToAvoidGrid.DataSource = FilePathContains;

            this.FilePathsToAvoidGrid.AddNewRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;


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
            this.Style.TitleBar.Font = this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Style.TitleBar.TextHorizontalAlignment = HorizontalAlignment.Center;
            this.Style.TitleBar.TextVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
        }

        private void SetupContextMenu()
        {
            FilePathsToAvoidGrid.RecordContextMenu = new ContextMenuStrip();

            OnDeleteClicked += DeleteRow;

            FilePathsToAvoidGrid.RecordContextMenu.Items.Add("Delete", null, OnDeleteClicked);
        }

        private void settingsOkbutton_Click(object sender, System.EventArgs e)
        {
            Settings.Default.PathsToAvoid.Clear();

            foreach (var c in FilePathContains)
            {
                Settings.Default.PathsToAvoid.Add(c.Name);
            }

            Settings.Default.Save();

            this.Close();
        }

        private EventHandler OnDeleteClicked;

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
    }
}
