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
    public static class HomeTabController
    {
        internal static void FillEditors(MainFrame model)
        {
            //TODO DISPLAY
            model.numberOfChannelsElementValue = 1;
            //model.SelectedPortElement.EditValue = "COM3";
            model.samplingRateElementValue = 1;
            model.selectIncomingLiveChannelsElementValue = 1;
            model.keepRecordsElementValue = 300;
            model.DisplayModeElement.EditValue = Strings.MeasureTab_DisplayMode_MultiPanel;
            model.SelectIncomingLiveChannelsElement.Enabled = false;
            model.SelectIncomingLiveChannelsRepositoryItemComboBox.Items.AddRange(new int[5] {1,2,3,4,5 });
            model.DisplayModeRepositoryItemComboBox.Items.AddRange(new string[] {
                Strings.MeasureTab_DisplayMode_MultiPanel,
                Strings.MeasureTab_DisplayMode_SinglePanel,
                Strings.MeasureTab_DisplayMode_Monitor
            }
            );

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

        internal static void SetGroupsAndIconsToCurrentState(MainFrame mainFrameModel)
        {
            if (mainFrameModel.connectedState)
            {
                ///*Disconnecting*/                

                setAllPortOptionsToRecentConnectState(mainFrameModel);

                try
                {
                    var succesfullyClosed = PortController.CloseSerialOnExit(mainFrameModel.serialPort);
                    if (succesfullyClosed)
                    {
                        mainFrameModel.connectedState = false;
                    }
                    else
                    {
                        mainFrameModel.connectedState = true;
                    }

                    mainFrameModel.serialPort.Dispose();
                    mainFrameModel.IsPortConnectedStatusBarLabel.Caption = StringConstants.portStatusDisconnected;
                    mainFrameModel.ConnectButton.ImageOptions.SvgImage = Resources.connect;
                    mainFrameModel.ConnectButton.Caption = StringConstants.connect;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }


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
                var portOpened = mainFrameModel.portController.OpenThePort();

                if (portOpened)
                {
                    // mainFrameModel.numberOfPanelsDisplayed = mainFrameModel.numberOfChannelsFromElementValue;
                    mainFrameModel.IsPortConnectedStatusBarLabel.Caption = StringConstants.portStatusConnected;

                }

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

    }
}
