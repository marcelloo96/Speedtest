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

        internal static CartesianChart InitializeDefaultChart(CartesianChart chart, DefaultChartUserControl model)
        {
            model.viewModel = new DefaultChartViewModel(model.deltaT, model.keepRecords);
            chart.Hoverable = true;
            //chart.Zoom = ZoomingOptions.X;
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

            //chart.AxisY.Add(new LiveCharts.Wpf.Axis {
            //    MinValue = model.viewModel.values.Min(p=>p.Y),
            //    MaxValue= model.viewModel.values.Max(p => p.Y),

            //});
            //chart.AxisY.Add(new LiveCharts.Wpf.Axis
            //{
            //    Sections = new LiveCharts.Wpf.SectionsCollection
            //    {
            //        new LiveCharts.Wpf.AxisSection
            //        {
            //            Value = 2000,
            //            Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(248, 213, 72))
            //        },
            //        new LiveCharts.Wpf.AxisSection
            //        {
            //            //Label = "Good",
            //            Value = 500,
            //            SectionWidth = 1000,
            //            Fill = new SolidColorBrush
            //            {
            //                Color = System.Windows.Media.Color.FromRgb(204,204,204),
            //                Opacity = .4
            //            }
            //        },
            //        new LiveCharts.Wpf.AxisSection
            //        {
            //            //Label = "Bad",
            //            Value = 0,
            //            SectionWidth = 500,
            //            Fill = new SolidColorBrush
            //            {
            //                Color = System.Windows.Media.Color.FromRgb(254,132,132),
            //                Opacity = .4
            //            }
            //        }
            //    }
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

                MessageBox.Show("refresh chartvalues" + e.Message);
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
                MessageBox.Show("Chartcontroller / Print Chart Monitor" + ex.Message);
            }
        }

        internal static void printGearedChart(double[] importantValues, int numberOfPanelsDisplayed, MainFrame mainFrameModel, bool recording=false)
        {
            try
            {
                if (importantValues != null && importantValues.Length >= numberOfPanelsDisplayed)
                {
                    for (var i = 0; i < numberOfPanelsDisplayed; i++)
                    {
                        ChartController.RefreshDefaultChartValues(mainFrameModel.defaultCharts[i].viewModel, importantValues[i],recording);
                    }
                }
                else
                {
                    for (var i = 0; i < numberOfPanelsDisplayed; i++)
                    {
                        ChartController.RefreshDefaultChartValues(mainFrameModel.defaultCharts[i].viewModel, double.NaN, recording);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chartcontroller / Print Chart" + ex.Message);
            }

        }

        internal static void printDefaultChart(DefaultChartUserControl defaultChartUserControl, double[] sendingData, int numberOfIncomingData,bool recording, int choosenXChannel = 0, int choosenYChannel = 0)
        {
            try
            {
                double _tmpval = 0;
                if (sendingData != null && sendingData.Length >= numberOfIncomingData && Math.Max(choosenXChannel, choosenYChannel) < sendingData.Length && Math.Min(choosenXChannel, choosenYChannel) >= 0)
                {
                    _tmpval = sendingData[0];
                }

                ChartController.RefreshDefaultChartValues(defaultChartUserControl.viewModel, _tmpval,recording);
            }
            catch (Exception e)
            {

                MessageBox.Show("XY" + e.Message);
            }


        }

        private static void RefreshDefaultChartValues(DefaultChartViewModel viewModel, double tmpval,bool recording=false)
        {
            var values = viewModel.values;
            var rec = viewModel.RecordValues;

            if (recording)
            {
                if (lastInsertedXYValue < viewModel.keepRecords)
                {
                    values[lastInsertedXYValue++].Y = double.NaN;
                    rec[lastInsertedXYValue++].Y = tmpval;

                }
                else
                {
                    values = shiftListToTheLeft(values, viewModel);
                    values[lastInsertedXYValue - 1].Y = double.NaN;

                    rec = shiftListToTheLeft(rec, viewModel);
                    rec[lastInsertedXYValue - 1].Y = tmpval;
                }
            }
            else {
                if (lastInsertedXYValue < viewModel.keepRecords)
                {
                    values[lastInsertedXYValue++].Y = tmpval;
                    rec[lastInsertedXYValue++].Y = double.NaN;

                }
                else
                {
                    values = shiftListToTheLeft(values, viewModel);
                    values[lastInsertedXYValue - 1].Y = tmpval;

                    rec = shiftListToTheLeft(rec, viewModel);
                    rec[lastInsertedXYValue - 1].Y = double.NaN;
                }

            }
            
        }

        private static GearedValues<ObservablePoint> shiftListToTheLeft(GearedValues<ObservablePoint> list, DefaultChartViewModel viewModel)
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
