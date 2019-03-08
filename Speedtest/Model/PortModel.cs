using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedtest.Model
{
    class PortModel : SerialPort
    {
        /// <summary>
        /// Requires a MainFrame model to set its SerialPort to default state.
        /// </summary>
        /// <param name="mainFrameModel"></param>
        public PortModel(MainFrame mainFrameModel)
        {
            PortName = (string)mainFrameModel.SelectedPortElement.EditValue;
            BaudRate = (int)mainFrameModel.BaudRateElement.EditValue;
            DataBits = (int)mainFrameModel.DataBitsElement.EditValue;
            Parity = (Parity)mainFrameModel.ParityElement.EditValue;
            StopBits = (StopBits)mainFrameModel.StopBitElement.EditValue;
            RtsEnable = (bool)mainFrameModel.RtsEnableElement.EditValue;
            DtrEnable = (bool)mainFrameModel.DtrEnableElement.EditValue;
            Handshake = (Handshake)mainFrameModel.HandShakeElement.EditValue;
            ReceivedBytesThreshold = 500000;

        }
    }
}
