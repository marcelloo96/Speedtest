using LiveCharts.Defaults;
using LiveCharts.Geared;
using System.Collections.Generic;

namespace Speedtest.Model.ChartViewModels
{
    public class ScrollableViewModel
    {
        public ScrollableViewModel(List<double> singleChart, double deltaT)
        {
            var l = new List<ObservablePoint>();

            double T = 0;
            foreach (var point in singleChart)
            {
                l.Add(new ObservablePoint(T, point));
                T += deltaT;
            }

            Values = l.AsGearedValues().WithQuality(Quality.High);

            From = 0;
            To = T / 5;
        }
        public ScrollableViewModel(GearedValues<ObservablePoint> observableChart)
        {
            Values = observableChart;
            From = 0;
            To = observableChart[observableChart.Count / 5].X;
        }

        public GearedValues<ObservablePoint> Values { get; set; }
        public double From { get; set; }
        public double To { get; set; }

    }
}
