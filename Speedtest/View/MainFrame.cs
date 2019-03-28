using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using Speedtest.Controller;
using System;
using System.IO.Ports;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Docking;
using System.Collections.Generic;
using Speedtest.View.MeasureWindow;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedtest
{
    public partial class MainFrame : RibbonForm
    {
        #region fields

        //public SerialPort serialPort;
        public SpeedTest gearedChart;
        public List<SpeedTest> gearedCharts;
        public PortController portController;
        public MainMeasureWindow mmw;
        public bool connectedState { get; set; }
        public bool isRunning { get; set; }
        public double tryparseTmp;
        public readonly bool firstConnect = true;
        public List<string[]> myPortBuffer;
        public Stopwatch timer;
        public Int32 deltaTime;
        public string[] sendingData;
        int incomingData;
        int numberOfPanels;
        DataCollector dc;
        private string comingDataBuffer;
        char[] charSeparators = new char[] { '\n' };
        #endregion

        public MainFrame()
        {
            InitializeComponent();
            MeasureTabController.FillEditors(this);
            PortOptionsTabController.FillEditors(this);
            MeasureTabController.SetInitialState(this);
            portController = new PortController(this);
            gearedCharts = new List<SpeedTest>();
            myPortBuffer = new List<string[]>();
            timer = new Stopwatch();
            incomingData = Int32.Parse(NumberOfIncomingDataElement.EditValue.ToString());
            numberOfPanels = numberOfChannelsFromElementValue;

        }

        private void createCharts()
        {
            for (int i = 0; i < (int)channelsElement.EditValue; i++)
            {
                gearedChart = new SpeedTest(serialPort, (int)channelsElement.EditValue)
                {
                    Dock = DockStyle.Fill
                };
                gearedCharts.Add(gearedChart);
            }
        }
        private void connectButton_ItemClick(object sender, ItemClickEventArgs ea)
        {
            if (String.IsNullOrWhiteSpace((string)this.selectedPortElement.EditValue))
            {
                MessageBox.Show(Strings.Global_Error_NoPortSelected);
            }
            else
            {
                testConnect();
            }
        }

        public void testConnect()
        {
            if (!String.IsNullOrWhiteSpace((string)this.selectedPortElement.EditValue))
            {
                try
                {
                    MeasureTabController.ConnectionManager(this);

                    if (connectedState)
                    {
                        mmw = new MainMeasureWindow(this);
                        mmw.Dock = DockStyle.Fill;
                        contentPanel.Controls.Add(mmw);
                    }
                    else
                    {

                        contentPanel.Controls.Clear();
                        mmw.deleteControls();

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

        }

        private void startStopButton_ItemClick(object sender, ItemClickEventArgs ea)
        {
            deltaTime = 1000 / Int32.Parse(samplingRateElement.EditValue.ToString());
            if (isRunning)
            {
                isRunning = false;
                
                connectiongGroup.Enabled = false;
            }
            else
            {
                serialPort.DiscardInBuffer();
                isRunning = true;
                dc = new DataCollector(serialPort,printasd);
                connectiongGroup.Enabled = true;
            }

        }

        Action<string> printasd = delegate (string a)
        {
            Debug.WriteLine(a);
        };

        private void printAll(string currentlyArrived)
        {

            {
                sendingData = currentlyArrived.Split(' ');
                gearedCharts.ForEach(p => p.viewModel.recivedChartValues.Clear());
                ChartController.printChartMonitor(mmw.chartMonitor, sendingData);
                ChartController.printChart(sendingData, numberOfPanels, this);

            }
        }
    }
}
