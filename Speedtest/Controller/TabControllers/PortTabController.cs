using System;
using System.IO.Ports;

namespace Speedtest.Controller
{
    class PortOptionsTabController
    {
        public static readonly int[] baudRateOptionsList = new int[] { 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 74880, 115200, 230400, 250000, 500000, 1000000, 2000000 };
        public static readonly int[] dataBitsOptionList = new int[] { 5, 6, 7, 8 };
        public static readonly int[] numberOfChannelsOptionList = new int[] { 1, 2, 3, 4, 5 };
        public static readonly Parity[] paritiesOptionList = new Parity[] { Parity.None, Parity.Even, Parity.Odd, Parity.Mark, Parity.Space };
        public static readonly StopBits[] stopBitsOptionList = new StopBits[] { StopBits.One, StopBits.OnePointFive, StopBits.Two };
        public static readonly bool[] boolOptions = new bool[] { true, false };
        public static readonly Handshake[] handshakeOptionList = new Handshake[] { Handshake.None, Handshake.RequestToSend, Handshake.RequestToSendXOnXOff, Handshake.XOnXOff };
        public static readonly int[] readWriteBufferSizes = getListOf2Exponents();


        internal static void FillEditors(MainFrame model)
        {
            //Basic
            model.BaudRateRepositoryItemComboBox.Items.AddRange(baudRateOptionsList);
            model.SelectedPortRepositoryItemComboBox.Items.AddRange(SerialPort.GetPortNames());
            model.NumberOfChannelsRepositoryItemComboBox.Items.AddRange(numberOfChannelsOptionList);

            //Advanced
            model.DataBitsReporitotyItemComboBox.Items.AddRange(dataBitsOptionList);
            model.ParityRepositoryItemComboBox.Items.AddRange(paritiesOptionList);
            model.StopBitRepositoryItemComboBox.Items.AddRange(stopBitsOptionList);
            model.RtsEnableRepositoryItemComboBox.Items.AddRange(boolOptions);
            model.DtrEnableRepositoryItemComboBox.Items.AddRange(boolOptions);
            model.HandShakeRepositoryItemComboBox.Items.AddRange(handshakeOptionList);
            model.ReadBufferSizeRepositoryItemComboBox.Items.AddRange(readWriteBufferSizes);
            model.WriteBufferSizeRepositoryItemComboBox.Items.AddRange(readWriteBufferSizes);

            //SETTING DEFAULT VALUES
            model.baudRateFromElementValue = baudRateOptionsList[11]; //115200
            model.dataBitsElementValue = dataBitsOptionList[3]; //8
            model.parityElementValue = Parity.None;
            model.stopBitElementValue = StopBits.One;
            model.handShakeElementValue = Handshake.None;
            model.readBufferSizeElementValue = readWriteBufferSizes[0];
            model.writeBufferSizeElementValue = readWriteBufferSizes[0];
            model.rtsEnableElementValue = false;
            model.dtrEnableElementValue = false;

            #region DisableEditingOnComboBoxes
            model.BaudRateRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            model.SelectedPortRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            model.NumberOfChannelsRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            model.DataBitsReporitotyItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            model.ParityRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            model.StopBitRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            model.RtsEnableRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            model.DtrEnableRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            model.HandShakeRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            #endregion
        }

        public static int[] getListOf2Exponents()
        {
            int[] list = new int[19];
            for (int i = 12; i < 31; i++)
            {
                list[i - 12] = Convert.ToInt32(Math.Pow(2, i));
            }
            return list;
        }
    }
}
