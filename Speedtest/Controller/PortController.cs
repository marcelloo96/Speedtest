using Speedtest.Model;
using Speedtest.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Speedtest.Controller
{
    public class PortController
    {
        private MainFrame mainFrameModel;
        public double tryparseTmp;
        public PortController(MainFrame model) {
            this.mainFrameModel = model;

        }
        public void CreatePort()
        {
            mainFrameModel.serialPort = new PortModel(mainFrameModel);
        }
        public void DoTheConnection()
        {
            try
            {
                mainFrameModel.serialPort.Open();
                if (mainFrameModel.serialPort.IsOpen)
                {
                    mainFrameModel.IsPortConnectedStatusBarLabel.Caption = StringConstants.portStatusConnected;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void dataFlow(object sender, EventArgs e)
        {
            mainFrameModel.gearedCharts.ForEach(p => p.viewModel.recivedChartValues.Clear());

            var recived = mainFrameModel.serialPort.ReadExisting();
            string[] chartValues = recived.Split('\n');
            int a = chartValues.Length;
            Debug.WriteLine(a);

            string[] importantValues = chartValues[5].Split(' ');
            
            //We cant add more channel to the panel than the number of the incoming data
            int maxNumberChannels = Math.Min((int)mainFrameModel.ChannelsElement.EditValue, importantValues.Length);
                      

            if (importantValues.Length > (int)mainFrameModel.ChannelsElement.EditValue)
            {
                for (var i = 0; i < (int)mainFrameModel.ChannelsElement.EditValue; i++)
                {
                    double.TryParse(importantValues[i], out tryparseTmp);
                    //mainFrameModel.gearedChart.viewModel.recivedChartValues.Add(tryparseTmp);
                    mainFrameModel.gearedCharts[i].viewModel.recivedChartValues.Add(tryparseTmp);
                    ChartController.RefreshChartValues(mainFrameModel.gearedCharts[i].viewModel, mainFrameModel.gearedCharts[i].viewModel.recivedChartValues);
                }
            }
            
            System.Threading.Thread.Sleep(1000);
        }
        
    }
}
