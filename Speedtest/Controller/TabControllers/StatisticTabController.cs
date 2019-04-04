using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedtest.Controller.TabControllers
{
    class StatisticTabController
    {
        internal static void FillEditors(MainFrame model, int numberOfChannels)
        {
            int[] channelArray = new int[numberOfChannels];
            for (int i = 0; i< numberOfChannels;i++) {
                channelArray[i] = i+1;
            }
            model.SelectRecordedChannelRepositoryItemComboBox.Items.AddRange(channelArray);
            model.SelectRecordedChannelElementValue = numberOfChannels > 0 ? 1 : 0;
        }
    }
}
