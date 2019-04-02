using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Geared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedtest.Model
{
    public class XYViewModel
    {
        public GearedValues<ObservablePoint> xyChartList { get; set; }
        public int keepRecords = 100;
        public double deltaTime = 1;


        public XYViewModel(double deltaT, int keepRecords)
        {
            xyChartList = new GearedValues<ObservablePoint>().WithQuality(Quality.High);
            double previousDeltaT = 0;
            this.keepRecords = keepRecords;
            this.deltaTime = deltaT;
            for (int i = 0; i < keepRecords; i++)
            {
                xyChartList.Add(new ObservablePoint((double)(previousDeltaT + deltaT), Double.NaN));
                previousDeltaT += deltaT;
            }

        }
    }
    public class XYPoint
    {
        public double x;
        public double y;

        public XYPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
