﻿using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Repository;
using Speedtest.Controller;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Speedtest
{
    public partial class MainFrame
    {
        #region ElementValues
        public int baudRateFromElementValue
        {
            get { return (int)baudRateElement.EditValue; }
            set { baudRateElement.EditValue = value; }
        }
        public int numberOfChannelsFromElementValue
        {
            get { return (int)channelsElement.EditValue; }
            set { channelsElement.EditValue = value; }
        }
        public string selectedPortElementValue
        {
            get { return (string)selectedPortElement.EditValue; }
            set { selectedPortElement.EditValue = value; }
        }
        public int dataBitsElementValue
        {
            get { return (int)dataBitsElement.EditValue; }
            set { dataBitsElement.EditValue = value; }
        }
        public Parity parityElementValue
        {
            get { return (Parity)parityElement.EditValue; }
            set { parityElement.EditValue = value; }
        }
        public StopBits stopBitElementValue
        {
            get { return (StopBits)stopBitElement.EditValue; }
            set { stopBitElement.EditValue = value; }
        }
        public bool rtsEnableElementValue
        {
            get { return (bool)rtsEnableElement.EditValue; }
            set { rtsEnableElement.EditValue = value; }
        }
        public bool dtrEnableElementValue
        {
            get { return (bool)dtrEnableElement.EditValue; }
            set { dtrEnableElement.EditValue = value; }
        }
        public Handshake handShakeElementValue
        {
            get { return (Handshake)handShakeElement.EditValue; }
            set { handShakeElement.EditValue = value; }
        }
        public int readBufferSizeElementValue
        {
            get { return (int)readBufferSizeElement.EditValue; }
            set { readBufferSizeElement.EditValue = value; }
        }
        public int writeBufferSizeElementValue
        {
            get { return (int)writeBufferSizeElement.EditValue; }
            set { writeBufferSizeElement.EditValue = value; }
        }
        public string delimeterElementValue
        {
            get { return (string)delimeterElement.EditValue; }
            set { delimeterElement.EditValue = value; }
        }
        public int samplingRateElementValue
        {
            get { return (int)samplingRateElement.EditValue; }
            set { samplingRateElement.EditValue = value; }
        }
        public int keepRecordsElementValue
        {
            get { return Int32.Parse(keepRecordsElement.EditValue.ToString()); }
            set { keepRecordsElement.EditValue = value; }
        }
        #endregion
        public BarEditItem ChannelsElement
        {
            get { return channelsElement; }
        }
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
        public BarEditItem NumberOfIncomingDataElement { get { return numberOfIncomingDataElement; } }

        public string DisplayModeElementValue {
            get { return (string) displayModeElement.EditValue; }
            set { displayModeElement.EditValue = value; }
        }
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
        public BarStaticItem IsPortConnectedStatusBarLabel
        {
            get { return portStatusLabel; }
            set { portStatusLabel = value; }
        }
        #endregion

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
                serialPort.ReadBufferSize = readBufferSizeElementValue;
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
                    delimeterElementValue = PortOptionsTabController.defaultDelimeter;
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
                if (keepRecordsElementValue < 1)
                {
                    keepRecordsElementValue = 1;
                }
                else if (keepRecordsElementValue > 1000)
                {
                    keepRecordsElementValue = 1000;
                }

                if (mmw != null)
                {
                    foreach (var i in mmw.gearedCharts)
                    {
                        i.viewModel.keepRecords = keepRecordsElementValue;
                    }
                }
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
    }
}