namespace Speedtest.View.StatisticWindow
{
    partial class ScrollableChartUserControl
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
            this.scrollerChart = new LiveCharts.WinForms.CartesianChart();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // scrollerChart
            // 
            this.scrollerChart.BackColor = System.Drawing.Color.White;
            this.scrollerChart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.scrollerChart.Location = new System.Drawing.Point(0, 406);
            this.scrollerChart.Name = "scrollerChart";
            this.scrollerChart.Size = new System.Drawing.Size(920, 80);
            this.scrollerChart.TabIndex = 3;
            this.scrollerChart.Text = "cartesianChart2";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BackColor = System.Drawing.Color.White;
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Location = new System.Drawing.Point(0, 0);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(920, 486);
            this.cartesianChart1.TabIndex = 2;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // ScrollableChartUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scrollerChart);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "ScrollableChartUserControl";
            this.Size = new System.Drawing.Size(920, 486);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart scrollerChart;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
    }
}
