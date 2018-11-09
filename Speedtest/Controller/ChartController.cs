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
        public static CartesianChart SetDefaultChart(CartesianChart chart, SpeedTest model)
        {
            model.viewModel = new SpeedTestVm(model.numOfSeries, model.serialPort);

            chart.Hoverable = false;
            chart.DataTooltip = null;
            chart.Zoom = ZoomingOptions.X;
            chart.DisableAnimations = true;

            var transparent = (Brush)new BrushConverter().ConvertFromString("#00FFFFFF");

            for (int i = 0; i < model.numOfSeries; i++) {
                chart.Series.Add(new GLineSeries
                {
                    Values = model.viewModel.listOfCharts[i],
                    DataLabels = false,
                    Fill = transparent,
                    LineSmoothness = 0
                });
            }

            return chart;

        }


        internal static void RefreshChartValues(SpeedTestVm model, List<double> current)
        {
            int index = 0;
            foreach (var i in model.listOfCharts) {
                if (index < model.listOfCharts.Count() && index<current.Count()) {

                    var first = i.DefaultIfEmpty(0).FirstOrDefault();
                    if (i.Count > model.keepRecords - 1) i.Remove(first);
                    if (i.Count < model.keepRecords) i.Add(current[index]);

                    index++;
                }


            }

            model.IsHot = current[0] > 0;
            model.CurrentLecture = current[0];

        }

        /// <summary>
        /// The model's 'listOfCharts' List will contain the same amount of element as the model's 'numOfSeries' value is.  
        /// </summary>
        /// <param name="model"></param>
        internal static void InitializeListOfCharts(SpeedTestVm model, int numOfSeries)
        {
            model.listOfCharts = new List<GearedValues<double>>();
            for (int i = 0; i < numOfSeries; i++)
            {
                model.listOfCharts.Add(new GearedValues<double>().WithQuality(Quality.High));
            }
        }
    }
}
