using Speedtest.Properties;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Speedtest.Controller
{
    public static class PortController
    {
        public static void CreatePort(MainFrame model)
        {

            model.serialPort = new SerialPort()
            {
                PortName = (string)model.SelectedPortElement.EditValue,
                BaudRate=(int)model.BaudRateElement.EditValue,
                DataBits=(int)model.DataBitsElement.EditValue,
                Parity=(Parity)model.ParityElement.EditValue,
                StopBits=(StopBits)model.StopBitElement.EditValue,
                RtsEnable=(bool)model.RtsEnableElement.EditValue,
                DtrEnable=(bool)model.DtrEnableElement.EditValue,
                Handshake=(Handshake)model.HandShakeElement.EditValue

            };
        }

        internal static void DoTheConnection(MainFrame model)
        {
            try
            {
                model.serialPort.Open();
                if (model.serialPort.IsOpen)
                {
                    model.IsPortConnectedStatusBarLabel.Caption = StringConstants.portStatusConnected;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
