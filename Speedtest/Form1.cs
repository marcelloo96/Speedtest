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
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region fields
        public RepositoryItemComboBox BaudRateRepositoryItemComboBox { get { return baudRateRepositoryItemComboBox; } }
        public RepositoryItemComboBox SelectedPortRepositoryItemComboBox { get { return selectedPortRepositoryItemComboBox; } }
        public RepositoryItemComboBox NumberOfChannelsRepositoryItemComboBox { get { return numberOfChannelsRepositoryItemComboBox; } }
        public RepositoryItemComboBox DisplayModeRepositoryItemComboBox { get { return displayModeRepositoryItemComboBox; } }
        public BarEditItem DisplayModeElement { get { return displayModeElement; } }
        public BarEditItem BaudRateElement { get { return baudRateElement; } }
        public BarEditItem ChannelsElement { get { return channelsElement; } }
        public BarEditItem SelectedPortElement { get { return selectedPortElement; } }
        public BarButtonItem ConnectButton { get { return connectButton; } }
        public BarButtonItem StartStopButton { get { return startStopButton; } }
        public bool connectedState { get; set; }
        public string displayMode { get; set; }
        public string selectedPortName { get; set; }

        public string baudRate { get; set; }
        #endregion

        public Form1()
        {
            InitializeComponent();

            MeasureTabController.FillEditors(this);
            MeasureTabController.SetInitialState(this);
            


        }

        private void connectButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            MeasureTabController.SetConnection(this);

        }

        private void startStopButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            SpeedTest asd = new SpeedTest();
            asd.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(asd);
            int tmp = 0;
            int.TryParse(channelsElement.EditValue.ToString(), out tmp);
            asd.externalStart(tmp, SelectedPortElement.EditValue.ToString());
        }
    }
}
