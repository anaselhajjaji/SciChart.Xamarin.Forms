using System;
using System.Collections.Generic;
using System.Text;

namespace SciChart.Xamarin.Views.Model
{
    public interface IDoubleRange : IRange
    {
        new double Min { get; set; }
        new double Max { get; set; }
    }

    /// <summary>
    /// Defines a range of type <see cref="System.Double"/>
    /// </summary>
    public class DoubleRange : RangeBase, IDoubleRange
    {        
        private readonly IDoubleRange _nativeRange;

        public DoubleRange()
        {
            _nativeRange = Factory.NewDoubleRange(0,0);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleRange"/> class.
        /// </summary>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <remarks></remarks>
        public DoubleRange(double min, double max) 
        {
            _nativeRange = Factory.NewDoubleRange(min, max);
        }

        public double Min
        {
            get => _nativeRange.Min;
            set => _nativeRange.Min = value;
        }

        public double Max
        {
            get => _nativeRange.Max;
            set => _nativeRange.Max = value;
        }

        IComparable IRange.Min
        {
            get => _nativeRange.Min;
            set => _nativeRange.Min = (double)value;
        }

        IComparable IRange.Max
        {
            get => _nativeRange.Max;
            set => _nativeRange.Max = (double)value;
        }

        public IDoubleRange AsDoubleRange()
        {
            return this;
        }
    }
}
