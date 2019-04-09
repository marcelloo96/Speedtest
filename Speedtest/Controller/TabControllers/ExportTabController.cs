using Speedtest.Controller.TabControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedtest.Controller
{
    class RecordingTabController 
    {
        internal static void FillEditors(MainFrame model)
        {
            model.exportingFileFormatEditValue = Strings.Recording_ExportinFileFormat_CSV;
            model.ExportingFileFormatRepositoryItemComboBox.Items.Add(Strings.Recording_ExportinFileFormat_CSV);
            model.ExportingFileFormatRepositoryItemComboBox.Items.Add(Strings.Recording_ExportinFileFormat_TXT);
        }
    }
}
