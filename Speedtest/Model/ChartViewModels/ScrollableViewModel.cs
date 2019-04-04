using LiveCharts.Defaults;
using LiveCharts.Geared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedtest.Model.ChartViewModels
{
    public class ScrollableViewModel
    {
        public ScrollableViewModel(List<double> singleChart, double deltaT)
        {
            var l = new List<ObservablePoint>();

            double T = 0;
            foreach (var point in singleChart) {
                l.Add(new ObservablePoint(T, point));
                T += deltaT;
            }


            Formatter = x => ((double)x * deltaT).ToString();

            Values = l.AsGearedValues().WithQuality(Quality.High);

            From = 0;
            To = singleChart.Count();
        }

        public object Mapper { get; set; }
        public GearedValues<ObservablePoint> Values { get; set; }
        public double From { get; set; }
        public double To { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}
