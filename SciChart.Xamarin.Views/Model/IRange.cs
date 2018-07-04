using System;
using System.ComponentModel;

namespace SciChart.Xamarin.Views.Model
{
    /// <summary>
    /// Defines the base interface to a Range (Min, Max), used throughout SciChart for visible, data and index range calculations
    /// </summary>
    public interface IRange 
    {
        /// <summary>
        /// Gets or sets the Min value of this range
        /// </summary>
        IComparable Min { get; set; }

        /// <summary>
        /// Gets or sets the Max value of this range
        /// </summary>
        IComparable Max { get; set; }

        /// <summary>
        /// Converts this range to a <see cref="DoubleRange"/>, which are used internally for calculations
        /// </summary>
        /// <example>For numeric ranges, the conversion is simple. For <see cref="DateRange"/> instances, returns a new <see cref="DoubleRange"/> with the Min and Max Ticks</example>
        /// <returns></returns>
        IDoubleRange AsDoubleRange();
    }   
}