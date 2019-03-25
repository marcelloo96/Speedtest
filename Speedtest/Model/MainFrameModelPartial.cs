using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            get { return (int)keepRecordsElement.EditValue; }
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
    }
}
