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
using LiveCharts.Defaults;
using LiveCharts.Geared;
using Speedtest.View;
using AForge.Math;
using static Speedtest.View.StatisticWindow.ScrollableChartUserControl;

namespace Speedtest
{
    public partial class MainFrame : RibbonForm
    {
        #region fields
        public DefaultChartUserControl defaultChart;
        public GearedValues<DefaultChartUserControl> defaultCharts;
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
        public List<List<double>> listOfImportedSeries;
        private List<UserControl> activePanels;
        private readonly bool alreadyExisting = true;
        private List<string> availableFileFilters;
        #endregion

        public MainFrame()
        {
            InitializeComponent();
            MeasureTabController.FillEditors(this);
            PortOptionsTabController.FillEditors(this);
            RecordingTabController.FillEditors(this);
            ImportTabController.FillEditors(this);
            MeasureTabController.SetInitialState(this);
            portController = new PortController(this);
            defaultCharts = new GearedValues<DefaultChartUserControl>();
            myPortBuffer = new List<string[]>();
            activePanels = new List<UserControl>();
            availableFileFilters = getFileFilters();

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
                        bringContentToFront(mmw);
                    }
                    else
                    {

                        contentPanel.Controls.Clear();
                        activePanels.Remove(mmw);
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

                        mmw.xyChartUserControl.Dock = DockStyle.None;
                        mmw.xyChartUserControl.SendToBack();

                        ChartController.RemoveAllPointsFromGeared(defaultCharts);
                    }
                    else if (DisplayModeElementValue == Strings.MeasureTab_DisplayMode_XY)
                    {
                        mmw.xyChartUserControl.Dock = DockStyle.Fill;
                        mmw.xyChartUserControl.BringToFront();

                        mmw.chartMonitor.SendToBack();
                        mmw.chartMonitor.Dock = DockStyle.None;

                        ChartController.RemoveMonitorText(this);
                        ChartController.RemoveAllPointsFromGeared(defaultCharts);

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
                if (isRunning)
                {
                    Debug.WriteLine(currentlyArrived);
                    sendingData = Array.ConvertAll(currentlyArrived.Split(' '), Double.Parse);

                    if (Recording)
                    {
                        csvBuffer.AppendLine(String.Join(",", sendingData));
                    }
                    if (useLinearity)
                    {
                        sendingData = calculateLinearValue(sendingData, sensitivity, zeroValue);
                    }
                    //gearedCharts.ForEach(p => p.viewModel.recivedChartValues.Clear());

                    if (DisplayModeElementValue == Strings.MeasureTab_DisplayMode_Chart)
                    {
                        ChartController.printGearedChart(sendingData, numberOfPanels, this, Recording);
                    }
                    else if (DisplayModeElementValue == Strings.MeasureTab_DisplayMode_Monitor)
                    {
                        ChartController.printChartMonitor(mmw.chartMonitor, sendingData);
                    }
                    else if (DisplayModeElementValue == Strings.MeasureTab_DisplayMode_XY)
                    {
                        ChartController.printDefaultChart(mmw.xyChartUserControl, sendingData, numberOfIncomingDataEditValue, Recording);
                        //ChartController.printGearedChart(sendingData, numberOfPanels, this);
                    }
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
            dialog.Filter = String.Join("|", availableFileFilters);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                importingFilePath = dialog.FileName;

                listOfImportedSeries = CSVModel.getListOfCharts(importingFilePath);
                var channelsCount = listOfImportedSeries.Count();
                statisticChannelsFoundLabel.Caption = Strings.Statistic_ChannelsFound + ": " + channelsCount;
                var fileName = importingFilePath.Split('\\').Last().Split('.').First();
                if (fileName.Length > 25)
                {
                    fileName = fileName.Remove(25, fileName.Length - 25) + "...";
                }
                importedFileName.Caption = fileName;
                ImportTabController.ResetDetectedChannels(this, channelsCount);

            }

        }

