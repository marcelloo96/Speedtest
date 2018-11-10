using Speedtest.Properties;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Speedtest.Controller
{
    public static class MeasureTabController
    {
        //public static readonly int[] baudRates = new int[] { 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 74880, 115200, 230400, 250000, 500000, 1000000, 2000000 };
        //public static readonly int[] numberOfChannels = new int[] { 1, 2, 3, 4, 5 };

        internal static void FillEditors(MainFrame model)
        {
            //TODO DISPLAY
        }

        internal static void SetInitialState(MainFrame model)
        {
            model.DisplayModeElement.Enabled = false;
            model.StartStopButton.Enabled = false;
            //   model.DisplayModeRepositoryItemComboBox.ReadOnly = true;
        }

        internal static void ConnectionManager(MainFrame model)
        {
            if (model.connectedState)
            {
                /*Disconnecting*/

                model.SelectedPortElement.Enabled = true;
                model.BaudRateElement.Enabled = true;
                model.ChannelsElement.Enabled = true;
                model.DisplayModeElement.Enabled = false;
                model.StartStopButton.Enabled = false;

                model.ConnectButton.ImageOptions.SvgImage = Resources.connect;
                model.ConnectButton.Caption = StringConstants.connect;

                model.connectedState = !model.connectedState;

                try
                {
                    CloseSerialOnExit(model.serialPort);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                if (!model.serialPort.IsOpen)
                {
                    model.IsPortConnectedStatusBarLabel.Caption = StringConstants.portStatusDisconnected;
                }
            }
            else
            {
                /*Connecting*/
                string portName = model.SelectedPortElement.EditValue.ToString();
                int baudRate = Int32.Parse(model.BaudRateElement.EditValue.ToString());

                var a = PortController.CreatePort(model);
                model.serialPort = new SerialPort(portName, baudRate);
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

                if (model.BaudRateElement.EditValue != null &&
                    model.SelectedPortElement.EditValue != null &&
                    model.ChannelsElement.EditValue != null)
                {
                    model.SelectedPortElement.Enabled = false;
                    model.BaudRateElement.Enabled = false;
                    model.ChannelsElement.Enabled = false;
                    model.DisplayModeElement.Enabled = true;
                    model.StartStopButton.Enabled = true;

                    model.ConnectButton.ImageOptions.SvgImage = Resources.disconnect;
                    model.ConnectButton.Caption = StringConstants.disconnect;

                    model.connectedState = !model.connectedState;
                }




            }


        }
        private static void CloseSerialOnExit(SerialPort serialPort)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.DtrEnable = false;
                    serialPort.RtsEnable = false;
                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();
                    serialPort.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

        }
    }
}
