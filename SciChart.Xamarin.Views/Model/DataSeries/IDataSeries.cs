using System.Collections.Generic;
using System.Text;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    public interface IDataSeries
    {
        /// <summary>
        /// Gets or sets the name of this series.
        /// </summary>
        string SeriesName { get; set; }

        /// <summary>
        /// Gets the number of points in this dataseries.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// New to v3.3: when AcceptsUnsortedData is false, the DataSeries with throw an InvalidOperationException if unsorted data is appended. Unintentional unsorted data can result in much slower performance. 
        /// To disable this check, set AcceptsUnsortedData = true. 
        /// </summary>        
        bool AcceptsUnsortedData { get; set; }

        /// <summary>
        /// Clears the series, resetting internal lists to zero size.
        /// </summary>
        void Clear();
    }
}
