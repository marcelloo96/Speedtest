using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Geared;
using LiveCharts.WinForms;
using Speedtest.View.MeasureWindow;

namespace Speedtest.Controller
{
    public class ChartController
    {
        public static double tryparseTmp;
        public static CartesianChart SetDefaultChart(CartesianChart chart, SpeedTest model)
        {
            model.viewModel = new SpeedTestVm(model.numOfSeries, model.serialPort);

            chart.Hoverable = false;
            chart.DataTooltip = null;
            chart.Zoom = ZoomingOptions.X;
            chart.DisableAnimations = true;
            chart.AutoSize = true;

            var transparent = (Brush)new BrushConverter().ConvertFromString("#00FFFFFF");

            for (int i = 0; i < model.numOfSeries; i++)
            {
                chart.Series.Add(new GLineSeries
                {
                    Values = model.viewModel.listOfCharts[i],

                    DataLabels = false,
                    Fill = transparent,
                    LineSmoothness = 0,
                });
            }

            return chart;

        }

        public static string[] getlofasz()
        {
            string[] kurvaanyad = new string[300];
            for (int i = 0; i < kurvaanyad.Length; i++)
            {
                kurvaanyad[i] = i.ToString();
            }

            return kurvaanyad;
        }
        internal static void RefreshChartValues(SpeedTestVm speedTestModel, List<double> current)
        {
            int index = 0;
            foreach (var i in speedTestModel.listOfCharts)
            {
                if (index < speedTestModel.listOfCharts.Count() && index < current.Count())
                {

                    var first = i.DefaultIfEmpty(0).FirstOrDefault();
                    if (i.Count > speedTestModel.keepRecords - 1)
                    {
                        i.Remove(first);
                    }
                    if (i.Count < speedTestModel.keepRecords)
                    {
                        i.Add(current[index]);
                    }

                    index++;
                }


            }

            //speedTestModel.IsHot = current[0] > 0;
            speedTestModel.CurrentLecture = current[0];

        }
        internal static void printChartMonitor(ChartMonitor chartMonitorModel, string[] values)
        {
            var textbox = chartMonitorModel.TextBox;
            if (textbox.InvokeRequired)
            {
                textbox.Invoke((MethodInvoker)delegate ()
                {
                    printChartMonitor(chartMonitorModel, values);
                });
            }
            else
            {
                if (values != null)
                {
                    textbox.AppendText(String.Join(" ", values));
                }
            }
        }

        internal static void printChart(string[] importantValues, int numberOfPanelsDisplayed, MainFrame mainFrameModel)
        {
            if (importantValues != null && importantValues.Length >= numberOfPanelsDisplayed)
            {
                for (var i = 0; i < numberOfPanelsDisplayed; i++)
                {
                    double.TryParse(importantValues[i], out tryparseTmp);
                    mainFrameModel.gearedCharts[i].viewModel.recivedChartValues.Add(tryparseTmp);
                    ChartController.RefreshChartValues(mainFrameModel.gearedCharts[i].viewModel, mainFrameModel.gearedCharts[i].viewModel.recivedChartValues);
                }
            }
            else
            {
                for (var i = 0; i < numberOfPanelsDisplayed; i++)
                {
                    mainFrameModel.gearedCharts[i].viewModel.recivedChartValues.Add(double.NaN);
                    ChartController.RefreshChartValues(mainFrameModel.gearedCharts[i].viewModel, mainFrameModel.gearedCharts[i].viewModel.recivedChartValues);
                }
            }
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
