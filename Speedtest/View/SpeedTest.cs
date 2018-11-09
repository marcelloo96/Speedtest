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
    public partial class SpeedTest : Form
    {
        public SpeedTestVm viewModel;
        public SerialPort serialPort = new SerialPort();
        public int numOfSeries { get { return (int)numberOfPorts.Value; } }        

        public SpeedTest()
        {
            InitializeComponent();
            spCombobox.Items.AddRange(SerialPort.GetPortNames());

            startButton.Enabled = false;
            stopButton.Enabled = false;
            clearButton.Enabled = false;
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
            foreach (var i in viewModel.listOfCharts) {
                i.Clear();
            }
        }

        private void refreshPortsList_Click(object sender, System.EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            spCombobox.Items.Clear();
            spCombobox.Items.AddRange(ports);
        }

        private void openButton_Click(object sender, System.EventArgs e)
        {
            cartesianChart1 = ChartController.SetDefaultChart(cartesianChart1, this);
            trackBarControl1.Value = viewModel.keepRecords;
            numberOfPorts.Enabled = false;
            openButton.Enabled = false;
            closeButton.Enabled = true;
            refreshButton.Enabled = false;
            startButton.Enabled = true;
            stopButton.Enabled = true;
            clearButton.Enabled = true;
            try
            {
                serialPort.PortName = spCombobox.Text;
                viewModel.serialPort = this.serialPort;
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            openButton.Enabled = true;
            closeButton.Enabled = false;
            startButton.Enabled = false;
            stopButton.Enabled = false;
            clearButton.Enabled = false;

            Thread CloseDown = new Thread(new ThreadStart(CloseSerialOnExit));
            CloseDown.Start();
        }
        private void CloseSerialOnExit()
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.DtrEnable = false;
                    serialPort.RtsEnable = false;
                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();
                    serialPort.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

        }

        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            totalPoints.Text = "Displayed points: " + trackBarControl1.Value;
            viewModel.keepRecords = trackBarControl1.Value;
        }
    }
}
