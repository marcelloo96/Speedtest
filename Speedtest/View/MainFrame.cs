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
        char[] charSeparators = new char[] { '\n' };
        //public Dictionary<string, Action> displayActions;
        public static string currentlyStaticArrived;

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
            numberOfPanels = numberOfChannelsElementValue;
            //displayActions = new Dictionary<string, Action> {
            //    {Strings.MeasureTab_MonitorDisplayMode, ()=>printAll() }
            //};
        }

        public void testConnect()
        {
            if (!String.IsNullOrWhiteSpace(selectedPortElementValue))
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

        private void connectButton_ItemClick(object sender, ItemClickEventArgs ea)
        {
            if (connectedState)
            {
                //Disconnecting
                contentPanel.Controls.Clear();
                mmw.deleteControls();
                mmw.Dispose();
                PortController.CloseSerialOnExit(serialPort);
                serialPort.Dispose();
                connectedState = false;
                measureControlPanelGroup.Enabled = false;
                
            }
            else {
                //Connecting
                if (String.IsNullOrWhiteSpace(selectedPortElementValue))
                {
                    MessageBox.Show(Strings.Global_Error_NoPortSelected);
                }
                else
                {
                    testConnect();
                }
                connectedState = true;
                isRunning = false;
                measureControlPanelGroup.Enabled = true;
            }
            
        }

        private void startStopButton_ItemClick(object sender, ItemClickEventArgs ea)
        {
            deltaTime = 1000 / samplingRateElementValue;
            if (isRunning)
            {
                isRunning = false;
                dc.Dispose();
                connectiongGroup.Enabled = true;
            }
            else
            {
                isRunning = true;
                if (serialPort == null)
                {
                    portController.CreatePort();

                }
                if (!serialPort.IsOpen)
                {
                    portController.OpenThePort();
                }
                dc = new DataCollector(serialPort, printTo);
                serialPort.DiscardInBuffer();
                connectiongGroup.Enabled = false;


            }



        }
        private void printTo(string currentlyArrived)
        {
            Debug.WriteLine(currentlyArrived);
            sendingData = currentlyArrived.Split(' ');
            gearedCharts.ForEach(p => p.viewModel.recivedChartValues.Clear());

            if (DisplayModeElementValue == Strings.MeasureTab_ChartDisplayMode)
            {
                ChartController.printChart(sendingData, numberOfPanels, this);
            }
            else if (DisplayModeElementValue == Strings.MeasureTab_MonitorDisplayMode) {
                ChartController.printChartMonitor(mmw.chartMonitor, sendingData);
            }

        }


    }

}
