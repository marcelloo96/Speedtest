using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Geared;
using LiveCharts.WinForms;
using Speedtest.Model;
using Speedtest.View.MeasureWindow;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;

namespace Speedtest.Controller
{
    public class ChartController
    {
        public static double tryparseTmp;
        public static int lastInsertedXYValue = 0;
        public static readonly bool multipleChart = false;
        public static double lastValueForEdgeDetecting = double.NaN;

        internal static CartesianChart InitializeDefaultChart(CartesianChart chart, DefaultChartUserControl model)
        {
            model.viewModel = new DefaultChartViewModel(model.deltaT, model.keepRecords);
            chart.Hoverable = false;
            chart.Zoom = ZoomingOptions.Y;
            chart.DisableAnimations = true;
            chart.AutoSize = true;
            chart.DataTooltip = null;
            var transparent = Brushes.Transparent;

            chart.Series.Add(new GLineSeries
            {
                Values = model.viewModel.values,
                DataLabels = false,
                Fill = transparent,
                LineSmoothness = 0,

            });
            chart.Series.Add(new GLineSeries
            {
                Values = model.viewModel.RecordValues,
                DataLabels = false,
                LineSmoothness = 0,

            });
            chart.Series.Add(new GLineSeries
            {
                Values = model.viewModel.MeanValues,
                Fill = Brushes.Transparent,
                DataLabels = false,
                LineSmoothness = 0,

            });
            chart.Series.Add(new GLineSeries
            {
                Values = model.viewModel.EdgeDetectingLine,
                Fill = Brushes.Transparent,
                DataLabels = false,
                LineSmoothness = 0,

            });

            //chart.AxisY.Add(new LiveCharts.Wpf.Axis
            //{
            //    MinValue = model.viewModel.values.Min(p => p.Y),
            //    MaxValue = model.viewModel.values.Max(p => p.Y),

            //});

            return chart;
        }

