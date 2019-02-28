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
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.gearedChartUserControl = new Speedtest.View.MeasureWindow.GearedChartUserControl();
            this.chartSettingsUserControl = new Speedtest.View.MeasureWindow.ChartSettingsUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.gearedChartUserControl);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.chartSettingsUserControl);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(976, 461);
            this.splitContainerControl.SplitterPosition = 695;
            this.splitContainerControl.TabIndex = 0;
            // 
            // gearedChartUserControl
            // 
            this.gearedChartUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gearedChartUserControl.Location = new System.Drawing.Point(0, 0);
            this.gearedChartUserControl.Name = "gearedChartUserControl";
            this.gearedChartUserControl.Size = new System.Drawing.Size(695, 461);
            this.gearedChartUserControl.TabIndex = 0;
            // 
            // chartSettingsUserControl
            // 
            this.chartSettingsUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartSettingsUserControl.Location = new System.Drawing.Point(0, 0);
            this.chartSettingsUserControl.Name = "chartSettingsUserControl";
            this.chartSettingsUserControl.Size = new System.Drawing.Size(269, 461);
            this.chartSettingsUserControl.TabIndex = 0;
            // 
            // MainMeasureWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl);
            this.Name = "MainMeasureWindow";
            this.Size = new System.Drawing.Size(976, 461);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainerControl splitContainerControl;
        private GearedChartUserControl gearedChartUserControl;
        private ChartSettingsUserControl chartSettingsUserControl;
    }
}
