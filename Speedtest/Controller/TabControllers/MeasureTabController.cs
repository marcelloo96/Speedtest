using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedtest.Controller
{
    class MeasureTabController
    {
        public static readonly int[] baudRateOptionsList = new int[] { 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 74880, 115200, 230400, 250000, 500000, 1000000, 2000000 };
        public static readonly int[] dataBitsOptionList = new int[] { 5, 6, 7, 8 };
        public static readonly int[] numberOfChannelsOptionList = new int[] { 1, 2, 3, 4, 5 };
        public static readonly Parity[] paritiesOptionList = new Parity[] { Parity.None, Parity.Even, Parity.Odd, Parity.Mark, Parity.Space };
        public static readonly StopBits[] stopBitsOptionList = new StopBits[] { StopBits.One, StopBits.OnePointFive, StopBits.Two };
        public static readonly bool[] boolOptions = new bool[] { true, false };
        public static readonly Handshake[] handshakeOptionList = new Handshake[] { Handshake.None, Handshake.RequestToSend, Handshake.RequestToSendXOnXOff, Handshake.XOnXOff };

        internal static void FillEditors(MainFrame model)
        {

        }


    }
}
