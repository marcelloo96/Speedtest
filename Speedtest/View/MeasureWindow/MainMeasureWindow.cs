 using DevExpress.XtraBars.Docking;
using LiveCharts.Geared;
using Speedtest.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Speedtest.View.MeasureWindow
{
    public partial class MainMeasureWindow : UserControl
    {
        public MainFrame mainFrameModel;
        public DefaultChartUserControl gearedChart;
        public GearedValues<DefaultChartUserControl> gearedCharts;
        public SerialPort serialPort;
        public int numberOfPanelsDisplayed;
        public DefaultChartUserControl xyChartUserControl;
        public ChartMonitorUserControl chartMonitor;

        public MainMeasureWindow(MainFrame model)
        {
            serialPort = model.serialPort;
            mainFrameModel = model;
            gearedChart = model.defaultChart;
            gearedCharts = model.defaultCharts;
            numberOfPanelsDisplayed= mainFrameModel.numberOfChannelsElementValue;
            InitializeComponent();
            InitialState();
            xyChartUserControl = new DefaultChartUserControl(model.keepRecordsElementValue, model.deltaTime);
            chartMonitor = new ChartMonitorUserControl();
            Controls.Add(xyChartUserControl);
            Controls.Add(chartMonitor);

        }

        public void InitialState() {
            if (!String.IsNullOrWhiteSpace(mainFrameModel.selectedPortElementValue))
            {
                try
                {
                    //MeasureTabController.ConnectionManager(mainFrameModel);

                    if (mainFrameModel.connectedState)
                    {
                        //CONNECTING
                        createCharts();
                        //the Connection Manager already swapped the 'connectedState' value

                        int height = this.Size.Height / numberOfPanelsDisplayed;
                        //gearedChartUserControl.Width = mainFrameModel.contentPanel.Width * 3 / 4;
                        for (int i = 0; i < numberOfPanelsDisplayed; i++)
                        {

                            DockPanel tmpPanel = new DockPanel
                            {
                                Text = "Chart " + i,
                                AutoScaleMode=AutoScaleMode.Inherit
                            };
                            ControlContainer tmpPanel_Container = new ControlContainer();
                            var currentChart = gearedCharts[i];
                            tmpPanel_Container.Controls.Add(currentChart);
                            
                            tmpPanel.Height = height;
                            tmpPanel.Controls.Add(tmpPanel_Container);


                            gearedChartUserControl.dockManager.AddPanel(DockingStyle.Top, tmpPanel);

                        }
                        resizeControls(mainFrameModel.contentPanel.Height, mainFrameModel.contentPanel.Width);
                    }
                    else
                    {
                        gearedChartUserControl.Controls.Clear();
                        gearedCharts.Clear();
                        gearedChartUserControl.dockManager.Clear();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void createCharts()
        {
            for (int i = 0; i < numberOfPanelsDisplayed; i++)
            {
                gearedChart = new DefaultChartUserControl(mainFrameModel.keepRecordsElementValue,mainFrameModel.deltaTime)
                {
                    Dock = DockStyle.Fill
                };
                gearedCharts.Add(gearedChart);
            }
        }

        public void deleteControls() {
            this.Controls.Clear();
            gearedCharts.Clear();
            gearedChartUserControl.dockManager.Clear();

        }

        internal void resizeControls(int height, int width)
        {
            var newHeight = height / numberOfPanelsDisplayed;
            var panels = gearedChartUserControl.dockManager.Panels;
            //splitContainerControl.SplitterPosition = width * 3 / 4;

            
            for (int i = 0; i < panels.Count(); i++) {
                panels[i].Height = newHeight;
            }
        }

    }


}
