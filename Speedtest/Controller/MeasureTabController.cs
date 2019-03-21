using Speedtest.Model;
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
            model.ChannelsElement.EditValue = 2;
            //model.SelectedPortElement.EditValue = "COM3";
            model.SamplingRateElement.EditValue = 1;
            model.KeepRecordsElement.EditValue = 300;
            model.NumberOfIncomingDataElement.EditValue = 3;
            model.DisplayModeElement.EditValue = Strings.MeasureTab_ChartDisplayMode;
            model.DisplayModeRepositoryItemComboBox.Items.AddRange(new string[] {Strings.MeasureTab_ChartDisplayMode, Strings.MeasureTab_MonitorDisplayMode});

        }
        /// <summary>
        /// Disable all functions that need a connection
        /// </summary>
        /// <param name="model"></param>
        internal static void SetInitialState(MainFrame model)
        {
            //model.DisplayModeElement.Enabled = false;
            model.StartStopButton.Enabled = false;
            //model.DisplayModeRepositoryItemComboBox.ReadOnly = true;
        }

        internal static void ConnectionManager(MainFrame mainFrameModel)
        {
            if (mainFrameModel.connectedState)
            {
                ///*Disconnecting*/                

                setAllPortOptionsToRecentConnectState(mainFrameModel);

                mainFrameModel.ConnectButton.ImageOptions.SvgImage = Resources.connect;
                mainFrameModel.ConnectButton.Caption = StringConstants.connect;                

                try
                {
                    CloseSerialOnExit(mainFrameModel.serialPort);
                    mainFrameModel.serialPort.Dispose();
                    mainFrameModel.IsPortConnectedStatusBarLabel.Caption = StringConstants.portStatusDisconnected;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                
                mainFrameModel.connectedState = false;
            }
            else
            {
                /*Connecting*/

                //TODO: Check the editors

                setAllPortOptionsToRecentConnectState(mainFrameModel);

                mainFrameModel.ConnectButton.ImageOptions.SvgImage = Resources.disconnect;
                mainFrameModel.ConnectButton.Caption = StringConstants.disconnect;

                //model.portController.CreatePort();
                mainFrameModel.portController.CreatePort();
                mainFrameModel.portController.DoTheConnection();

                mainFrameModel.connectedState = true;
            }


        }
        /// <summary>
        /// Enable/Diasble all Port options depending on the model's 'connectingState' parameter
        /// </summary>
        /// <param name="model"></param>
        private static void setAllPortOptionsToRecentConnectState(MainFrame model)
        {
            model.ChannelsElement.Enabled = model.connectedState;
            model.PortAdvancedsGroup.Enabled = model.connectedState;
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
