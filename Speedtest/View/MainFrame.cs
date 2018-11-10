using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using Speedtest.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Speedtest.Properties;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;

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
        public bool connectedState { get; set; }
        public string displayMode { get; set; }
        public string selectedPortName { get; set; }

        public string baudRate { get; set; }
        #endregion

        public MainFrame()
        {
            InitializeComponent();

            MeasureTabController.FillEditors(this);
            PortOptionsTabController.FillEditors(this);

            MeasureTabController.SetInitialState(this);

        }

        private void connectButton_ItemClick(object sender, ItemClickEventArgs e)
        {
           MeasureTabController.ConnectionManager(this);

        }

        private void startStopButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            int numberOfChannels = Int32.Parse(channelsElement.EditValue.ToString());

            gearedChart = new SpeedTest(serialPort, numberOfChannels)
            {
                Dock = DockStyle.Fill
            };

            contentPanel.Controls.Add(gearedChart);

            gearedChart.externalStart();
        }

        private void backstageViewControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
