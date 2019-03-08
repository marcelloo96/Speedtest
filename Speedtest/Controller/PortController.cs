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
        public int numberOfIncomingData;
        public SerialPort serialPort;
        Stopwatch timer;
        public string[] importantValues;
        public List<string> buffer;
        public int bytesToRead;

        public PortController(MainFrame model)
        {
            this.mainFrameModel = model;
            numberOfIncomingData = 1;
            deltaTime = 1000;
            regex = new Regex(@"-?[0-9]*(\s|\\r)");
            timer = new Stopwatch();
            buffer = new List<string>();
        }
        public void CreatePort()
        {
            mainFrameModel.serialPort = new PortModel(mainFrameModel);
            serialPort = mainFrameModel.serialPort;
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
            timer.Start();

            while (timer.ElapsedMilliseconds < deltaTime)
            {
                //Wait
            }
            timer.Stop();


            if (mainFrameModel.isRunning)
            {
                mainFrameModel.gearedCharts.ForEach(p => p.viewModel.recivedChartValues.Clear());
                string[] recivedSeparatedChartValues = recivedValueFormatter(serialPort.ReadExisting());

                string match = recognisedChartValues(recivedSeparatedChartValues);
                Debug.WriteLine(timer.ElapsedMilliseconds + " -> " + match);
                string[] importantValues = match.Split(' ');

                ChartController.printChartMonitor(mainFrameModel.mmw.chartMonitor, importantValues);
                ChartController.printChart(importantValues, numberOfPanelsDisplayed, mainFrameModel);


            }
            serialPort.DiscardInBuffer();
            timer.Reset();
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
                if (regex.Matches(i).Count == numberOfIncomingData)
                {
                    return i;

                }
            }

            //for (var i = chartValues.Length - 1; i > 0; i--) {
            //    if (regex.Matches(chartValues[i]).Count==numberOfIncomingData) {
            //        return chartValues[i];
            //    }
            //}
            return "";
        }

        internal void dataflowExtra()
        {
            while (mainFrameModel.isRunning && serialPort.IsOpen)
            {
                //timer.Start();
                //buffer.Clear();
                //  while (timer.ElapsedMilliseconds < deltaTime) {

                if (serialPort.IsOpen)
                {
                    if (serialPort.BytesToRead != 0)
                    {
                        if (serialPort.IsOpen)
                        {
                            importantValues = serialPort.ReadLine().Split(' ');

                        }

                    }
                }

                //if (serialPort.BytesToRead != 0)
                //{
                //    var bytesToRead = serialPort.BytesToRead;
                //    byte[] temp = new byte[bytesToRead];
                //    serialPort.Read(temp, 0, bytesToRead);
                //    var important = System.Text.Encoding.Default.GetString(temp);
                //    Debug.WriteLine(important);
                //    buffer.Add(important);
                //    importantValues = important.Split(' ');
                //}

                mainFrameModel.gearedCharts.ForEach(p => p.viewModel.recivedChartValues.Clear());
                ChartController.printChartMonitor(mainFrameModel.mmw.chartMonitor, importantValues);
                ChartController.printChart(importantValues, numberOfPanelsDisplayed, mainFrameModel);
            }

            // timer.Reset();


            // }
        }

    }

}