        internal static void RefreshXYChartValues(DefaultChartViewModel viewModel, ObservablePoint current)
        {
            try
            {
                var i = viewModel.values;

                if (i.Count > viewModel.keepRecords - 1)
                {
                    var first = i.FirstOrDefault();
                    i.Remove(first);
                }
                if (i.Count < viewModel.keepRecords)
                {
                    var removable = viewModel.values.Where(p => p.X == current.X || p.Y == current.Y).ToList();
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

                //MessageBox.Show("refresh chartvalues" + e.Message);
            }


        }
        internal static void RemoveAllPointsFromGeared(GearedValues<DefaultChartUserControl> defaultCharts)
        {
            foreach (var chart in defaultCharts)
            {
                chart.viewModel.values.Clear();
                chart.viewModel.setValuesInicialState(chart.viewModel);
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
                //MessageBox.Show("Chartcontroller / Print Chart Monitor" + ex.Message);
            }
        }

        internal static void printGearedChart(MainFrame mainFrameModel, int numberOfPanelsDisplayed, double[] importantValues)
        {
            try
            {
                if (importantValues != null)
                {
                    var correctLenght = Math.Min(importantValues.Length, numberOfPanelsDisplayed);
                    for (var i = 0; i < correctLenght; i++)
                    {
                        ChartController.RefreshDefaultChartValues(mainFrameModel, mainFrameModel.defaultCharts[i].viewModel, importantValues[i], multipleChart);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Chartcontroller / Print Chart" + ex.Message);
            }

        }

        internal static void printDefaultChart(MainFrame mainframe, DefaultChartUserControl defaultChartUserControl, double[] sendingData)
        {
            try
            {
                double _tmpval = double.NaN;
                if (sendingData != null && sendingData.Length > mainframe.selectIncomingLiveChannelsElementValue)
                {
                    _tmpval = sendingData[mainframe.selectIncomingLiveChannelsElementValue];
                }
                else
                {
                    MessageBox.Show(Strings.Error_ChannelNetExistOrFound);
                    mainframe.StartStopButton.PerformClick();
                }



                ChartController.RefreshDefaultChartValues(mainframe, defaultChartUserControl.viewModel, _tmpval);
            }
            catch (Exception e)
            {

                //MessageBox.Show("XY" + e.Message);
            }


        }

        private static void RefreshDefaultChartValues(MainFrame mainFrame, DefaultChartViewModel viewModel, double tmpval, bool isSingleGraph = true)
        {
            var values = viewModel.values;
            var rec = viewModel.RecordValues;
            var edge = viewModel.EdgeDetectingLine;
            var mean = viewModel.MeanValues;
            bool recording = mainFrame.Recording;
            double avg = double.NaN;

            if (MainFrame.meanValueIsOn && isSingleGraph)
            {
                avg = values.Concat(rec).Where(p => double.IsNaN(p.Y) == false).Select(p => p.Y).Average();
                mainFrame.meanValueLabelCaption = Strings.Global_MeanValue + avg.ToString("F2");
            }

            if (lastInsertedXYValue < viewModel.keepRecords)
            {
                if (recording)
                {
                    values[lastInsertedXYValue++].Y = double.NaN;
                    rec[lastInsertedXYValue++].Y = tmpval;
                }
                else
                {
                    values[lastInsertedXYValue++].Y = tmpval;
                    rec[lastInsertedXYValue++].Y = double.NaN;
                }

                if (MainFrame.meanValueIsOn && isSingleGraph)
                {

                    mean[lastInsertedXYValue++].Y = avg;
                }
                else
                {
                    mean[lastInsertedXYValue++].Y = double.NaN;
                }

                if (MainFrame.edgeDetecting && isSingleGraph)
                {
                    for (int i = 0; i < edge.Count(); i++)
                    {
                        edge[i].Y = mainFrame.tresholdElementValue;
                    }
                }
                else
                {
                    edge[lastInsertedXYValue++].Y = double.NaN;
                }

            }
            else
            {
                if (recording)
                {
                    values = PopFirstAndAddNewCorrectXValuedPoint(values, viewModel);
                    values[lastInsertedXYValue - 1].Y = double.NaN;

                    rec = PopFirstAndAddNewCorrectXValuedPoint(rec, viewModel);
                    rec[lastInsertedXYValue - 1].Y = tmpval;
                }
                else
                {
                    values = PopFirstAndAddNewCorrectXValuedPoint(values, viewModel);
                    values[lastInsertedXYValue - 1].Y = tmpval;

                    rec = PopFirstAndAddNewCorrectXValuedPoint(rec, viewModel);
                    rec[lastInsertedXYValue - 1].Y = double.NaN;
                }

                if (MainFrame.meanValueIsOn && isSingleGraph)
                {
                    mean = PopFirstAndAddNewCorrectXValuedPoint(mean, viewModel);
                    mean[lastInsertedXYValue - 1].Y = avg;
                }
                else
                {
                    mean = PopFirstAndAddNewCorrectXValuedPoint(mean, viewModel);
                    mean[lastInsertedXYValue - 1].Y = double.NaN;
                }

                if (MainFrame.edgeDetecting && isSingleGraph)
                {
                    printEdgeDetectedPeriodTime(mainFrame, tmpval);

                    edge = PopFirstAndAddNewCorrectXValuedPoint(edge, viewModel);
                    for (int i = 0; i < edge.Count(); i++)
                    {
                        edge[i].Y = mainFrame.tresholdElementValue;
                    }

                    lastValueForEdgeDetecting = tmpval;
                }
                else
                {
                    edge = PopFirstAndAddNewCorrectXValuedPoint(edge, viewModel);
                    edge[lastInsertedXYValue - 1].Y = double.NaN;
                }



            }

        }

        private static void printEdgeDetectedPeriodTime(MainFrame mainFrame, double tmpval)
        {
            var timer = mainFrame.timer;
            if (mainFrame.edgeTypeElementValue == Strings.Measure_EdgeType_Rising)
            {
                if (lastValueForEdgeDetecting < MainFrame.Treshold && tmpval > MainFrame.Treshold)
                {
                    if (timer.IsRunning)
                    {
                        timer.Stop();
                        mainFrame.periodTimeCaption = Strings.Measure_PeriodTimeLabel + timer.ElapsedMilliseconds + "ms";
                        timer.Restart();
                    }
                    else
                    {
                        timer.Start();
                    }
                }

            }
            else if (mainFrame.edgeTypeElementValue == Strings.Measure_EdgeType_Fall)
            {
                if (lastValueForEdgeDetecting > MainFrame.Treshold && tmpval < MainFrame.Treshold)
                {
                    if (timer.IsRunning)
                    {
                        timer.Stop();
                        mainFrame.periodTimeCaption = Strings.Measure_PeriodTimeLabel + timer.ElapsedMilliseconds + "ms";
                        timer.Restart();
                    }
                    else
                    {
                        timer.Start();
                    }
                }

            }
        }

        private static GearedValues<ObservablePoint> PopFirstAndAddNewCorrectXValuedPoint(GearedValues<ObservablePoint> list, DefaultChartViewModel viewModel)
        {
            list.Remove(list.First());
            var nextT = list.LastOrDefault().X + viewModel.deltaTime;
            list.Add(new ObservablePoint(nextT, Double.NaN));

            return list;
        }

    }
}
