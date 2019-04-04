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
            this.mainChart = new LiveCharts.WinForms.CartesianChart();
            this.scrollerChart = new LiveCharts.WinForms.CartesianChart();
            this.bottomPanel = new DevExpress.XtraEditors.SidePanel();
            this.topPanel = new DevExpress.XtraEditors.SidePanel();
            this.bottomPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainChart
            // 
            this.mainChart.BackColor = System.Drawing.Color.White;
            this.mainChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainChart.Location = new System.Drawing.Point(0, 0);
            this.mainChart.Name = "mainChart";
            this.mainChart.Size = new System.Drawing.Size(995, 398);
            this.mainChart.TabIndex = 2;
            this.mainChart.Text = "cartesianChart1";
            // 
            // scrollerChart
            // 
            this.scrollerChart.BackColor = System.Drawing.Color.White;
            this.scrollerChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollerChart.Location = new System.Drawing.Point(0, 1);
            this.scrollerChart.Name = "scrollerChart";
            this.scrollerChart.Size = new System.Drawing.Size(995, 112);
            this.scrollerChart.TabIndex = 3;
            this.scrollerChart.Text = "cartesianChart2";
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.scrollerChart);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 398);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(995, 113);
            this.bottomPanel.TabIndex = 4;
            this.bottomPanel.Text = "sidePanel1";
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.mainChart);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(995, 398);
            this.topPanel.TabIndex = 5;
            this.topPanel.Text = "sidePanel2";
            // 
            // ScrollableChartUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.bottomPanel);
            this.Name = "ScrollableChartUserControl";
            this.Size = new System.Drawing.Size(995, 511);
            this.bottomPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart mainChart;
        private LiveCharts.WinForms.CartesianChart scrollerChart;
        private DevExpress.XtraEditors.SidePanel bottomPanel;
        private DevExpress.XtraEditors.SidePanel topPanel;
    }
}
