using System.Windows.Forms;
using LiveCharts.Defaults;
using LiveCharts.Geared;
using LiveCharts;
using System.Windows.Media;

namespace Speedtest.View.StatisticWindow
{
    public partial class HistogramChartUserControl : UserControl 
    {
        public GearedValues<ObservablePoint> Values;
        public HistogramChartUserControl(GearedValues<ObservablePoint> chart)
        {
            Values = chart;
            InitializeComponent();

            mainChart.Zoom = ZoomingOptions.X;
            mainChart.DisableAnimations = true;
            mainChart.Hoverable = true;
            mainChart.BackColor= System.Drawing.SystemColors.Control;
            mainChart.Series.Add(new GColumnSeries
            {
                Values = Values,
                Fill = new SolidColorBrush(Color.FromRgb(32, 112, 176)),
                ScalesXAt = 0,
                ColumnPadding = 0,
                MaxColumnWidth = 9999,
                SharesPosition = false
            });
        }
    }
}
