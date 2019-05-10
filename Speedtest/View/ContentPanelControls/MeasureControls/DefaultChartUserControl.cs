using Speedtest.Controller;
using Speedtest.Model;
using System.Windows.Forms;

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
            XYChart = ChartController.InitializeDefaultChart(XYChart, this);
        }
    }
}
