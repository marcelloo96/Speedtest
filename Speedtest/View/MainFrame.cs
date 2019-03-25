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

namespace Speedtest
{
    public partial class MainFrame : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region fields
        #region ComboBoxes
        public RepositoryItemComboBox SelectedPortRepositoryItemComboBox { get { return selectedPortRepositoryItemComboBox; } }
        public RepositoryItemComboBox BaudRateRepositoryItemComboBox { get { return baudRateRepositoryItemComboBox; } }
        public RepositoryItemComboBox NumberOfChannelsRepositoryItemComboBox { get { return numberOfChannelsRepositoryItemComboBox; } }
        public RepositoryItemComboBox DisplayModeRepositoryItemComboBox { get { return displayModeRepositoryItemComboBox; } }
        public RepositoryItemComboBox DataBitsReporitotyItemComboBox { get { return dataBitsReporitotyItemComboBox; } }
        public RepositoryItemComboBox ParityRepositoryItemComboBox { get { return parityRepositoryItemComboBox; } }
        public RepositoryItemComboBox StopBitRepositoryItemComboBox { get { return stopBitRepositoryItemComboBox; } }
        public RepositoryItemComboBox ReadBufferSizeRepositoryItemComboBox { get { return readBufferSizeRepositoryItemComboBox; } }
        public RepositoryItemComboBox WriteBufferSizeRepositoryItemComboBox { get { return writeBufferSizeRepositoryItemComboBox; } }
        public RepositoryItemComboBox RtsEnableRepositoryItemComboBox { get { return rtsEnableRepositoryItemComboBox; } }
        public RepositoryItemComboBox DtrEnableRepositoryItemComboBox { get { return dtrEnableRepositoryItemComboBox; } }
        public RepositoryItemComboBox HandShakeRepositoryItemComboBox { get { return handShakeRepositoryItemComboBox; } }
        public RepositoryItemTextEdit DelimeterRepositoryItemTextBox { get { return delimeterRepositoryItemTextBox; } }
        public RepositoryItemTextEdit NumberOfIncomingDataRepositoryItemTextBox { get { return numberOfIncomingDataRepositoryItemTextBox; } }
        public RepositoryItemTextEdit KeepRecordsRepositoryItemTextEdit { get { return keepRecordsRepositoryItemTextBox; } }
        #endregion
        #region Elements
        public BarEditItem DisplayModeElement { get { return displayModeElement; } }
        public int BaudRateElement {
            get { return (int)baudRateElement.EditValue; }
            set { baudRateElement.EditValue = value; }
        }
        public BarEditItem ChannelsElement { get { return channelsElement; } }
        public BarEditItem SelectedPortElement { get { return selectedPortElement; } }
        public BarEditItem DataBitsElement { get { return dataBitsElement; } }
        public BarEditItem ParityElement { get { return parityElement; } }
        public BarEditItem StopBitElement { get { return stopBitElement; } }
        public BarEditItem RtsEnableElement { get { return rtsEnableElement; } }
        public BarEditItem DtrEnableElement { get { return dtrEnableElement; } }
        public BarEditItem HandShakeElement { get { return handShakeElement; } }
        public BarEditItem ReadBufferSizeElement { get { return readBufferSizeElement; } }
        public BarEditItem WriteBufferSizeElement { get { return writeBufferSizeElement; } }
        public BarEditItem DelimeterElement { get { return delimeterElement; } }
        public BarEditItem SamplingRateElement { get { return samplingRateElement; } }
        public BarEditItem NumberOfIncomingDataElement { get { return numberOfIncomingDataElement; } }
        public BarEditItem KeepRecordsElement { get { return keepRecordsElement; } }

