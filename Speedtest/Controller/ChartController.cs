using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            chart.Series.Add(new GLineSeries
            {
                Values = viewModel.Values,
                DataLabels = false
            });
            chart.DisableAnimations = true;
            return chart;
            
        }
    }
}
