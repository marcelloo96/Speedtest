using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using Speedtest.Controller;
using System;
using System.IO.Ports;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Docking;
using System.Collections.Generic;
using Speedtest.View.MeasureWindow;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Speedtest.Properties;
using System.IO;
using Speedtest.Model;
using Speedtest.Controller.TabControllers;
using Speedtest.Model.ChartViewModels;
using Speedtest.View.StatisticWindow;

namespace Speedtest
{
    public partial class MainFrame : RibbonForm
    {
        #region fields
        public SpeedTest gearedChart;
        public List<SpeedTest> gearedCharts;
        public PortController portController;
        public MainMeasureWindow mmw;
        public bool connectedState { get; set; }
        public bool isRunning { get; set; }
        public bool Recording { get; set; }
        public List<string[]> myPortBuffer;
        public double deltaTime;
        public double[] sendingData;
        DataCollector dc;
        public static bool useLinearity = false;
        public static double sensitivity = 1;
        public static double zeroValue = 1;
        public static int numberOfPanels = 1;
        public StringBuilder csvBuffer;
        public string savingFileDestinationPath;
        public string importingFilePath;
        public List<List<double>> listOfImportedCharts;
        #endregion

        public MainFrame()
        {
            InitializeComponent();
            MeasureTabController.FillEditors(this);
            PortOptionsTabController.FillEditors(this);
            RecordingTabController.FillEditors(this);
            MeasureTabController.SetInitialState(this);
            portController = new PortController(this);
            gearedCharts = new List<SpeedTest>();
            myPortBuffer = new List<string[]>();

            savingFileDestinationPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            changeFileDestinationCaption(savingFileDestinationPath);

        }


