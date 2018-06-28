using System;
using System.Collections.Generic;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    public interface IXyDataSeries<TX,TY> : IDataSeries 
        where TX:IComparable 
        where TY:IComparable
    {
        /// <summary>
        /// Appends an X, Y point to the series.
        /// </summary>
        /// <param name="x">The X Value.</param>
        /// <param name="y">The Y Value.</param>
        void Append(TX x, TY y);

        /// <summary>
        /// Gets the X Values of this series.
        /// </summary>
        IList<TX> XValues { get; }

        /// <summary>
        /// Gets the Y Values of this series.
        /// </summary>
        IList<TY> YValues { get; }

    }
}