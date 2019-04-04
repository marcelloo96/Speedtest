namespace Speedtest.View.StatisticWindow
{
    partial class HistogramChartUserControl
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
            this.mainChart = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // mainChart
            // 
            this.mainChart.BackColor = System.Drawing.Color.White;
            this.mainChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainChart.Location = new System.Drawing.Point(0, 0);
            this.mainChart.Name = "mainChart";
            this.mainChart.Size = new System.Drawing.Size(947, 469);
            this.mainChart.TabIndex = 3;
            this.mainChart.Text = "cartesianChart1";
            // 
            // HistogramChartUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainChart);
            this.Name = "HistogramChartUserControl";
            this.Size = new System.Drawing.Size(947, 469);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart mainChart;
    }
}
