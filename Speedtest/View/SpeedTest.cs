using System.Windows.Forms;
using LiveCharts.Geared;
using System.IO.Ports;
using System;
using System.Threading;
using LiveCharts;
using LiveCharts.WinForms;
using Speedtest.Controller;

namespace Speedtest
{
    public partial class SpeedTest : UserControl
    {
        public SpeedTestVm viewModel;
        public SerialPort serialPort;
        public Int32 numOfSeries;


        public SpeedTest() {
            InitializeComponent();
        }
        public SpeedTest(SerialPort serialPort, int numOfSeries)
        {
            InitializeComponent();

            this.serialPort = serialPort;
            this.numOfSeries = numOfSeries;
            cartesianChart1 = ChartController.SetDefaultChart(cartesianChart1, this);

        }
    }
}
