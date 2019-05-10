using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Geared;
using System.Windows.Forms;
using System.Windows.Media;

namespace Speedtest.View.StatisticWindow
{
    public partial class SimpleObservablePointedChartUserControl : UserControl
    {
        public GearedValues<ObservablePoint> Values;
        public SimpleObservablePointedChartUserControl(GearedValues<ObservablePoint> chart)
        {
            Values = chart;
            InitializeComponent();

            mainChart.Zoom = ZoomingOptions.X;
            mainChart.DisableAnimations = true;
            mainChart.Hoverable = true;
            mainChart.BackColor = System.Drawing.Color.Transparent;
            mainChart.Series.Add(new GColumnSeries
            {
                Values = Values,
                Fill = new SolidColorBrush(Color.FromRgb(32, 112, 176)),
                ScalesXAt = 0,
                ColumnPadding = 0,
                MaxColumnWidth = 10,
                SharesPosition = false
            });
        }
    }
}
