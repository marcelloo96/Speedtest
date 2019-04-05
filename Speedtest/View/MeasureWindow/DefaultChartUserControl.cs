using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Speedtest.Controller;
using Speedtest.Model;

namespace Speedtest.View.MeasureWindow
{
    public partial class DefaultChartUserControl : UserControl
    {
        public DefaultChartViewModel viewModel { get; set; }
        /// <summary>
        /// Constructor of MMW change the values below
        /// </summary>
        public int keepRecords { get; set; }
        public double deltaT { get; set; }
        public DefaultChartUserControl(int keepRecords, double deltaT)
        {
            this.keepRecords = keepRecords;
            this.deltaT = deltaT;

            InitializeComponent();
            XYChart = ChartController.InitializeXYChart(XYChart, this);
        }
    }
}