        #endregion
        #region Groups
        public RibbonPageGroup PortBasicsGroup { get { return portBasicsGroup; } }
        public RibbonPageGroup PortAdvancedsGroup { get { return portAdvancedsGroup; } }
        public RibbonPageGroup MeasurePortBasicGroup { get { return measurePortBasicGroup; } }
        #endregion
        #region Buttons
        public BarButtonItem ConnectButton { get { return connectButton; } }
        public BarButtonItem StartStopButton { get { return startStopButton; } }
        #endregion
        #region Labels
        public BarStaticItem IsPortConnectedStatusBarLabel { get { return portStatusLabel; } set { portStatusLabel = value; } }
        #endregion
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
        //List<byte> Data = new List<byte>();
        //private const int SizeOfMeasurement = 4;
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
            numberOfPanels = (int)ChannelsElement.EditValue;

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
                //serialPort.DataReceived -= portController.dataFlow;
                isRunning = false;
                connectiongGroup.Enabled = false;
            }
            else
            {
                serialPort.DiscardInBuffer();
                //serialPort.DataReceived += portController.dataFlow;
                isRunning = true;
                //(new Thread(() => {
                //    portController.dataflowExtra();
                //})).Start();

                connectiongGroup.Enabled = true;
                //    new Thread(() =>
                //    {
                //        while (isRunning && serialPort.IsOpen)
                //        {
                //            string myBuffer = String.Empty;
                //            if (serialPort.BytesToRead != 0)
                //            {

                //                var a = serialPort.ReadExisting();
                //                if (!a.Contains("\n"))
                //                {
                //                    myBuffer = a;

                //                }
                //                else
                //                {
                //                    Debug.WriteLine(myBuffer + a);
                //                    myBuffer = String.Empty;
                //                }


                //            }


                //        }

                //    }).Start();
                //}

                //(new Thread(() =>
                //{
                //    while (isRunning)
                //    {
                //        timer.Start();
                //        //ellapsedMilliseconds < deltatime

                //        if (timer.ElapsedMilliseconds < deltaTime)
                //        {
                //            //wait
                //        }
                //        else if (timer.ElapsedMilliseconds == deltaTime)
                //        {
                //            var a = myPortBuffer;
                //            Debug.WriteLine(a.Count);

                //            if (a.Count == 0)
                //            {
                //                sendingData = null;
                //            }
                //            else
                //            {
                //                foreach (var i in a)
                //                {
                //                    if (i.Length == incomingData)
                //                    {
                //                        sendingData = i;
                //                        break;
                //                    }
                //                }
                //            }

                //            gearedCharts.ForEach(p => p.viewModel.recivedChartValues.Clear());
                //            ChartController.printChartMonitor(mmw.chartMonitor, sendingData);
                //            ChartController.printChart(sendingData, numberOfPanels, this);
                //            myPortBuffer.Clear();
                //        }
                //        else
                //        {
                //            timer.Reset();

                //        }

                //    }
                //})).Start();
            }

        }

        private void selectedPortRepositoryItemComboBox_DoubleClick(object sender, EventArgs e)
        {
            SelectedPortRepositoryItemComboBox.Items.Clear();
            SelectedPortRepositoryItemComboBox.Items.AddRange(SerialPort.GetPortNames());

        }
        private void baudRateElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.BaudRate = (int)baudRateElement.EditValue;
            }
        }

        private void dataBitsElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.DataBits = (int)dataBitsElement.EditValue;
            }
        }

        private void parityElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.Parity = (Parity)parityElement.EditValue;
            }
        }

        private void stopBitElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.StopBits = (StopBits)stopBitElement.EditValue;
            }
        }

        private void rtsEnableElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.RtsEnable = (bool)rtsEnableElement.EditValue;
            }
        }

        private void dtrEnableElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.DtrEnable = (bool)dtrEnableElement.EditValue;
            }
        }

        private void handShakeElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.Handshake = (Handshake)handShakeElement.EditValue;
            }
        }

        private void writeBufferSizeElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.WriteBufferSize = (int)writeBufferSizeElement.EditValue;
            }
        }

        private void readBufferSizeElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.ReadBufferSize = (int)((double)readBufferSizeElement.EditValue);
            }
        }

        private void channelsElement_EditValueChanged(object sender, EventArgs e)
        {
            numberOfPanels = Int32.Parse(channelsElement.EditValue.ToString());
        }

        private void delimeterElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                if ((string)delimeterElement.EditValue == "" || (string)delimeterElement.EditValue == PortOptionsTabController.defaultDelimeter)
                {
                    serialPort.NewLine = "\n";
                }
                //TODO különböző delimetereket tudjon megkülönböztetni

                if ((string)delimeterElement.EditValue == "")
                {
                    DelimeterElement.EditValue = PortOptionsTabController.defaultDelimeter;
                }

            }
        }

        private void selectedPortElement_EditValueChanged(object sender, EventArgs e)
        {
            testConnect();
        }

        private void MainFrame_Resize(object sender, EventArgs e)
        {
            if ((this.WindowState == FormWindowState.Maximized || this.WindowState == FormWindowState.Minimized) && mmw != null)
            {

                mmw.resizeControls(contentPanel.Height, contentPanel.Width);

            }
            else if (mmw != null)
            {
                mmw.resizeControls(contentPanel.Height, contentPanel.Width);
            }

        }

        private void samplingRateElement_EditValueChanged(object sender, EventArgs e)
        {
            //Hz given, and we need millisec
            //so 1/f*1000 -> 1000/f
            if (portController != null)
            {
                portController.deltaTime = 1000 / Int32.Parse((string)samplingRateElement.EditValue);
                deltaTime = 1000 / Int32.Parse((string)samplingRateElement.EditValue);
            }
        }

        private void displayModeElement_EditValueChanged(object sender, EventArgs e)
        {
            string editValue = (string)displayModeElement.EditValue;

            if (mmw != null)
            {
                if (editValue == Strings.MeasureTab_ChartDisplayMode)
                {
                    mmw.chartMonitor.SendToBack();
                }
                else if (editValue == Strings.MeasureTab_MonitorDisplayMode)
                {
                    mmw.chartMonitor.BringToFront();
                }
            }

        }

        private void numberOfIncomingDataElement_EditValueChanged(object sender, EventArgs e)
        {
            if (portController != null)
            {
                portController.numberOfIncomingData = Int32.Parse((string)NumberOfIncomingDataElement.EditValue);
            }
        }

        private void keepRecordsElement_EditValueChanged(object sender, EventArgs e)
        {
            if (keepRecordsElement.EditValue != null)
            {
                var editvalue = Int32.Parse(keepRecordsElement.EditValue.ToString());
                if (editvalue < 1)
                {
                    editvalue = 1;
                }
                else if (editvalue > 1000)
                {
                    editvalue = 1000;
                }
                keepRecordsElement.EditValue = editvalue;
                if (mmw != null)
                {
                    foreach (var i in mmw.gearedCharts)
                    {
                        i.viewModel.keepRecords = editvalue;
                    }
                }
            }




        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (isRunning) {
                while (serialPort.BytesToRead > 0)
                {
                    var count = serialPort.BytesToRead;
                    var bytes = new byte[count];
                    serialPort.Read(bytes, 0, count);
                    AddBytes(Encoding.UTF8.GetString(bytes));
                }
            }
        }

        private void AddBytes(string arrivedString)
        {
            comingDataBuffer += arrivedString;

            var SampleList = comingDataBuffer.Split('\n').Where(p=>p!="\r" && p!=String.Empty ).ToList();

            comingDataBuffer = String.Join("", SampleList);
            for (int i = 0; i < SampleList.Count; i++) {
                if (SampleList[i].Contains("\r"))
                {
                    comingDataBuffer=comingDataBuffer.Remove(0, SampleList[i].Length);
                    Debug.WriteLine(SampleList[i]);
                }
                else {
                    break;
                }
            }

           
        }

        private void printAll(List<byte> measurementData) {
            gearedCharts.ForEach(p => p.viewModel.recivedChartValues.Clear());
            ChartController.printChartMonitor(mmw.chartMonitor, sendingData);
            ChartController.printChart(sendingData, numberOfPanels, this);
        }



        private void asd(string currentlyArrived)
        {
            new Thread(() =>
            {
                if (!String.IsNullOrWhiteSpace(currentlyArrived))
                {
                    //myPortBuffer.Add(currentlyArrived.Split(' '));
                    sendingData = currentlyArrived.Split(' ');
                    gearedCharts.ForEach(p => p.viewModel.recivedChartValues.Clear());
                    ChartController.printChartMonitor(mmw.chartMonitor, sendingData);
                    ChartController.printChart(sendingData, numberOfPanels, this);
                }

            }).Start();
        }
    }
}
