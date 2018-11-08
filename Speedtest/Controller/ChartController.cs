using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Geared;
using LiveCharts.WinForms;

namespace Speedtest.Controller
{
    public static class ChartController
    {
        public static CartesianChart SetDefaultChart(CartesianChart chart, SpeedTestVm viewModel)
        {
            chart.Hoverable = false;
            chart.DataTooltip = null;
            chart.Zoom = ZoomingOptions.X;
            var converter = new BrushConverter();
            chart.Series.Add(new GLineSeries
            {
                Values = viewModel.Chart1,
                DataLabels = false,
                Fill = (Brush)converter.ConvertFromString("#00FFFFFF"),
                LineSmoothness = 0
            });
            chart.Series.Add(new GLineSeries
            {
                Values = viewModel.Chart2,
                DataLabels = false,
                Fill = (Brush)converter.ConvertFromString("#00FFFFFF"),
                LineSmoothness = 0
            });
            chart.DisableAnimations = true;
            return chart;

        }



        internal static void refreshChartValues(SpeedTestVm model, List<double> current)
        {
            var first = model.Chart1.DefaultIfEmpty(0).FirstOrDefault();
            if (model.Chart1.Count > model.keepRecords - 1) model.Chart1.Remove(first);
            if (model.Chart1.Count < model.keepRecords) model.Chart1.Add(current[0]);

            if (current.Count() ==2) {
                first = model.Chart2.DefaultIfEmpty(0).FirstOrDefault();
                if (model.Chart2.Count > model.keepRecords - 1) model.Chart2.Remove(first);
                if (model.Chart2.Count < model.keepRecords) model.Chart2.Add(current[1]);

            }
            model.IsHot = current[0] > 0;
            model.Count = model.Chart1.Count;
            model.CurrentLecture = current[0];

        }
    }
}
