 using DevExpress.XtraBars.Docking;
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
        public SpeedTest gearedChart;
        public List<SpeedTest> gearedCharts;
        public SerialPort serialPort;

        public MainMeasureWindow(MainFrame model)
        {
            serialPort = model.serialPort;
            mainFrameModel = model;
            gearedChart = model.gearedChart;
            gearedCharts = model.gearedCharts;
            InitializeComponent();
            InitialState();
        }

        public void InitialState() {
            if (!String.IsNullOrWhiteSpace((string)mainFrameModel.SelectedPortElement.EditValue))
            {
                try
                {
                    //MeasureTabController.ConnectionManager(mainFrameModel);

                    if (mainFrameModel.connectedState)
                    {
                        //CONNECTING
                        createCharts();
                        //the Connection Manager already swapped the 'connectedState' value

                        int height = this.Size.Height / (int)mainFrameModel.ChannelsElement.EditValue;
                        for (int i = 0; i < (int)mainFrameModel.ChannelsElement.EditValue; i++)
                        {

                            DockPanel tmpPanel = new DockPanel
                            {
                                Text = "Chart " + i
                            };
                            ControlContainer tmpPanel_Container = new ControlContainer();

                            tmpPanel_Container.Controls.Add(gearedCharts[i]);
                            tmpPanel.Height = height;
                            tmpPanel.Controls.Add(tmpPanel_Container);

                            gearedChartUserControl.dockManager.AddPanel(DockingStyle.Top, tmpPanel);

                        }
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
            for (int i = 0; i < (int)mainFrameModel.ChannelsElement.EditValue; i++)
            {
                gearedChart = new SpeedTest(serialPort, (int)mainFrameModel.ChannelsElement.EditValue)
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
    }


}
