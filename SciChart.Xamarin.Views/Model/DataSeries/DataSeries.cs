using System.Collections.Generic;
using System.Text;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    public enum DataSeriesType
    {
        Xy,
        Xyz
    }

    public class DataSeries
    {
        public int Count { get; set; }
        public int FifoCapacity { get; set; }
        public string SeriesName { get; set; }
        public DataSeriesType SeriesType { get; set; }
    }
}
