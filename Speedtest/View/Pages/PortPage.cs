using DevExpress.XtraBars;
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
        public string selectedPortElementValue
        {
            get { return (string)selectedPortElement.EditValue; }
            set { selectedPortElement.EditValue = value; }
        }
        public int baudRateFromElementValue
        {
            get { return (int)baudRateElement.EditValue; }
            set { baudRateElement.EditValue = value; }
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

        #endregion
        #region EditValueChanged
        private void selectedPortElement_EditValueChanged(object sender, EventArgs e)
        {
            testConnect();
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
                serialPort.BaudRate = baudRateFromElementValue;
            }
        }

        private void dataBitsElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.DataBits = dataBitsElementValue;
            }
        }

        private void parityElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.Parity = parityElementValue;
            }
        }

        private void stopBitElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.StopBits = stopBitElementValue;
            }
        }

        private void rtsEnableElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.RtsEnable = rtsEnableElementValue;
            }
        }

        private void dtrEnableElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.DtrEnable = dtrEnableElementValue;
            }
        }

        private void handShakeElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.Handshake = handShakeElementValue;
            }
        }

        private void writeBufferSizeElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.WriteBufferSize = writeBufferSizeElementValue;
            }
        }

        private void readBufferSizeElement_EditValueChanged(object sender, EventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.ReadBufferSize = readBufferSizeElementValue;
            }
        }
        #endregion
        #region ComboBoxes
        public RepositoryItemComboBox SelectedPortRepositoryItemComboBox { get { return selectedPortRepositoryItemComboBox; } }
        public RepositoryItemComboBox BaudRateRepositoryItemComboBox { get { return baudRateRepositoryItemComboBox; } }
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
        #region Groups
        public RibbonPageGroup PortAdvancedsGroup { get { return portAdvancedsGroup; } }
        #endregion

    }
}
