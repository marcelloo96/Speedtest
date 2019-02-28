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
            if (mainFrameModel.isRunning) {
                mainFrameModel.gearedCharts.ForEach(p => p.viewModel.recivedChartValues.Clear());

                var recived = mainFrameModel.serialPort.ReadExisting();

                string[] chartValues = recivedValueFormatter(recived);
                int numberOfFormattedRecivedCharValues = chartValues.Length;
                Debug.WriteLine(numberOfFormattedRecivedCharValues);
                string[] importantValues;
                if (numberOfFormattedRecivedCharValues < 0)
                {
                    importantValues = new string[] { };
                }
                else
                {
                    if (numberOfFormattedRecivedCharValues > 100)
                    {
                        //If the sampling frequency greater than 100Hz, then the first datasets may damaged or deficient.
                        importantValues = chartValues[10].Split(' ');
                    }
                    else
                    {
                        importantValues = chartValues[0].Split(' ');
                    }

                }


                //We cant add more channel to the panel than the number of the incoming datas we have
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

        public string[] recivedValueFormatter(string recived) {
            if (String.IsNullOrWhiteSpace(recived))
            {
                return new string[] { };
            }
            else {
                return recived.Split('\n');
            }
            
        }
    }
}
