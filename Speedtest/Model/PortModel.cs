using System.IO.Ports;

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
            PortName = mainFrameModel.selectedPortElementValue;
            BaudRate = mainFrameModel.baudRateFromElementValue;
            DataBits = mainFrameModel.dataBitsElementValue;
            Parity = mainFrameModel.parityElementValue;
            StopBits = mainFrameModel.stopBitElementValue;
            RtsEnable = mainFrameModel.rtsEnableElementValue;
            DtrEnable = mainFrameModel.dtrEnableElementValue;
            Handshake = mainFrameModel.handShakeElementValue;
            ReceivedBytesThreshold = 500000;

        }
    }
}
