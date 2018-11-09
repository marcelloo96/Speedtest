using Speedtest.Properties;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedtest.Controller
{
    public static class MeasureTabController
    {
        public static readonly int[] baudRates = new int[] { 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 74880, 115200, 230400, 250000, 500000, 1000000, 2000000 };
        public static readonly int[] numberOfChannels = new int[] { 1, 2, 3, 4, 5 };

        internal static void FillEditors(Form1 model)
        {
            model.BaudRateRepositoryItemComboBox.Items.AddRange(baudRates);
            model.SelectedPortRepositoryItemComboBox.Items.AddRange(SerialPort.GetPortNames());
            model.NumberOfChannelsRepositoryItemComboBox.Items.AddRange(numberOfChannels);

            model.BaudRateRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            model.SelectedPortRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            model.NumberOfChannelsRepositoryItemComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

        }

        internal static void SetInitialState(Form1 model)
        {
            model.DisplayModeElement.Enabled = false;
            model.StartStopButton.Enabled = false;
            //   model.DisplayModeRepositoryItemComboBox.ReadOnly = true;
        }

        internal static void SetConnection(Form1 model)
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
            }
            else
            {
                /*Connecting*/

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
    }
}
