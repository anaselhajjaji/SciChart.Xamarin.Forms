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
        public DoubleRange()
        {
            NativeRange = Factory.NewDoubleRange(0,0);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleRange"/> class.
        /// </summary>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <remarks></remarks>
        public DoubleRange(double min, double max) 
        {
            NativeRange = Factory.NewDoubleRange(min, max);
        }

        public double Min
        {
            get => ((IDoubleRange)NativeRange).Min;
            set => ((IDoubleRange)NativeRange).Min = value;
        }

        public double Max
        {
            get => ((IDoubleRange)NativeRange).Max;
            set => ((IDoubleRange)NativeRange).Max = value;
        }

        IComparable IRange.Min
        {
            get => ((IDoubleRange)NativeRange).Min;
            set => ((IDoubleRange)NativeRange).Min = (double)value;
        }

        IComparable IRange.Max
        {
            get => ((IDoubleRange)NativeRange).Max;
            set => ((IDoubleRange)NativeRange).Max = (double)value;
        }

        public IDoubleRange AsDoubleRange()
        {
            return this;
        }
    }
}
