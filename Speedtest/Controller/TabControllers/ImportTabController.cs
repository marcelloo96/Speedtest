using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedtest.Controller.TabControllers
{
    class ImportTabController
    {
        internal static void FillEditors(MainFrame model, int numberOfChannels=0)
        {
            List<string> displayModes = new List<string>();
            
            displayModes.Add(Strings.Import_DisplayMode_Scroll);
            displayModes.Add(Strings.Import_DisplayMode_Histogram);

            model.ImportDisplayModeElementRepositoryItemComboBox.Items.AddRange(displayModes);

            
            model.importDisplayModeElementValue = displayModes.First();



           

        }

        internal static void ResetDetectedChannels(MainFrame model, int channelsCount)
        {
            int[] channelArray = new int[channelsCount];


            for (int i = 0; i < channelsCount; i++)
            {
                channelArray[i] = i + 1;
            }
            model.SelectRecordedChannelRepositoryItemComboBox.Items.AddRange(channelArray);
            model.SelectRecordedChannelElementValue = channelsCount > 0 ? 1 : 0;
        }
    }
}
