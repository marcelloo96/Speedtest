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
                        ChartController.RefreshDefaultChartValues(mainFrameModel.defaultCharts[i].viewModel, importantValues[i], recording, mainFrameModel,false);
                    }
                }
                else
                {
                    for (var i = 0; i < numberOfPanelsDisplayed; i++)
                    {
                        ChartController.RefreshDefaultChartValues(mainFrameModel.defaultCharts[i].viewModel, double.NaN, recording, mainFrameModel,false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chartcontroller / Print Chart" + ex.Message);
            }

        }

        internal static void printDefaultChart(MainFrame mainframe, DefaultChartUserControl defaultChartUserControl, double[] sendingData)
        {
            try
            {
                double _tmpval = double.NaN ;
                if (sendingData != null && sendingData.Length > mainframe.selectIncomingLiveChannelsElementValue)
                {
                    _tmpval = sendingData[mainframe.selectIncomingLiveChannelsElementValue];
                }
                else {
                    MessageBox.Show(Strings.Error_ChannelNetExistOrFound);
                    mainframe.StartStopButton.PerformClick();
                }

                

                ChartController.RefreshDefaultChartValues(defaultChartUserControl.viewModel, _tmpval,mainframe.Recording, mainframe);
            }
            catch (Exception e)
            {

                MessageBox.Show("XY" + e.Message);
            }


        }

        private static void RefreshDefaultChartValues(DefaultChartViewModel viewModel, double tmpval,bool recording, MainFrame mainFrame, bool isSingleGraph=true)
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
            double avg = double.NaN;
            if (MainFrame.meanValueIsOn && isSingleGraph)
            {
                avg = values.Select(p => p.Y).ToArray().Average();
                mainFrame.meanValueLabelCaption = Strings.Global_MeanValue + avg.ToString("F2");
                
            }
            for (int i = 0; i < viewModel.MeanValues.Count; i++) {
                viewModel.MeanValues[i].Y = avg;
                viewModel.MeanValues[i].X = values[i].X;
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
