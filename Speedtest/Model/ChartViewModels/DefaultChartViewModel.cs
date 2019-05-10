using LiveCharts.Defaults;
using LiveCharts.Geared;
using System;

namespace Speedtest.Model
{
    public class DefaultChartViewModel
    {
        public GearedValues<ObservablePoint> values { get; set; }
        public GearedValues<ObservablePoint> RecordValues { get; set; }
        public GearedValues<ObservablePoint> MeanValues { get; set; }
        public GearedValues<ObservablePoint> EdgeDetectingLine { get; set; }
        public int keepRecords = 100;
        public double deltaTime = 1;


        public DefaultChartViewModel(double deltaT, int keepRecords)
        {
            values = new GearedValues<ObservablePoint>().WithQuality(Quality.High);
            RecordValues = new GearedValues<ObservablePoint>().WithQuality(Quality.High);
            MeanValues = new GearedValues<ObservablePoint>().WithQuality(Quality.High);
            EdgeDetectingLine = new GearedValues<ObservablePoint>().WithQuality(Quality.High);
            this.keepRecords = keepRecords;
            this.deltaTime = deltaT;
            setValuesInicialState(this);

        }
        public void setValuesInicialState(DefaultChartViewModel vm)
        {
            //double previousDeltaT = 0;
            vm.values.Clear();
            vm.RecordValues.Clear();
            vm.MeanValues.Clear();
            vm.EdgeDetectingLine.Clear();
            for (int i = 0; i < vm.keepRecords; i++)
            {
                var point = new ObservablePoint((double)(i * deltaTime), Double.NaN);
                vm.values.Add(point);
                vm.RecordValues.Add(point);
                vm.MeanValues.Add(point);
                vm.EdgeDetectingLine.Add(point);
                //previousDeltaT += deltaTime;
            }
        }
    }
}
