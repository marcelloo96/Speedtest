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
        public int numberOfPanelsDisplayed;
        Stopwatch timer;

        public PortController(MainFrame model)
        {
            this.mainFrameModel = model;
            deltaTime = 1000;
            regex = new Regex(@"-?[0-9]*(\s|\\r)");
            timer = new System.Diagnostics.Stopwatch();

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
                    numberOfPanelsDisplayed = (int)mainFrameModel.ChannelsElement.EditValue;
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
            if (timer.IsRunning)
            {
                while (timer.ElapsedMilliseconds < deltaTime)
                {
                    //Wait
                }
                timer.Stop();
                timer.Reset();
            }
            if (mainFrameModel.isRunning)
            {
                mainFrameModel.gearedCharts.ForEach(p => p.viewModel.recivedChartValues.Clear());
                string[] chartValues = recivedValueFormatter(mainFrameModel.serialPort.ReadExisting());
                int numberOfFormattedRecivedCharValues = chartValues.Length;
                Debug.WriteLine(numberOfFormattedRecivedCharValues);

                string match = recognisedChartValues(chartValues);
                string[] importantValues = match.Split(' ');

                ChartController.printChartMonitor(mainFrameModel.mmw.chartMonitor, importantValues);

                if (importantValues.Length >= numberOfPanelsDisplayed)
                {
                    for (var i = 0; i < numberOfPanelsDisplayed; i++)
                    {
                        double.TryParse(importantValues[i], out tryparseTmp);
                        mainFrameModel.gearedCharts[i].viewModel.recivedChartValues.Add(tryparseTmp);
                        ChartController.RefreshChartValues(mainFrameModel.gearedCharts[i].viewModel, mainFrameModel.gearedCharts[i].viewModel.recivedChartValues);
                    }
                }
                timer.Start();

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

        public string recognisedChartValues(string[] chartValues)
        {
            foreach (var i in chartValues)
            {
                if (regex.Matches(i).Count >= numberOfPanelsDisplayed)
                {
                    return i;

                }
            }
            return "";
        }

    }
}
