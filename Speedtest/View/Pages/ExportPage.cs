using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using Speedtest.Properties;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Speedtest
{
    public partial class MainFrame
    {
        public StringBuilder csvBuffer;
        public string savingFileDestinationPath;
        public bool Recording { get; set; }

        #region ElementValues
        public string exportingFileFormatEditValue
        {
            get { return exportingFileFormatElement.EditValue.ToString(); }
            set { exportingFileFormatElement.EditValue = value; }
        }
        public string fileDestinationButtonCaption
        {
            get { return fileDestinationButtonElement.Caption; }
            set { fileDestinationButtonElement.Caption = value; }
        }
        public string exportFileNameElementValue
        {
            get { return exportFileNameElement.EditValue == null ? "" : exportFileNameElement.EditValue.ToString(); }
            set { exportFileNameElement.EditValue = value; }
        }
        #endregion
        #region ComboBoxes
        public RepositoryItemComboBox ExportingFileFormatRepositoryItemComboBox { get { return exportingFileFormatRepositoryItemComboBox; } }
        #endregion
        private void recordButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Recording)
            {
                //Stop Recording and save
                if (exportingFileFormatEditValue == Strings.Recording_ExportinFileFormat_CSV || exportingFileFormatEditValue == Strings.Recording_ExportinFileFormat_TXT)
                {
                    if (String.IsNullOrEmpty(exportFileNameElementValue))
                    {
                        exportFileNameElementValue = "Measurement_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    }
                    string csvpath = savingFileDestinationPath + @"\" + exportFileNameElementValue + exportingFileFormatEditValue;
                    File.AppendAllText(csvpath, csvBuffer.ToString());

                }
                csvBuffer.Clear();
                Recording = false;
                recordButton.Caption = Strings.Recording_Start;
                recordButton.ImageOptions.SvgImage = Resources.record;
                exportFileNameElementValue = "";
            }
            else
            {
                //Recording
                csvBuffer = new StringBuilder();
                Recording = true;
                recordButton.Caption = Strings.Recording_Stop;
                recordButton.ImageOptions.SvgImage = Resources.cancel;

                if (String.IsNullOrEmpty(exportFileNameElementValue))
                {
                    exportFileNameElementValue = "Measurement_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                }

            }
        }
        private void fileDestinationButtonElement_ItemClick(object sender, ItemClickEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = savingFileDestinationPath;
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                savingFileDestinationPath = dialog.SelectedPath;
                changeFileDestinationCaption(savingFileDestinationPath);
            }
        }
        private void changeFileDestinationCaption(string savingFileDestinationPath)
        {
            var splittedPath = savingFileDestinationPath.Split('\\');
            var shortPath = splittedPath.First() + @"\...\" + splittedPath.Last();
            fileDestinationButtonCaption = Strings.Recording_FileDestinationButton + ":\n" + shortPath;
        }

    }
}
