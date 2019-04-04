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

namespace Speedtest.View.StatisticWindow
{
    public partial class ScrollableChartUserControl : UserControl
    {
        private ScrollableViewModel _viewModel;
        private double deltaT;

        public ScrollableChartUserControl(List<double> chart,double deltaT)
        {
            InitializeComponent();

            _viewModel = new ScrollableViewModel(chart,deltaT);
            this.deltaT = deltaT;
           
            
            //Cartesian Chart
            mainChart.Zoom = ZoomingOptions.X;
            mainChart.DisableAnimations = true;
            mainChart.Hoverable = false;

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
                LabelFormatter = _viewModel.Formatter,
                Separator = new Separator { IsEnabled = false }
            };
            ax.RangeChanged += Axis_OnRangeChanged;
            mainChart.AxisX.Add(ax);

            //Scroller Chart
            scrollerChart.DisableAnimations = true;
            scrollerChart.ScrollMode = ScrollMode.X;
            scrollerChart.ScrollBarFill = new SolidColorBrush(Color.FromArgb(37, 48, 48, 48));
            scrollerChart.DataTooltip = null;
            scrollerChart.Hoverable = false;
            scrollerChart.DataTooltip = null;
            scrollerChart.AxisX.Add(new Axis
            {
                LabelFormatter = x => ((double)x * deltaT).ToString(),
                Separator = new Separator { IsEnabled = false },
                IsMerged = true,
                Foreground = new SolidColorBrush(Color.FromArgb(152, 0, 0, 0)),
                FontSize = 22,
                FontWeight = FontWeights.UltraBold
            });
            scrollerChart.AxisY.Add(new Axis { Separator = new Separator { IsEnabled = true }, ShowLabels = false });
            scrollerChart.Series.Add(new GLineSeries
            {
                Values = _viewModel.Values,
                Fill = Brushes.Silver,
                StrokeThickness = 0,
                PointGeometry = null,
                AreaLimit = 0
            });

            //lets bind the charts

            //the assistant synchronizes both charts
            //here he are setting the initial range
            var assistant = new ScrollableBindingAssistant
            {
                From = _viewModel.From,
                To = _viewModel.To
            };

            mainChart.AxisX[0].SetBinding(Axis.MinValueProperty,
                new Binding { Path = new PropertyPath("From"), Source = assistant, Mode = BindingMode.TwoWay });
            mainChart.AxisX[0].SetBinding(Axis.MaxValueProperty,
                new Binding { Path = new PropertyPath("To"), Source = assistant, Mode = BindingMode.TwoWay });

            scrollerChart.Base.SetBinding(CartesianChart.ScrollHorizontalFromProperty,
                new Binding { Path = new PropertyPath("From"), Source = assistant, Mode = BindingMode.TwoWay });
            scrollerChart.Base.SetBinding(CartesianChart.ScrollHorizontalToProperty,
                new Binding { Path = new PropertyPath("To"), Source = assistant, Mode = BindingMode.TwoWay });
        }

        private void Axis_OnRangeChanged(RangeChangedEventArgs eventargs)
        {
            _viewModel.Formatter = x => ((double)x * deltaT).ToString();
        }
    }
}
