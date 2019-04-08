using Speedtest.Controller;
using System;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using System.Collections.Generic;
using Speedtest.View.MeasureWindow;
using System.Diagnostics;
using System.Text;
using Speedtest.Controller.TabControllers;
using LiveCharts.Geared;

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
        public double deltaTime;
        public double[] printingData;
        DataCollector dc;
        public static int numberOfPanels = 1;        
        private List<UserControl> activePanels;
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


        private void printTo(string currentlyArrived)
        {
            try
            {
                if (isRunning)
                {
                    Debug.WriteLine(currentlyArrived);
                    printingData = Array.ConvertAll(currentlyArrived.Split(' '), Double.Parse);

                    if (Recording)
                    {
                        csvBuffer.AppendLine(String.Join(",", printingData));
                    }
                    if (useLinearity)
                    {
                        printingData = calculateLinearValue(printingData, sensitivity, zeroValue);
                    }
                    //gearedCharts.ForEach(p => p.viewModel.recivedChartValues.Clear());

                    if (DisplayModeElementValue == Strings.MeasureTab_DisplayMode_Chart)
                    {
                        ChartController.printGearedChart(printingData, numberOfPanels, this, Recording);
                    }
                    else if (DisplayModeElementValue == Strings.MeasureTab_DisplayMode_Monitor)
                    {
                        ChartController.printChartMonitor(mmw.chartMonitor, printingData);
                    }
                    else if (DisplayModeElementValue == Strings.MeasureTab_DisplayMode_XY)
                    {
                        ChartController.printDefaultChart(mmw.xyChartUserControl, printingData, numberOfIncomingDataEditValue, Recording);
                        //ChartController.printGearedChart(sendingData, numberOfPanels, this);
                    }
                }


            }
            catch (Exception e)
            {

                MessageBox.Show("printto" + e.Message);
            }


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


    }

}
