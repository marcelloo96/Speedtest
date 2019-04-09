namespace Speedtest.View.MeasureWindow
{
    partial class DefaultChartUserControl
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
            this.XYChart = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // XYChart
            // 
            this.XYChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XYChart.Location = new System.Drawing.Point(0, 0);
            this.XYChart.Name = "XYChart";
            this.XYChart.Size = new System.Drawing.Size(829, 429);
            this.XYChart.TabIndex = 0;
            this.XYChart.Text = "cartesianChart1";
            // 
            // XYChartUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.XYChart);
            this.Name = "XYChartUserControl";
            this.Size = new System.Drawing.Size(829, 429);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public LiveCharts.WinForms.CartesianChart XYChart;
    }
}
