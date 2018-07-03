using System;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    public interface IAxis : IAxisCore
    {
        /// <summary>
        /// Gets or sets the Alignment for this axis, e.g. Left, Right, Bottom, Top
        /// </summary>
        AxisAlignment AxisAlignment { get; set; }        
    }
}