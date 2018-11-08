using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LiveCharts.Geared;
using System.IO.Ports;
using System.Diagnostics;
using Speedtest.Controller;
using System.Collections.Generic;

namespace Speedtest
{
    public class SpeedTestVm
    {
        #region datafields

        /// <summary>
        /// revicedChartValue is the values that given by the 'Datarecived' action listener
        /// </summary>
        private List<double> recivedChartValues;
        int tmp = 0;
        double tryparseTmp;
        public int keepRecords = 300;

        public SerialPort serialPort { get; set; }
        public bool IsReading { get; set; }
        /// <summary>
        /// Each element in 'listOfChars' represent a different channel.
        /// The number of element this chart must equal the sum of the ports
        /// </summary>
        public List<GearedValues<double>> listOfCharts { get; set; }
        public double Count { get; set; }
        public double CurrentLecture { get; set; }
        public bool IsHot { get; set; }
        public int numOfSeries;
        System.IO.StreamWriter file;
        #endregion

        public SpeedTestVm(int numOfSeries)
        {
            this.numOfSeries = numOfSeries;
            listOfCharts = new List<GearedValues<double>>();
            recivedChartValues = new List<double>();

            for (int i=0; i<numOfSeries; i++) {
                listOfCharts.Add(new GearedValues<double>().WithQuality(Quality.High));
            }
            file = new System.IO.StreamWriter(@"D:\Egyetem\VII. Félév\Szakdolgozat\ArduinoCode\sender\asd.txt", true);

        }

        public void Clear()
        {
            foreach (var i in listOfCharts) {
                i.Clear();

            }
        }

        public void Read()
        {

            serialPort.DataReceived += (s, e) =>
            {
                tmp++;

                if (IsReading)
                {
                    recivedChartValues.Clear();
                    var recived = serialPort.ReadLine();
                    Debug.WriteLine(recived);

                    file.WriteLine(recived);

                    string[] chartValues = recived.Split(' ');

                    for (var i = 0; i < chartValues.Length; i++)
                    {
                        double.TryParse(chartValues[i], out tryparseTmp);
                        recivedChartValues.Add(tryparseTmp);
                    }

                    ChartController.refreshChartValues(this, recivedChartValues);
                }


            };

        }

        public void Stop()
        {
            IsReading = false;
            file.Close();
        }

    }
}
