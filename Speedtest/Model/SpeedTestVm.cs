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
        private List<double> recivedChartValues;
        int tmp = 0;
        double tryparseTmp;
        public int keepRecords = 300;

        public SerialPort serialPort { get; set; }
        public bool IsReading { get; set; }
        public GearedValues<double> Chart1 { get; set; }
        public GearedValues<double> Chart2 { get; set; }
        public double Count { get; set; }
        public double CurrentLecture { get; set; }
        public bool IsHot { get; set; }
        System.IO.StreamWriter file;

        public SpeedTestVm()
        {
            recivedChartValues = new List<double>();
            Chart1 = new GearedValues<double>().WithQuality(Quality.High);
            Chart2 = new GearedValues<double>().WithQuality(Quality.High);
            file = new System.IO.StreamWriter(@"D:\Egyetem\VII. Félév\Szakdolgozat\ArduinoCode\sender\asd.txt", true);

        }

        public void Clear()
        {
            Chart1.Clear();
            Chart2.Clear();
        }

        public void Read()
        {

            //(new Thread(() =>
            //{
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

            //})).Start();


        }

        public void Stop()
        {
            IsReading = false;
            file.Close();
        }

        /*public void refreshChartValues() {
            var first = Values.DefaultIfEmpty(0).FirstOrDefault();
            if (Values.Count > keepRecords - 1) Values.Remove(first);
            if (Values.Count < keepRecords) Values.Add(_trend);
            IsHot = _trend > 0;
            Count = Values.Count;
            CurrentLecture = _trend;
        }*/
    }
}
