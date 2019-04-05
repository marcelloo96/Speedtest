using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Geared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedtest.Model
{
    public class DefaultChartViewModel
    {
        public GearedValues<ObservablePoint> values { get; set; }
        public int keepRecords = 100;
        public double deltaTime = 1;


        public DefaultChartViewModel(double deltaT, int keepRecords)
        {
            values = new GearedValues<ObservablePoint>().WithQuality(Quality.High);
            double previousDeltaT = 0;
            this.keepRecords = keepRecords;
            setValuesInicialState(this);

        }
        public void setValuesInicialState(DefaultChartViewModel vm) {
            double previousDeltaT = 0;
            for (int i = 0; i < vm.keepRecords; i++)
            {
                vm.values.Add(new ObservablePoint((double)(previousDeltaT + vm.deltaTime), Double.NaN));
                previousDeltaT += deltaTime;
            }
        }
    }
}
