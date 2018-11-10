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

namespace Speedtest
{
    public partial class MainFrame : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region fields
        public RepositoryItemComboBox BaudRateRepositoryItemComboBox { get { return baudRateRepositoryItemComboBox; } }
        public RepositoryItemComboBox SelectedPortRepositoryItemComboBox { get { return selectedPortRepositoryItemComboBox; } }
        public RepositoryItemComboBox NumberOfChannelsRepositoryItemComboBox { get { return dataBitsRepositoryItemComboBox; } }
        public RepositoryItemComboBox DisplayModeRepositoryItemComboBox { get { return displayModeRepositoryItemComboBox; } }
        public BarEditItem DisplayModeElement { get { return displayModeElement; } }
        public BarEditItem BaudRateElement { get { return baudRateElement; } }
        public BarEditItem ChannelsElement { get { return channelsElement; } }
        public BarEditItem SelectedPortElement { get { return selectedPortElement; } }
        public BarButtonItem ConnectButton { get { return connectButton; } }
        public BarButtonItem StartStopButton { get { return startStopButton; } }
        public BarStaticItem IsPortConnectedStatusBarLabel { get { return portStatusLabel; } set { portStatusLabel = value; } }
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
    }
}
