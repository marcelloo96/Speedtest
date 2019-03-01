using Speedtest.Model;
using Speedtest.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Speedtest.Controller
{
    public class PortController
    {
        private MainFrame mainFrameModel;
        public double tryparseTmp;
        public int deltaTime;
        public Regex regex;
        public int minNumberOfIncomingData;

        public PortController(MainFrame model)
        {
            this.mainFrameModel = model;
            deltaTime = 1;
            regex = new Regex(@"-?[0-9]*(\s|\\r)");
            minNumberOfIncomingData = (int)mainFrameModel.ChannelsElement.EditValue;

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
            if (mainFrameModel.isRunning /*&& deltaTime != 0*/)
            {
                mainFrameModel.gearedCharts.ForEach(p => p.viewModel.recivedChartValues.Clear());
                string[] chartValues = recivedValueFormatter(mainFrameModel.serialPort.ReadExisting());
                int numberOfFormattedRecivedCharValues = chartValues.Length;
                Debug.WriteLine(numberOfFormattedRecivedCharValues);

                string match = recognisedChartValues(chartValues);
                string[] importantValues = match.Split(' ');

                ChartController.printChartMonitor(mainFrameModel.mmw.chartMonitor, importantValues);
                //We cant add more channel to the panel than the number of the incoming datas we have
                int maxNumberChannels = Math.Min(minNumberOfIncomingData, importantValues.Length);


                if (importantValues.Length > minNumberOfIncomingData)
                {
                    for (var i = 0; i < minNumberOfIncomingData; i++)
                    {
                        double.TryParse(importantValues[i], out tryparseTmp);
                        mainFrameModel.gearedCharts[i].viewModel.recivedChartValues.Add(tryparseTmp);
                        ChartController.RefreshChartValues(mainFrameModel.gearedCharts[i].viewModel, mainFrameModel.gearedCharts[i].viewModel.recivedChartValues);
                    }
                }

                System.Threading.Thread.Sleep(1000);


            }

        }

        public string[] recivedValueFormatter(string recived)
        {
            if (String.IsNullOrWhiteSpace(recived))
            {
                return new string[] { };
            }
            else
            {
                return recived.Split('\n');
            }

        }

        public string recognisedChartValues(string [] chartValues) {
            foreach (var i in chartValues)
            {
                if (regex.Matches(i).Count >= minNumberOfIncomingData)
                {
                    return i;

                }
            }
            return "";
        }

    }
}
