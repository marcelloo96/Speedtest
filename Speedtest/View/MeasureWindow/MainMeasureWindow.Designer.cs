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
            this.gearedChartUserControl = new Speedtest.View.MeasureWindow.GearedChartUserControl();
            this.SuspendLayout();
            // 
            // gearedChartUserControl
            // 
            this.gearedChartUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gearedChartUserControl.Location = new System.Drawing.Point(0, 0);
            this.gearedChartUserControl.Margin = new System.Windows.Forms.Padding(0);
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
            this.ResumeLayout(false);

        }

        #endregion
        private GearedChartUserControl gearedChartUserControl;
    }
}
