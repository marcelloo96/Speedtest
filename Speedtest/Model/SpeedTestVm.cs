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
        /// The number of elements this list got represent the number of points we Draw each deltatime
        /// </summary>
        public List<double> recivedChartValues;
        public int keepRecords = 300;

        public SerialPort serialPort { get; set; }
        public bool IsReading { get; set; }
        /// <summary>
        /// Each element in 'listOfChars' represent a different channel.
        /// The number of element this chart must equal the sum of the ports
        /// </summary>
        public List<GearedValues<double>> listOfCharts { get; set; }
        public bool IsHot { get; set; }

        #endregion

        public SpeedTestVm(int numOfSeries, SerialPort serialPort)
        {
            this.serialPort = serialPort;
            ChartController.InitializeListOfCharts(this, numOfSeries);
            recivedChartValues = new List<double>();

        }
 
    }
}
