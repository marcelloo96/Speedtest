using DevExpress.XtraEditors;

namespace Speedtest.View.MeasureWindow
{
    partial class MainMeasureWindow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager();
            this.gearedChartUserControl = new Speedtest.View.MeasureWindow.GearedChartUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager
            // 
            this.dockManager.Form = this;
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // gearedChartUserControl
            // 
            this.gearedChartUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gearedChartUserControl.Location = new System.Drawing.Point(0, 0);
            this.gearedChartUserControl.Name = "gearedChartUserControl";
            this.gearedChartUserControl.Size = new System.Drawing.Size(976, 461);
            this.gearedChartUserControl.TabIndex = 0;
            // 
            // MainMeasureWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gearedChartUserControl);
            this.Name = "MainMeasureWindow";
            this.Size = new System.Drawing.Size(976, 461);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private GearedChartUserControl gearedChartUserControl;
    }
}