        public void testConnect()
        {
            if (!String.IsNullOrWhiteSpace(selectedPortElementValue))
            {
                try
                {
                    MeasureTabController.SetGroupsAndIconsToCurrentState(this);

                    if (connectedState)
                    {
                        mmw = new MainMeasureWindow(this);
                        mmw.Dock = DockStyle.Fill;
                        contentPanel.Controls.Add(mmw);
                    }
                    else
                    {

                        contentPanel.Controls.Clear();
                        mmw.deleteControls();

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

        }

        private void connectButton_ItemClick(object sender, ItemClickEventArgs ea)
        {
            if (connectedState)
            {
                //Disconnecting

                contentPanel.Controls.Clear();
                mmw.deleteControls();
                mmw.Dispose();
                PortController.CloseSerialOnExit(serialPort);
                serialPort.Dispose();
                MeasureTabController.SetGroupsAndIconsToCurrentState(this);
                connectedState = false;
                measureControlPanelGroup.Enabled = false;


            }
            else
            {
                //Connecting
                if (String.IsNullOrWhiteSpace(selectedPortElementValue))
                {
                    MessageBox.Show(Strings.Global_Error_NoPortSelected);
                }
                else
                {
                    testConnect();
                }
                connectedState = true;
                isRunning = false;
                measureControlPanelGroup.Enabled = true;
            }

        }
        private void displayModeElement_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (mmw != null)
                {
                    if (DisplayModeElementValue == Strings.MeasureTab_DisplayMode_Chart)
                    {
                        mmw.splitContainerControl.Dock = DockStyle.Fill;
                        mmw.splitContainerControl.BringToFront();

                        mmw.chartMonitor.Dock = DockStyle.None;
                        mmw.chartMonitor.SendToBack();
                        mmw.xyChartUserControl.Dock = DockStyle.None;
                        mmw.xyChartUserControl.SendToBack();

                        ChartController.RemoveMonitorText(this);
                    }
                    else if (DisplayModeElementValue == Strings.MeasureTab_DisplayMode_Monitor)
                    {
                        mmw.chartMonitor.Dock = DockStyle.Fill;
                        mmw.chartMonitor.BringToFront();

                        mmw.splitContainerControl.Dock = DockStyle.None;
                        mmw.splitContainerControl.SendToBack();
                        mmw.xyChartUserControl.Dock = DockStyle.None;
                        mmw.xyChartUserControl.SendToBack();

                        ChartController.RemoveAllPointsFromGeared(gearedCharts);
                    }
                    else if (DisplayModeElementValue == Strings.MeasureTab_DisplayMode_XY)
                    {
                        mmw.xyChartUserControl.Dock = DockStyle.Fill;
                        mmw.xyChartUserControl.BringToFront();

                        mmw.chartMonitor.SendToBack();
                        mmw.chartMonitor.Dock = DockStyle.None;
                        mmw.splitContainerControl.Dock = DockStyle.None;
                        mmw.splitContainerControl.SendToBack();

                        ChartController.RemoveMonitorText(this);
                        ChartController.RemoveAllPointsFromGeared(gearedCharts);

                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("displayModeElement_EditValueChanged");
            }


        }

        private void startStopButton_ItemClick(object sender, ItemClickEventArgs ea)
        {
            try
            {
                deltaTime = 1 / samplingRateElementValue;
                if (isRunning)
                {
                    isRunning = false;
                    dc.Dispose();
                    connectiongGroup.Enabled = true;
                    measurePortBasicGroup.Enabled = true;
                    keepRecordsElement.Enabled = true;
                    StartStopButton.Caption = Strings.Global_Start;
                    StartStopButton.ImageOptions.SvgImage = Resources.start;
                }
                else
                {
                    isRunning = true;
                    if (serialPort == null)
                    {
                        portController.CreatePort();

                    }
                    if (!serialPort.IsOpen)
                    {
                        portController.OpenThePort();
                    }
                    dc = new DataCollector(serialPort, printTo);
                    serialPort.DiscardInBuffer();
                    connectiongGroup.Enabled = false;
                    measurePortBasicGroup.Enabled = false;
                    keepRecordsElement.Enabled = false;
                    StartStopButton.Caption = Strings.Global_Stop;
                    StartStopButton.ImageOptions.SvgImage = Resources.stop;


                }
            }
            catch (Exception e)
            {

                MessageBox.Show("startStopButton_ItemClick");
            }




        }
        private void printTo(string currentlyArrived)
        {
            try
            {

                //Debug.WriteLine(currentlyArrived);
                sendingData = Array.ConvertAll(currentlyArrived.Split(' '), Double.Parse);

                if (Recording)
                {
                    csvBuffer.AppendLine(String.Join(",", sendingData));
                }
                if (useLinearity)
                {
                    sendingData = calculateLinearValue(sendingData, sensitivity, zeroValue);
                }
                gearedCharts.ForEach(p => p.viewModel.recivedChartValues.Clear());

                if (DisplayModeElementValue == Strings.MeasureTab_DisplayMode_Chart)
                {
                    ChartController.printGearedChart(sendingData, numberOfPanels, this);
                }
                else if (DisplayModeElementValue == Strings.MeasureTab_DisplayMode_Monitor)
                {
                    ChartController.printChartMonitor(mmw.chartMonitor, sendingData);
                }
                else if (DisplayModeElementValue == Strings.MeasureTab_DisplayMode_XY)
                {
                    ChartController.printXYChart(mmw.xyChartUserControl, sendingData, numberOfIncomingDataEditValue);
                    //ChartController.printGearedChart(sendingData, numberOfPanels, this);
                }

            }
            catch (Exception e)
            {

                MessageBox.Show("printto" + e.Message);
            }


        }

        private double[] calculateLinearValue(double[] sendingData, double sensitivity, double zeroValue)
        {
            try
            {
                for (int i = 0; i < sendingData.Length; i++)
                {
                    sendingData[i] = sendingData[i] * sensitivity + zeroValue;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("calculateLinearValue" + e.Message);
            }

            return sendingData;
        }

        private void calculateLinearityButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (adcMaxEditValue != 0)
            {
                sensitivityElementValue = (double)((double)voltageReferenceEditValue / (double)adcMaxEditValue);
            }
        }

        private void recordButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Recording)
            {
                //Stop Recording and save
                if (exportingFileFormatEditValue == Strings.Recording_ExportinFileFormat_CSV || exportingFileFormatEditValue == Strings.Recording_ExportinFileFormat_TXT)
                {
                    string csvpath = savingFileDestinationPath + @"\Measurement_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") +exportingFileFormatEditValue;
                    File.AppendAllText(csvpath, csvBuffer.ToString());
                    
                }
                csvBuffer.Clear();
                Recording = false;
                recordButton.Caption = Strings.Recording_Start;
                recordButton.ImageOptions.SvgImage = Resources.record;
            }
            else
            {
                //Recording
                csvBuffer = new StringBuilder();
                Recording = true;
                recordButton.Caption = Strings.Recording_Stop;
                recordButton.ImageOptions.SvgImage = Resources.cancel;
            }
        }

        private void barEditItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
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

        private void statisticImportButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                importingFilePath = dialog.FileName;

                listOfImportedCharts = CSVModel.getListOfCharts(importingFilePath);
                var channelsCount = listOfImportedCharts.Count();
                statisticChannelsFoundLabel.Caption = Strings.Statistic_ChannelsFound + ": " + channelsCount;
                StatisticTabController.FillEditors(this, channelsCount);


            }

        }

        private void showSelectedChannelElement_ItemClick(object sender, ItemClickEventArgs e)
        {
            var scrollable = new ScrollableChartUserControl(listOfImportedCharts[SelectRecordedChannelElementValue],deltaTime);
            scrollable.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(scrollable);
        }

        private void recordingWholeMeasurementElement_EditValueChanged(object sender, EventArgs e)
        {
            //var recordfromStart = (bool)recordingWholeMeasurementElement.EditValue;

            //if (recordfromStart)
            //{
            //    recordButton.Enabled = false;
            //    Recording = true;
            //}
            //else
            //{
            //    recordButton.Enabled = true;
            //    Recording = false;
            //}

            //recordButton.PerformClick();

        }
    }

}
