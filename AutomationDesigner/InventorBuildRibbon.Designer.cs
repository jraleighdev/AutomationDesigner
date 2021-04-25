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
            this.InventorCaptureDrawingData = this.Factory.CreateRibbonButton();
            this.copyGroup = this.Factory.CreateRibbonGroup();
            this.InventorGetRefButton = this.Factory.CreateRibbonButton();
            this.InventorCopyDocuments = this.Factory.CreateRibbonButton();
            this.settingsGroup = this.Factory.CreateRibbonGroup();
            this.InventorSettingsButton = this.Factory.CreateRibbonButton();
            this.solidWorksBuildTab = this.Factory.CreateRibbonTab();
            this.solidworksBuildGroup = this.Factory.CreateRibbonGroup();
            this.solidWorksBuildButton = this.Factory.CreateRibbonButton();
            this.solidWorksStopBuild = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.solidworksBuildTemplate = this.Factory.CreateRibbonButton();
            this.solidworksCaptureGroup = this.Factory.CreateRibbonGroup();
            this.solidworksCaptureButton = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.solidworksLoadRefDocs = this.Factory.CreateRibbonButton();
            this.solidWorksCopyButton = this.Factory.CreateRibbonButton();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.solidworksSettings = this.Factory.CreateRibbonButton();
            this.buildTab.SuspendLayout();
            this.group1.SuspendLayout();
            this.editGroup.SuspendLayout();
            this.inventorDataCapture.SuspendLayout();
            this.copyGroup.SuspendLayout();
            this.settingsGroup.SuspendLayout();
            this.solidWorksBuildTab.SuspendLayout();
            this.solidworksBuildGroup.SuspendLayout();
            this.group2.SuspendLayout();
            this.solidworksCaptureGroup.SuspendLayout();
            this.group3.SuspendLayout();
            this.group4.SuspendLayout();
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
            this.inventorDataCapture.Items.Add(this.InventorCaptureDrawingData);
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
            // InventorCaptureDrawingData
            // 
            this.InventorCaptureDrawingData.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.InventorCaptureDrawingData.Label = "Capture Drawing Data";
            this.InventorCaptureDrawingData.Name = "InventorCaptureDrawingData";
            this.InventorCaptureDrawingData.ShowImage = true;
            this.InventorCaptureDrawingData.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.InventorCaptureDrawingData_Click);
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
            // solidWorksBuildTab
            // 
            this.solidWorksBuildTab.Groups.Add(this.solidworksBuildGroup);
            this.solidWorksBuildTab.Groups.Add(this.group2);
            this.solidWorksBuildTab.Groups.Add(this.solidworksCaptureGroup);
            this.solidWorksBuildTab.Groups.Add(this.group3);
            this.solidWorksBuildTab.Groups.Add(this.group4);
            this.solidWorksBuildTab.Label = "Solidworks Build";
            this.solidWorksBuildTab.Name = "solidWorksBuildTab";
            // 
            // solidworksBuildGroup
            // 
            this.solidworksBuildGroup.Items.Add(this.solidWorksBuildButton);
            this.solidworksBuildGroup.Items.Add(this.solidWorksStopBuild);
            this.solidworksBuildGroup.Label = "Build";
            this.solidworksBuildGroup.Name = "solidworksBuildGroup";
            // 
            // solidWorksBuildButton
            // 
            this.solidWorksBuildButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.solidWorksBuildButton.Image = ((System.Drawing.Image)(resources.GetObject("solidWorksBuildButton.Image")));
            this.solidWorksBuildButton.Label = "Build";
            this.solidWorksBuildButton.Name = "solidWorksBuildButton";
            this.solidWorksBuildButton.ShowImage = true;
            this.solidWorksBuildButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.solidWorksBuildButton_Click);
            // 
            // solidWorksStopBuild
            // 
            this.solidWorksStopBuild.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.solidWorksStopBuild.Image = ((System.Drawing.Image)(resources.GetObject("solidWorksStopBuild.Image")));
            this.solidWorksStopBuild.Label = "Stop";
            this.solidWorksStopBuild.Name = "solidWorksStopBuild";
            this.solidWorksStopBuild.ShowImage = true;
            this.solidWorksStopBuild.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.solidWorksStopBuild_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.solidworksBuildTemplate);
            this.group2.Label = "Generate";
            this.group2.Name = "group2";
            // 
            // solidworksBuildTemplate
            // 
            this.solidworksBuildTemplate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.solidworksBuildTemplate.Image = ((System.Drawing.Image)(resources.GetObject("solidworksBuildTemplate.Image")));
            this.solidworksBuildTemplate.Label = "Build Template";
            this.solidworksBuildTemplate.Name = "solidworksBuildTemplate";
            this.solidworksBuildTemplate.ShowImage = true;
            this.solidworksBuildTemplate.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.solidworksBuildTemplate_Click);
            // 
            // solidworksCaptureGroup
            // 
            this.solidworksCaptureGroup.Items.Add(this.solidworksCaptureButton);
            this.solidworksCaptureGroup.Label = "Capture";
            this.solidworksCaptureGroup.Name = "solidworksCaptureGroup";
            // 
            // solidworksCaptureButton
            // 
            this.solidworksCaptureButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.solidworksCaptureButton.Image = ((System.Drawing.Image)(resources.GetObject("solidworksCaptureButton.Image")));
            this.solidworksCaptureButton.Label = "Capture Model Data";
            this.solidworksCaptureButton.Name = "solidworksCaptureButton";
            this.solidworksCaptureButton.ShowImage = true;
            this.solidworksCaptureButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.solidworksCaptureButton_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.solidworksLoadRefDocs);
            this.group3.Items.Add(this.solidWorksCopyButton);
            this.group3.Label = "Copy Tools";
            this.group3.Name = "group3";
            // 
            // solidworksLoadRefDocs
            // 
            this.solidworksLoadRefDocs.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.solidworksLoadRefDocs.Image = ((System.Drawing.Image)(resources.GetObject("solidworksLoadRefDocs.Image")));
            this.solidworksLoadRefDocs.Label = "Load Ref Documents";
            this.solidworksLoadRefDocs.Name = "solidworksLoadRefDocs";
            this.solidworksLoadRefDocs.ShowImage = true;
            this.solidworksLoadRefDocs.SuperTip = "Loads the referenced documents to a new sheet.";
            this.solidworksLoadRefDocs.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.solidworksLoadRefDocs_Click);
            // 
            // solidWorksCopyButton
            // 
            this.solidWorksCopyButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.solidWorksCopyButton.Image = ((System.Drawing.Image)(resources.GetObject("solidWorksCopyButton.Image")));
            this.solidWorksCopyButton.Label = "Copy";
            this.solidWorksCopyButton.Name = "solidWorksCopyButton";
            this.solidWorksCopyButton.ShowImage = true;
            this.solidWorksCopyButton.SuperTip = "Copies the list of documents";
            this.solidWorksCopyButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.solidWorksCopyButton_Click);
            // 
            // group4
            // 
            this.group4.Items.Add(this.solidworksSettings);
            this.group4.Label = "Settings";
            this.group4.Name = "group4";
            // 
            // solidworksSettings
            // 
            this.solidworksSettings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.solidworksSettings.Image = ((System.Drawing.Image)(resources.GetObject("solidworksSettings.Image")));
            this.solidworksSettings.Label = "Settings";
            this.solidworksSettings.Name = "solidworksSettings";
            this.solidworksSettings.ShowImage = true;
            this.solidworksSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.solidworksSettings_Click);
            // 
            // InventorBuildRibbon
            // 
            this.Name = "InventorBuildRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.buildTab);
            this.Tabs.Add(this.solidWorksBuildTab);
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
            this.solidWorksBuildTab.ResumeLayout(false);
            this.solidWorksBuildTab.PerformLayout();
            this.solidworksBuildGroup.ResumeLayout(false);
            this.solidworksBuildGroup.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.solidworksCaptureGroup.ResumeLayout(false);
            this.solidworksCaptureGroup.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
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
        internal Microsoft.Office.Tools.Ribbon.RibbonTab solidWorksBuildTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup solidworksBuildGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton solidWorksBuildButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton solidWorksStopBuild;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton solidworksBuildTemplate;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton solidworksLoadRefDocs;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton solidWorksCopyButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton solidworksSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup solidworksCaptureGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton solidworksCaptureButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup inventorDataCapture;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton captureInventorModelData;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton InventorCaptureDrawingData;
    }

    partial class ThisRibbonCollection
    {
        internal InventorBuildRibbon Ribbon1
        {
            get { return this.GetRibbon<InventorBuildRibbon>(); }
        }
    }
}
