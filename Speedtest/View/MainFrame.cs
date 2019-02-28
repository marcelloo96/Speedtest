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
        #endregion
        #region Elements
        public BarEditItem DisplayModeElement { get { return displayModeElement; } }
        public BarEditItem BaudRateElement { get { return baudRateElement; } }
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
        public SerialPort serialPort;
        public SpeedTest gearedChart;
        public List<SpeedTest> gearedCharts;
        public PortController portController;
        public MainMeasureWindow mmw;
        public bool connectedState { get; set; }
        public bool isRunning { get; set; }
        public double tryparseTmp;
        public readonly bool firstConnect = true;


        #endregion

        public MainFrame()
        {
            InitializeComponent();
            portController = new PortController(this);
            MeasureTabController.FillEditors(this);
            PortOptionsTabController.FillEditors(this);
            MeasureTabController.SetInitialState(this);
            gearedCharts = new List<SpeedTest>();
            //testConnect();


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
                    else {

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
            if (isRunning)
            {
                serialPort.DataReceived -= portController.dataFlow;
                isRunning = false;
            }
            else
            {
                serialPort.DataReceived += portController.dataFlow;
                isRunning = true;
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
                serialPort.ReadBufferSize = (int)readBufferSizeElement.EditValue;
            }
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
            mmw.resizeControls(contentPanel.Height);
        }
    }
}
