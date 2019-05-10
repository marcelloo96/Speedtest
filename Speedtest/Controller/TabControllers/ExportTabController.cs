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
