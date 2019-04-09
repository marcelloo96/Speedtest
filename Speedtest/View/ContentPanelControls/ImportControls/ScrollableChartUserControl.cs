using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Events;
using LiveCharts.Geared;
using LiveCharts.Wpf;
using Binding = System.Windows.Data.Binding;
using Speedtest.Model.ChartViewModels;
using Speedtest.Controller.Charts;
using System.Collections.Generic;
using LiveCharts.Defaults;
using LiveCharts.Configurations;

namespace Speedtest.View.StatisticWindow
{
    public partial class ScrollableChartUserControl : UserControl
    {
        public enum ScrollableType : int { Basic = 1, FFT = 2 };

        private ScrollableViewModel _viewModel;
        private double deltaT;
        public List<double> doubleValues;
        public GearedValues<ObservablePoint> observableValues;
        public ScrollableType type;

        
        

        public ScrollableChartUserControl(List<double> chart, double deltaT, ScrollableType type = ScrollableType.Basic)
        {
            InitializeComponent();
            this.type = type;
            _viewModel = new ScrollableViewModel(chart, deltaT);
            this.deltaT = deltaT;
            doubleValues = chart;


            //Cartesian Chart
            mainChart.Zoom = ZoomingOptions.X;
            mainChart.DisableAnimations = true;
            mainChart.Hoverable = true;
            mainChart.BackColor = System.Drawing.Color.Transparent;
            mainChart.Series.Add(new GLineSeries
            {
                Values = _viewModel.Values,
                AreaLimit = 0,
                LineSmoothness = 0,
                Fill = Brushes.Transparent,


                PointGeometry = null
            });
            var ax = new Axis
            {
                Separator = new Separator { IsEnabled = false }
            };
            mainChart.AxisX.Add(ax);
            scrollerChart.AxisX.Add(new Axis
            {
                LabelFormatter = x => x.ToString(),
                Separator = new Separator { IsEnabled = false },
                IsMerged = true,
                Foreground = new SolidColorBrush(Color.FromArgb(152, 0, 0, 0)),
                FontSize = 22,
                FontWeight = FontWeights.UltraBold
            });
            scrollerChart.Series.Add(new GLineSeries
            {
                Values = _viewModel.Values,
                Fill = Brushes.Silver,
                StrokeThickness = 0,
                PointGeometry = null,
                AreaLimit = 0
            });
            createScrollerChart(type);
        }

        public ScrollableChartUserControl(GearedValues<ObservablePoint> chart, double deltaT, ScrollableType type = ScrollableType.FFT)
        {
            InitializeComponent();
            this.type = type;
            _viewModel = new ScrollableViewModel(chart);
            this.deltaT = deltaT;
            observableValues = chart;


            //Cartesian Chart
            mainChart.Zoom = ZoomingOptions.X;
            mainChart.DisableAnimations = true;
            mainChart.Hoverable = true;
            mainChart.BackColor = System.Drawing.Color.Transparent;
            mainChart.Series = new SeriesCollection(Mappers.Xy<ObservablePoint>()
                       .X(point => Math.Log10(point.X))
                       .Y(point => Math.Log10(point.Y)))
                    {new GLineSeries
                        {
                            Values = _viewModel.Values,
                            AreaLimit = 0,
                            LineSmoothness = 0,
                            Fill = Brushes.Transparent,


                        PointGeometry = null

                        }
                    };
            mainChart.AxisX.Add(new LogarithmicAxis
            {
                LabelFormatter = value => Math.Pow(10, value).ToString("R"),
                Base = 10,
                Separator = new Separator
                {
                    Stroke = Brushes.LightGray
                }
            });
            mainChart.AxisY.Add(new LogarithmicAxis
            {
                LabelFormatter = value => Math.Pow(10, value).ToString("R"),
                Base = 10,
                Separator = new Separator
                {
                    Stroke = Brushes.LightGray
                }
            });
            scrollerChart.AxisX.Add(new Axis
            {
                LabelFormatter = x => Math.Pow(10, x).ToString(),
                Separator = new Separator { IsEnabled = false },
                IsMerged = true,
                Foreground = new SolidColorBrush(Color.FromArgb(152, 0, 0, 0)),
                FontSize = 22,
                FontWeight = FontWeights.UltraBold
            });
            scrollerChart.Series = new SeriesCollection(Mappers.Xy<ObservablePoint>()
        .X(point => Math.Log10(point.X))
        .Y(point => Math.Log10(point.Y)))
            {new GLineSeries
            {
                Values = _viewModel.Values,
                Fill = Brushes.Silver,
                StrokeThickness = 0,
                PointGeometry = null,
                AreaLimit = 0
            }
            };
            createScrollerChart(type);
        }

        private void createScrollerChart(ScrollableType type)
        {
            //Scroller Chart
            scrollerChart.DisableAnimations = true;
            scrollerChart.ScrollMode = ScrollMode.X;
            scrollerChart.ScrollBarFill = new SolidColorBrush(Color.FromArgb(100, 0, 122, 204));
            scrollerChart.BackColor = System.Drawing.Color.Transparent;
            scrollerChart.DataTooltip = null;
            scrollerChart.Hoverable = false;
            scrollerChart.DataTooltip = null;

            scrollerChart.AxisY.Add(new Axis { Separator = new Separator { IsEnabled = true }, ShowLabels = false });
            

            //lets bind the charts

            //the assistant synchronizes both charts
            //here he are setting the initial range
            var assistant = new ScrollableBindingAssistant
            {
                From = _viewModel.From,
                To = _viewModel.To
            };
            if (type == ScrollableType.FFT)
            {
                assistant.To = Math.Log10(_viewModel.Values[_viewModel.Values.Count / 4].X);
            }
            mainChart.AxisX[0].SetBinding(Axis.MinValueProperty,
                new Binding { Path = new PropertyPath("From"), Source = assistant, Mode = BindingMode.TwoWay });
            mainChart.AxisX[0].SetBinding(Axis.MaxValueProperty,
                new Binding { Path = new PropertyPath("To"), Source = assistant, Mode = BindingMode.TwoWay });

            scrollerChart.Base.SetBinding(CartesianChart.ScrollHorizontalFromProperty,
                new Binding { Path = new PropertyPath("From"), Source = assistant, Mode = BindingMode.TwoWay });
            scrollerChart.Base.SetBinding(CartesianChart.ScrollHorizontalToProperty,
                new Binding { Path = new PropertyPath("To"), Source = assistant, Mode = BindingMode.TwoWay });
        }
    }
}
