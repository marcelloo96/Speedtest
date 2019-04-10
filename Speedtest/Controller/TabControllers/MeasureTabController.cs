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
        internal static void FillEditors(MainFrame model)
        {
            model.EdgeTypeRepositoryItemComboBox.Items.Add(Strings.Measure_EdgeType_Rising);
            model.EdgeTypeRepositoryItemComboBox.Items.Add(Strings.Measure_EdgeType_Fall);
            model.edgeTypeElementValue = Strings.Measure_EdgeType_Rising;
        }


    }
}
