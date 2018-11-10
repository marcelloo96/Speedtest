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
                ///*Disconnecting*/

                setAllPortOptionsToRecentConnectState(model);

                model.ConnectButton.ImageOptions.SvgImage = Resources.connect;
                model.ConnectButton.Caption = StringConstants.connect;

                //try
                //{
                //    CloseSerialOnExit(model.serialPort);

                //    model.IsPortConnectedStatusBarLabel.Caption = StringConstants.portStatusDisconnected;

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);

                //}
                model.connectedState = false;
            }
            else
            {
                /*Connecting*/

                //TODO: Check the editors

                setAllPortOptionsToRecentConnectState(model);

                model.ConnectButton.ImageOptions.SvgImage = Resources.disconnect;
                model.ConnectButton.Caption = StringConstants.disconnect;

                PortController.CreatePort(model);

                //PortController.DoTheConnection(model);
                model.connectedState = true;
            }


        }
        /// <summary>
        /// Enable/Diasble all Port options depending on the model's 'connectingState' parameter
        /// </summary>
        /// <param name="model"></param>
        private static void setAllPortOptionsToRecentConnectState(MainFrame model)
        {
            model.MeasurePortBasicGroup.Enabled = model.connectedState;
            model.PortAdvancedsGroup.Enabled = model.connectedState;
            model.PortBasicsGroup.Enabled = model.connectedState;

            model.DisplayModeElement.Enabled = !model.connectedState;
            model.StartStopButton.Enabled = !model.connectedState;
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