        private void showSelectedChannelElement_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (listOfImportedSeries != null)
            {
                var selectedChart = listOfImportedSeries[SelectRecordedChannelElementValue];

                


                //MathNet.Numerics.IntegralTransforms.Fourier.ForwardReal(selectedChart.ToArray(),n);
                if (importDisplayModeElementValue == Strings.Import_DisplayMode_Scroll)
                {
                    bringScrollableToFront(selectedChart.ToList(), activePanels.OfType<ScrollableChartUserControl>().ToList());
                }
                else if (importDisplayModeElementValue == Strings.Import_DisplayMode_Histogram)
                {
                    bringHistogramToFront(getHistogramFromChart(selectedChart), activePanels.OfType<SimpleObservablePointedChartUserControl>().ToList());
                }
                else if (importDisplayModeElementValue == Strings.Import_DisplayMode_FFT_PowerSpectrum) {
                    Complex[] complexArray = new Complex[selectedChart.Count];
                    for (int i = 0; i < selectedChart.Count; i++)
                    {
                        complexArray[i] = new Complex(selectedChart[i], 0);
                    }

                    FourierTransform.DFT(complexArray, FourierTransform.Direction.Forward);
                    double[] abs = new double[complexArray.Count()];
                    for (int i = 0; i < complexArray.Count(); i++)
                    {
                        abs[i] = complexArray[i].SquaredMagnitude;
                    }
                    bringScrollableToFront(abs.ToList(), activePanels.OfType<ScrollableChartUserControl>().ToList(), ScrollableType.FFT);
                }
                else if (importDisplayModeElementValue == Strings.Import_DisplayMode_FFT_PhaseSpectrum)
                {
                    Complex[] complexArray = new Complex[selectedChart.Count];
                    for (int i = 0; i < selectedChart.Count; i++)
                    {
                        complexArray[i] = new Complex(selectedChart[i], 0);
                    }

                    FourierTransform.DFT(complexArray, FourierTransform.Direction.Forward);
                    double[] abs = new double[complexArray.Count()];
                    for (int i = 0; i < complexArray.Count(); i++)
                    {
                        abs[i] = complexArray[i].Phase;
                    }
                    bringScrollableToFront(abs.ToList(), activePanels.OfType<ScrollableChartUserControl>().ToList());
                }

            }
            else
            {
                MessageBox.Show(Strings.Import_NoFilesImported);
            }

        }

        private void bringScrollableToFront(List<double> selectedChart, List<ScrollableChartUserControl> onPanelWithThisType, ScrollableType type = ScrollableType.Basic)
        {
            if (onPanelWithThisType != null && selectedChart != null)
            {
                foreach (var panel in onPanelWithThisType)
                {
                    if (panel.doubleValues.Equals(selectedChart))
                    {

                        bringContentToFront(panel, alreadyExisting);
                        return;
                    }
                }
            }

            bringContentToFront(new ScrollableChartUserControl(selectedChart, deltaTime, type));
        }

        private void bringHistogramToFront(GearedValues<ObservablePoint> generated, List<SimpleObservablePointedChartUserControl> onPanelWithThisType)
        {
            if (onPanelWithThisType != null && generated != null)
            {
                foreach (var panel in onPanelWithThisType)
                {
                    if (isObservablePointedChartsEqual(panel.Values, generated))
                    {

                        bringContentToFront(panel, alreadyExisting);
                        return;
                    }
                }

            }

            bringContentToFront(new SimpleObservablePointedChartUserControl(generated));
        }

        private bool isObservablePointedChartsEqual(GearedValues<ObservablePoint> a, GearedValues<ObservablePoint> b)
        {
            if (a == null || b == null)
            {
                return false;
            }
            if (a.Count() != b.Count())
            {
                return false;
            }
            else if (a.Count() == b.Count())
            {
                for (int i = 0; i < a.Count(); i++)
                {
                    if (a[i].X != b[i].X || a[i].Y != b[i].Y)
                    {
                        return false;
                    }

                }

            }

            return true;
        }

        private void bringContentToFront(UserControl currentControl, bool alreadyExisting = false)
        {
            if (!alreadyExisting)
            {
                activePanels.Add(currentControl);
            }

            contentPanel.Controls.Clear();

            foreach (var panel in activePanels)
            {
                panel.Dock = DockStyle.None;
                panel.Visible = false;
            }
            currentControl.Dock = DockStyle.Fill;
            currentControl.Visible = true;
            contentPanel.Controls.Add(currentControl);
        }

        private GearedValues<ObservablePoint> getHistogramFromChart(List<double> chart)
        {
            SortedDictionary<double, double> histogram = new SortedDictionary<double, double>();
            GearedValues<ObservablePoint> histogramChartModel = new GearedValues<ObservablePoint>();

            foreach (var point in chart)
            {
                if (histogram.ContainsKey(point))
                {
                    histogram[point]++;
                }
                else
                {
                    histogram[point] = 1;
                }
            }
            foreach (var item in histogram)
            {
                histogramChartModel.Add(new ObservablePoint(item.Key, item.Value));
            }

            return histogramChartModel;
        }

        private List<string> getFileFilters()
        {
            availableFileFilters = new List<string>();
            availableFileFilters.Add(Strings.Import_FileFilter_CSV);
            availableFileFilters.Add(Strings.Import_FileFilter_TXT);

            return availableFileFilters;
        }

    }

}
