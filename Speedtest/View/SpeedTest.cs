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


        public SpeedTest(SerialPort serialPort ,int numOfSeries)
        {
            InitializeComponent();

            this.serialPort = serialPort;

            this.numOfSeries = numOfSeries;


            cartesianChart1 = ChartController.SetDefaultChart(cartesianChart1, this);

        }


        private void StartOnClick(object sender, System.EventArgs e)
        {
            viewModel.IsReading = true;
            viewModel.Read();
        }

        private void StopOnClik(object sender, System.EventArgs e)
        {
            viewModel.Stop();
        }

        private void ClearOnClick(object sender, System.EventArgs e)
        {
            foreach (var i in viewModel.listOfCharts)
            {
                i.Clear();
            }
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            (new Thread(() =>
            {
                //CloseSerialOnExit();
            })).Start();

            //Thread CloseDown = new Thread(new ThreadStart(CloseSerialOnExit));
            //CloseDown.Start();
        }


        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            //totalPoints.Text = "Displayed points: " + trackBarControl1.Value;
            //viewModel.keepRecords = trackBarControl1.Value;
        }

        public void externalStart()
        {
            if (viewModel.IsReading)
            {
                //Stop
                viewModel.Stop();
                //(new Thread(() =>
                //{
                //    CloseSerialOnExit();
                //})).Start();
            }
            else
            {
                //Start


                viewModel.IsReading = true;
                viewModel.Read();

            }

        }
    }
}
