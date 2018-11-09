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
        public static readonly int[] baudRates = new int[] {300,1200,2400,4800,9600,19200,38400,57600,74880,115200,230400,250000,500000,1000000,2000000 };
        public static readonly int[] numberOfChannels = new int[] { 1, 2, 3, 4, 5 };

        internal static void FillEditors(Form1 model)
        {
            model.BaudRateRepositoryItemComboBox.Items.AddRange(baudRates);
            model.SelectedPortRepositoryItemComboBox.Items.AddRange(SerialPort.GetPortNames());
            model.NumberOfChannelsRepositoryItemComboBox.Items.AddRange(numberOfChannels);
        }

        internal static void SetInitialState(Form1 model)
        {
            model.DisplayModeElement.Enabled = false;
         //   model.DisplayModeRepositoryItemComboBox.ReadOnly = true;
        }
    }
}
