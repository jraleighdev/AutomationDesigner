namespace AutomationDesigner
{
    partial class InventorBuildRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public InventorBuildRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventorBuildRibbon));
            this.buildTab = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.BuildButton = this.Factory.CreateRibbonButton();
            this.InventorStopButton = this.Factory.CreateRibbonButton();
            this.editGroup = this.Factory.CreateRibbonGroup();
            this.InventorBuildTemplate = this.Factory.CreateRibbonButton();
            this.inventorDataCapture = this.Factory.CreateRibbonGroup();
            this.captureInventorModelData = this.Factory.CreateRibbonButton();
            this.copyGroup = this.Factory.CreateRibbonGroup();
            this.InventorGetRefButton = this.Factory.CreateRibbonButton();
            this.InventorCopyDocuments = this.Factory.CreateRibbonButton();
            this.settingsGroup = this.Factory.CreateRibbonGroup();
            this.InventorSettingsButton = this.Factory.CreateRibbonButton();
            this.solidworksBuildTemplate = this.Factory.CreateRibbonButton();
            this.solidworksCaptureButton = this.Factory.CreateRibbonButton();
            this.solidworksLoadRefDocs = this.Factory.CreateRibbonButton();
            this.solidWorksCopyButton = this.Factory.CreateRibbonButton();
            this.solidworksSettings = this.Factory.CreateRibbonButton();
            this.buildTab.SuspendLayout();
            this.group1.SuspendLayout();
            this.editGroup.SuspendLayout();
            this.inventorDataCapture.SuspendLayout();
            this.copyGroup.SuspendLayout();
            this.settingsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // buildTab
            // 
            this.buildTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.buildTab.Groups.Add(this.group1);
            this.buildTab.Groups.Add(this.editGroup);
            this.buildTab.Groups.Add(this.inventorDataCapture);
            this.buildTab.Groups.Add(this.copyGroup);
            this.buildTab.Groups.Add(this.settingsGroup);
            this.buildTab.Label = "Inventor Build";
            this.buildTab.Name = "buildTab";
            // 
            // group1
            // 
            this.group1.Items.Add(this.BuildButton);
            this.group1.Items.Add(this.InventorStopButton);
            this.group1.Label = "Build";
            this.group1.Name = "group1";
            // 
            // BuildButton
            // 
            this.BuildButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.BuildButton.Image = ((System.Drawing.Image)(resources.GetObject("BuildButton.Image")));
            this.BuildButton.Label = "Build";
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.ShowImage = true;
            this.BuildButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.InventorBuildButton_Click);
            // 
            // InventorStopButton
            // 
            this.InventorStopButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.InventorStopButton.Image = ((System.Drawing.Image)(resources.GetObject("InventorStopButton.Image")));
            this.InventorStopButton.Label = "Stop";
            this.InventorStopButton.Name = "InventorStopButton";
            this.InventorStopButton.ShowImage = true;
            // 
            // editGroup
            // 
            this.editGroup.Items.Add(this.InventorBuildTemplate);
            this.editGroup.Label = "Generate";
            this.editGroup.Name = "editGroup";
            // 
            // InventorBuildTemplate
            // 
            this.InventorBuildTemplate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.InventorBuildTemplate.Image = ((System.Drawing.Image)(resources.GetObject("InventorBuildTemplate.Image")));
            this.InventorBuildTemplate.Label = "Build Template";
            this.InventorBuildTemplate.Name = "InventorBuildTemplate";
            this.InventorBuildTemplate.ShowImage = true;
            this.InventorBuildTemplate.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.InventorGenTemplateButton_Click);
            // 
            // inventorDataCapture
            // 
            this.inventorDataCapture.Items.Add(this.captureInventorModelData);
            this.inventorDataCapture.Label = "Capture";
            this.inventorDataCapture.Name = "inventorDataCapture";
            // 
            // captureInventorModelData
            // 
            this.captureInventorModelData.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.captureInventorModelData.Image = ((System.Drawing.Image)(resources.GetObject("captureInventorModelData.Image")));
            this.captureInventorModelData.Label = "Capture Model Data";
            this.captureInventorModelData.Name = "captureInventorModelData";
            this.captureInventorModelData.ShowImage = true;
            this.captureInventorModelData.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.captureInventorModelData_Click);
            // 
            // copyGroup
            // 
            this.copyGroup.Items.Add(this.InventorGetRefButton);
            this.copyGroup.Items.Add(this.InventorCopyDocuments);
            this.copyGroup.Label = "Copy Tools";
            this.copyGroup.Name = "copyGroup";
            // 
            // InventorGetRefButton
            // 
            this.InventorGetRefButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.InventorGetRefButton.Image = ((System.Drawing.Image)(resources.GetObject("InventorGetRefButton.Image")));
            this.InventorGetRefButton.Label = "Load Ref Documents";
            this.InventorGetRefButton.Name = "InventorGetRefButton";
            this.InventorGetRefButton.ShowImage = true;
            this.InventorGetRefButton.SuperTip = "Loads the referenced documents to a new sheet.";
            this.InventorGetRefButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.InventorGetRefButton_Click);
            // 
            // InventorCopyDocuments
            // 
            this.InventorCopyDocuments.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.InventorCopyDocuments.Image = ((System.Drawing.Image)(resources.GetObject("InventorCopyDocuments.Image")));
            this.InventorCopyDocuments.Label = "Copy";
            this.InventorCopyDocuments.Name = "InventorCopyDocuments";
            this.InventorCopyDocuments.ShowImage = true;
            this.InventorCopyDocuments.SuperTip = "Copies the list of documents";
            this.InventorCopyDocuments.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.InventorcopyDocuments_Click);
            // 
            // settingsGroup
            // 
            this.settingsGroup.Items.Add(this.InventorSettingsButton);
            this.settingsGroup.Label = "Settings";
            this.settingsGroup.Name = "settingsGroup";
            // 
            // InventorSettingsButton
            // 
            this.InventorSettingsButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.InventorSettingsButton.Image = ((System.Drawing.Image)(resources.GetObject("InventorSettingsButton.Image")));
            this.InventorSettingsButton.Label = "Settings";
            this.InventorSettingsButton.Name = "InventorSettingsButton";
            this.InventorSettingsButton.ShowImage = true;
            this.InventorSettingsButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.InventorSettingsButton_Click);
            // 
            // solidworksBuildTemplate
            // 
            this.solidworksBuildTemplate.Label = "";
            this.solidworksBuildTemplate.Name = "solidworksBuildTemplate";
            // 
            // solidworksCaptureButton
            // 
            this.solidworksCaptureButton.Label = "";
            this.solidworksCaptureButton.Name = "solidworksCaptureButton";
            // 
            // solidworksLoadRefDocs
            // 
            this.solidworksLoadRefDocs.Label = "";
            this.solidworksLoadRefDocs.Name = "solidworksLoadRefDocs";
            // 
            // solidWorksCopyButton
            // 
            this.solidWorksCopyButton.Label = "";
            this.solidWorksCopyButton.Name = "solidWorksCopyButton";
            // 
            // solidworksSettings
            // 
            this.solidworksSettings.Label = "";
            this.solidworksSettings.Name = "solidworksSettings";
            // 
            // InventorBuildRibbon
            // 
            this.Name = "InventorBuildRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.buildTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.buildTab.ResumeLayout(false);
            this.buildTab.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.editGroup.ResumeLayout(false);
            this.editGroup.PerformLayout();
            this.inventorDataCapture.ResumeLayout(false);
            this.inventorDataCapture.PerformLayout();
            this.copyGroup.ResumeLayout(false);
            this.copyGroup.PerformLayout();
            this.settingsGroup.ResumeLayout(false);
            this.settingsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab buildTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BuildButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup editGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton InventorBuildTemplate;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton InventorStopButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup copyGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton InventorGetRefButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton InventorCopyDocuments;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup settingsGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton InventorSettingsButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton solidworksBuildTemplate;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton solidworksLoadRefDocs;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton solidWorksCopyButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton solidworksSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton solidworksCaptureButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup inventorDataCapture;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton captureInventorModelData;
    }

    partial class ThisRibbonCollection
    {
        internal InventorBuildRibbon Ribbon1
        {
            get { return this.GetRibbon<InventorBuildRibbon>(); }
        }
    }
}
