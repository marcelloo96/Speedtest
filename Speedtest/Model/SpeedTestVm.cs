using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LiveCharts.Geared;
using System.IO.Ports;
using System.Diagnostics;

namespace Speedtest
{
    public class SpeedTestVm
    {
        private double _trend;
        private SerialPort serialPort;
        string recivedData;
        double tryparseTmp;
        public int keepRecords = 500;

        public bool IsReading { get; set; }
        public GearedValues<double> Values { get; set; }
        public double Count { get; set; }
        public double CurrentLecture { get; set; }
        public bool IsHot { get; set; }

        public SpeedTestVm()
        {
            Values = new GearedValues<double>().WithQuality(Quality.High);

        }

        public void Stop()
        {
            IsReading = false;
        }

        public void Clear()
        {
            Values.Clear();
        }

        public void Read(SerialPort serialPort)
        {
            this.serialPort = serialPort;

            (new Thread(() => {
                if (IsReading) return;

                IsReading = true;

                serialPort.DataReceived += (s, e) =>
                {

                    recivedData = serialPort.ReadLine();
                    if (IsReading)
                    {

                        double.TryParse(recivedData, out tryparseTmp);
                        _trend = tryparseTmp;
                        
                        var first = Values.DefaultIfEmpty(0).FirstOrDefault();
                        if (Values.Count > keepRecords - 1) Values.Remove(first);
                        if (Values.Count < keepRecords) Values.Add(_trend);
                        IsHot = _trend > 0;
                        Count = Values.Count;
                        CurrentLecture = _trend;
                    }
                };                
                
            })).Start();
           
        }

    }
}
