using System;
using SciChart.Xamarin.Views.Utility;

namespace SciChart.Xamarin.Views.Model
{
    /// <summary>
    /// Defines a Range of Type DateTime
    /// </summary>
    /// <remarks></remarks>
    public class DateRange : Range<DateTime>
    {
        private static readonly string FormattingString = "dd MMM yyyy HH:mm:ss";

        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> class.
        /// </summary>
        /// <remarks></remarks>
        public DateRange()
        {
            // Default to Invalid range
            Min = DateTime.MaxValue;
            Max = DateTime.MaxValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> class.
        /// </summary>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <remarks></remarks>
        public DateRange(DateTime min, DateTime max) : base(min, max)
        {
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        /// <remarks></remarks>
        public override string ToString()
        {
            return string.Format("{0} {{Min={1}, Max={2}}}", GetType(), Min.ToString(FormattingString),
                Max.ToString(FormattingString));
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public override object Clone()
        {
            return new DateRange(Min, Max);
        }

        /// <summary>
        /// Gets the difference (Max - Min) of this range
        /// </summary>
        public override DateTime Diff
        {
            get { return new DateTime((Max - Min).Ticks); }
        }

        /// <summary>
        /// Gets whether the range is Zero, where Max equals Min
        /// </summary>
        /// <remarks></remarks>
        public override bool IsZero
        {
            get { return (Max - Min).Ticks <= DateTime.MinValue.Ticks; }
        }

        /// <summary>
        /// Converts this range to a <see cref="DoubleRange"/>, which are used internally for calculations
        /// </summary>
        /// <returns></returns>
        /// <example>For numeric ranges, the conversion is simple. For <see cref="DateRange"/> instances, returns a new <see cref="DoubleRange"/> with the Min and Max Ticks</example>
        /// <remarks></remarks>
        public override DoubleRange AsDoubleRange()
        {
            // In case of small difference between min/max ticks,
            // they both might be converted to the same double value.
            // This case tends to incorrect data visualization along the axis.
            // As work around a next value by ULP is used.

            double minTicksDouble;
            double maxTicksDouble;
            NumberUtil.ConvertLongsToDoublesConsideringDifferance(Min.Ticks, Max.Ticks, out minTicksDouble, out maxTicksDouble);

            return new DoubleRange(minTicksDouble, maxTicksDouble);
        }

        /// <summary>
        /// Sets the Min, Max values on the <see cref="IRange{T}"/>, returning this instance after modification
        /// </summary>
        /// <param name="min">The new Min value.</param>
        /// <param name="max">The new Max value.</param>
        /// <returns>This instance, after the operation</returns>
        /// <remarks></remarks>
        public override IRange<DateTime> SetMinMax(double min, double max)
        {
            // Need to convert double first to Decimal than to long because of loosing precision while converting from double to long very big numbers.
            // It fixes SC-3777 Deviations from VisibleRangeLimit during zooming / ZoomExtents.
            var minTicks = NumberUtil.Constrain((long)min.RoundOff().ToDecimal(), DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks);
            var maxTicks = NumberUtil.Constrain((long)max.RoundOff().ToDecimal(), DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks);

            SetMinMaxInternal(new DateTime(minTicks), new DateTime(maxTicks));

            return this;
        }

        /// <summary>
        /// Sets the Min, Max values on the <see cref="IRange{T}"/> with a maximum range limit, returning this instance after modification
        /// </summary>
        /// <param name="min">The new Min value.</param>
        /// <param name="max">The new Max value.</param>
        /// <param name="maxRange">The max range.</param>
        /// <returns>This instance, after the operation</returns>
        /// <remarks></remarks>
        public override IRange<DateTime> SetMinMax(double min, double max, IRange<DateTime> maxRange)
        {
            // Need to convert double first to Decimal than to long because of loosing precision while converting from double to long very big numbers.
            // It fixes SC-3777 Deviations from VisibleRangeLimit during zooming / ZoomExtents.
            var minDate = new DateTime((long)min.RoundOff().ToDecimal());
            var maxDate = new DateTime((long)max.RoundOff().ToDecimal());

            if (maxRange != null)
            {
                minDate = ComparableUtil.Max(minDate, maxRange.Min);
                maxDate = ComparableUtil.Min(maxDate, maxRange.Max);
            }

            Min = minDate;
            Max = maxDate;

            return this;
        }

        /// <summary>
        /// Grows the current <see cref="IRange{T}"/> by the min and max fraction, returning this instance after modification
        /// </summary>
        /// <param name="minFraction">The Min fraction to grow by. For example, Min = -10 and minFraction = 0.1 will result in the new Min = -11</param>
        /// <param name="maxFraction">The Max fraction to grow by. For example, Max = 10 and minFraction = 0.2 will result in the new Max = 12</param>
        /// <returns>This instance, after the operation</returns>
        /// <remarks></remarks>
        public override IRange<DateTime> GrowBy(double minFraction, double maxFraction)
        {
            if (!Min.IsDefined() || !Max.IsDefined())
            {
                return this;
            }

            var rangeDiff = (Max - Min).Ticks;

            bool isZeroRange = IsZero;

            long newMaxTicks = (long)(Max.Ticks + maxFraction * (isZeroRange ? Max.Ticks : rangeDiff));
            long newMinTicks = (long)(Min.Ticks - minFraction * (isZeroRange ? Min.Ticks : rangeDiff));

            if (newMaxTicks > DateTime.MaxValue.Ticks || newMinTicks < DateTime.MinValue.Ticks)
            {
                return this;
            }

            if (newMaxTicks < newMinTicks)
            {
                NumberUtil.Swap(ref newMaxTicks, ref newMinTicks);
            }

            Max = new DateTime(newMaxTicks);
            Min = new DateTime(newMinTicks);

            return this;
        }

        /// <summary>
        /// Clips the current <see cref="IRange{T}"/> to a maxmimum range 
        /// </summary>
        /// <param name="maximumRange">The Maximum Range</param>
        /// <returns>This instance, after the operation</returns>
        public override IRange<DateTime> ClipTo(IRange<DateTime> maximumRange)
        {
            var oldMax = Max;
            var oldMin = Min;

            var max = Max > maximumRange.Max ? maximumRange.Max : Max;
            var min = Min < maximumRange.Min ? maximumRange.Min : Min;

            if (min > maximumRange.Max)
            {
                min = maximumRange.Min;
            }
            if (max < oldMin)
            {
                max = maximumRange.Max;
            }
            if (min > max)
            {
                min = maximumRange.Min;
                max = maximumRange.Max;
            }

            SetMinMaxInternal(min, max);

            return this;
        }
    }
}