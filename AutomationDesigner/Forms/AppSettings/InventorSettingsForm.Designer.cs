
namespace AutomationDesigner.Forms.AppSettings
{
    partial class InventorSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.inventorSettingsControl1 = new AutomationDesigner.Controls.AppSettings.Inventor.InventorSettingsControl();
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(800, 450);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.inventorSettingsControl1;
            // 
            // InventorSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.elementHost1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InventorSettingsForm";
            this.ShowIcon = false;
            this.Text = "Inventor Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InventorSettingsForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.AppSettings.Inventor.InventorSettingsControl inventorSettingsControl1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
    }
}