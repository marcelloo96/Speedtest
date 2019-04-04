using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Geared;
using LiveCharts.Helpers;
using LiveCharts.WinForms;
using Speedtest.Model;
using Speedtest.View.MeasureWindow;
using LiveCharts.Helpers;
using System.Diagnostics;

namespace Speedtest.Controller
{
    public class ChartController
    {
        public static double tryparseTmp;
        public static int lastInsertedXYValue = 0;
        public static CartesianChart SetDefaultChart(CartesianChart chart, SpeedTest model)
        {
            model.viewModel = new SpeedTestVm(model.numOfSeries, model.serialPort);

            //chart.Hoverable = true;
            //chart.DataTooltip = null;
            chart.Zoom = ZoomingOptions.X;
            chart.DisableAnimations = true;
            chart.AutoSize = true;

            for (int i = 0; i < model.numOfSeries; i++)
            {
                chart.Series.Add(new GLineSeries
                {
                    Values = model.viewModel.listOfCharts[i],
                    DataLabels = false,
                    Fill = Brushes.Transparent,
                    LineSmoothness = 0,

                });
            }
            
            return chart;
        }

        internal static CartesianChart InitializeXYChart(CartesianChart chart, XYChartUserControl model)
        {
            model.viewModel = new XYViewModel(model.deltaT, model.keepRecords);
            chart.Hoverable = true;
            chart.Zoom = ZoomingOptions.X;
            chart.DisableAnimations = true;
            chart.AutoSize = true;
            var transparent = Brushes.Transparent;


            chart.Series.Add(new GLineSeries
            {
                Values = model.viewModel.xyChartList,
                DataLabels = false,
                Fill = transparent,
                LineSmoothness = 0,

            });

            chart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Sections = new LiveCharts.Wpf.SectionsCollection
                {
                    new LiveCharts.Wpf.AxisSection
                    {
                        Value = 2000,
                        Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(248, 213, 72))
                    },
                    new LiveCharts.Wpf.AxisSection
                    {
                        //Label = "Good",
                        Value = 500,
                        SectionWidth = 1000,
                        Fill = new SolidColorBrush
                        {
                            Color = System.Windows.Media.Color.FromRgb(204,204,204),
                            Opacity = .4
                        }
                    },
                    new LiveCharts.Wpf.AxisSection
                    {
                        //Label = "Bad",
                        Value = 0,
                        SectionWidth = 500,
                        Fill = new SolidColorBrush
                        {
                            Color = System.Windows.Media.Color.FromRgb(254,132,132),
                            Opacity = .4
                        }
                    }
                }
            });

            return chart;
        }

        internal static void RefreshChartValues(SpeedTestVm speedTestModel, List<double> current)
        {
            try
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
            }
            catch (Exception e)
            {

                MessageBox.Show("refresh chartvalues" + e.Message);
            }


        }

        internal static void RefreshXYChartValues(XYViewModel viewModel, ObservablePoint current)
        {
            try
            {
                var i = viewModel.xyChartList;

                if (i.Count > viewModel.keepRecords - 1)
                {
                    var first = i.FirstOrDefault();
                    i.Remove(first);
                }
                if (i.Count < viewModel.keepRecords)
                {
                    var removable = viewModel.xyChartList.Where(p => p.X == current.X || p.Y == current.Y).ToList();
                    if (removable != null && removable.Count > 0)
                    {
                        foreach (var removablePoint in removable)
                        {
                            i.Remove(removablePoint);
                        }
                    }

                    i.Add(current);
                }

            }
            catch (Exception e)
            {

                MessageBox.Show("refresh chartvalues" + e.Message);
            }


        }
        internal static void RemoveAllPointsFromGeared(List<SpeedTest> gearedCharts)
        {
            foreach (var gearedChart in gearedCharts)
            {
                foreach (var singleChartList in gearedChart.viewModel.listOfCharts)
                {
                    singleChartList.Clear();
                }
            }

        }

        internal static void RemoveMonitorText(MainFrame mainFrame)
        {
            mainFrame.mmw.chartMonitor.TextBox.Clear();
        }
        internal static void printChartMonitor(ChartMonitorUserControl chartMonitorModel, double[] values)
        {
            var textbox = chartMonitorModel.TextBox;
            try
            {
                if (textbox.InvokeRequired)
                {
                    textbox.Invoke((MethodInvoker)delegate ()
                    {
                        //printChartMonitor(chartMonitorModel, values);
                        textbox.AppendText(String.Join(" ", values) + Environment.NewLine);
                    });
                }
                else
                {
                    if (values != null)
                    {
                        textbox.AppendText(String.Join(" ", values) + Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chartcontroller / Print Chart Monitor" + ex.Message);
            }
        }

        internal static void printGearedChart(double[] importantValues, int numberOfPanelsDisplayed, MainFrame mainFrameModel)
        {
            try
            {
                if (importantValues != null && importantValues.Length >= numberOfPanelsDisplayed)
                {
                    for (var i = 0; i < numberOfPanelsDisplayed; i++)
                    {
                        mainFrameModel.gearedCharts[i].viewModel.recivedChartValues.Add(importantValues[i]);
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
            catch (Exception ex)
            {
                MessageBox.Show("Chartcontroller / Print Chart" + ex.Message);
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

        internal static void printXYChart(XYChartUserControl xyChartUserControl, double[] sendingData, int numberOfIncomingData, int choosenXChannel = 0, int choosenYChannel = 0)
        {
            try
            {
                //ObservablePoint point;
                //if (sendingData != null && sendingData.Length == numberOfIncomingData && Math.Max(choosenXChannel, choosenYChannel) < sendingData.Length && Math.Min(choosenXChannel, choosenYChannel) >= 0)
                //{
                //    point = new ObservablePoint(sendingData[choosenXChannel], sendingData[choosenYChannel]);
                //}
                //else
                //{
                //    point = new ObservablePoint(double.NaN, double.NaN);
                //}
                double _tmpval = 0;
                if (sendingData != null && sendingData.Length >= numberOfIncomingData && Math.Max(choosenXChannel, choosenYChannel) < sendingData.Length && Math.Min(choosenXChannel, choosenYChannel) >= 0)
                {
                    _tmpval = sendingData[0];
                }

                Debug.WriteLine(_tmpval);
                //xyChartUserControl.viewModel.xyChartList.Add(new ObservablePoint(x, y));
                ChartController.RefreshXYChartValues(xyChartUserControl.viewModel, _tmpval);
            }
            catch (Exception e)
            {

                MessageBox.Show("XY" + e.Message);
            }


        }

        private static void RefreshXYChartValues(XYViewModel viewModel, double tmpval)
        {
            var i = viewModel.xyChartList;
            if (lastInsertedXYValue < viewModel.keepRecords)
            {
                i[lastInsertedXYValue++].Y = tmpval;
            }
            else
            {
                i = shiftListToTheLeft(i, viewModel);
                i[lastInsertedXYValue - 1].Y = tmpval;
            }

        }

        private static GearedValues<ObservablePoint> shiftListToTheLeft(GearedValues<ObservablePoint> list, XYViewModel viewModel)
        {
            list.Remove(list.First());
            list.Add(new ObservablePoint(Double.NaN, Double.NaN));
            double T = 0;
            for(int i=0; i<list.Count;i++)
            {
                list[i].X = (double) T;
                T += viewModel.deltaTime;
            }
            return list;
        }

    }
}
