using System;
using SciChart.Xamarin.Views.Utility;

namespace SciChart.Xamarin.Views.Model
{
    /// <summary>
    /// Helper class to instantiate IRange derived types, where strong typing is required underneath but the runtime type of IRange is not known
    /// </summary>
    public static class RangeFactory
    {
        /// <summary>
        /// Creates a new <see cref="IRange"/> derived instance of the same type as originalRange with the specified Min and Max
        /// </summary>
        /// <param name="originalRange">The original range to use as a reference</param>
        /// <param name="min">The min value of the new range</param>
        /// <param name="max">The max value of the new range</param>
        /// <returns>A new <see cref="IRange"/> derived instance of the same type as originalRange</returns>
        public static IRange NewWithMinMax(IRange originalRange, IComparable min, IComparable max)
        {
            Guard.Assert(min, "min").IsLessThanOrEqualTo(max, "max");
            var cloned = (IRange)originalRange.Clone();
            cloned.SetMinMax(min.ToDouble(), max.ToDouble());
            return cloned;
        }

        /// <summary>
        /// Creates a new <see cref="IRange"/> derived instance of the same type as originalRange with the specified Min and Max, with a Range Limit to clip min, max to.
        /// </summary>
        /// <param name="originalRange">The original range to use as a reference</param>
        /// <param name="min">The min value of the new range</param>
        /// <param name="max">The max value of the new range</param>
        /// <param name="rangeLimit">The range limit to clip Min and Max to.</param>
        /// <returns>A new <see cref="IRange"/> derived instance of the same type as originalRange</returns>
        /// <remarks></remarks>
        public static IRange NewWithMinMax(IRange originalRange, double min, double max, IRange rangeLimit)
        {
            var cloned = (IRange)originalRange.Clone();
            cloned.SetMinMaxWithLimit(min, max, rangeLimit);
            return cloned;
        }

        /// <summary>
        /// Creates a new <see cref="IRange"/> instance of the same type as the min, max range with the specified Min and Max
        /// </summary>
        /// <param name="min">The min value of the new range</param>
        /// <param name="max">The max value of the new range</param>
        /// <returns>A new <see cref="IRange"/> derived instance of the same type as the input values</returns>
        public static IRange NewRange(IComparable min, IComparable max)
        {
            var rangeType = min.GetType();

            IRange result = null;

            if (rangeType == typeof(int))
            {
                result = new IntegerRange((int)min, (int)max);
            }
            else if (rangeType == typeof(DateTime))
            {
                result = new DateRange((DateTime)min, (DateTime)max);
            }
            else if (rangeType == typeof(TimeSpan))
            {
                result = new TimeSpanRange((TimeSpan)min, (TimeSpan)max);
            }
            else
            {
                result = new DoubleRange(min.ToDouble(), max.ToDouble());
            }

            return result;
        }

        /// <summary>
        /// Creates a new <see cref="IRange" /> instance of desired type, setting the min and max value
        /// </summary>
        /// <param name="rangeType">Type of the range to create, e.g. <see cref="IndexRange"/> or <see cref="DoubleRange"/>.</param>
        /// <param name="min">The min value of the new range</param>
        /// <param name="max">The max value of the new range</param>
        /// <returns>
        /// A new <see cref="IRange" /> derived instance of the same type as the input values
        /// </returns>
        public static IRange NewRange(Type rangeType, IComparable min, IComparable max)
        {
            var range = Activator.CreateInstance(rangeType) as IRange;
            range.SetMinMax(min.ToDouble(), max.ToDouble());
            return range;
        }
    }
}