using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Utility;

namespace SciChart.Xamarin.Views
{
    /// <summary>
    /// Extension methods for the <see cref="System.IComparable"/> type
    /// </summary>
    internal static class IComparableExtensions
    {
        /// <summary>
        /// Determines whether this IComparable is defined.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns></returns>
        public static bool IsDefined(this IComparable c)
        {
            return c != null && ComparableUtil.IsDefined(c);
        }

        /// <summary>
        /// Fast conversion to Double if Double
        /// </summary>
        /// <param name="c">The input IComparable.</param>
        /// <returns></returns>
        public static double ToDouble(this double c)
        {
            return c;
        }

        /// <summary>
        /// Conversion to Double if IComparable
        /// </summary>
        /// <param name="c">The input IComparable.</param>
        /// <returns></returns>
        public static double ToDouble(this IComparable c)
        {
            if (c is double)
                return (double)c;

            return ComparableUtil.ToDouble(c);
        }

        /// <summary>
        /// Converts an <see cref="IComparable"/> array to double array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputArray">The input array.</param>
        /// <returns></returns>
        public static double[] ToDoubleArray<T>(this T[] inputArray) where T : IComparable
        {
            return inputArray.Select(x => x.ToDouble()).ToArray();
        }

        /// <summary>
        /// Converts an <see cref="IComparable"/> list to double array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputArray">The input array.</param>
        /// <returns></returns>
        public static double[] ToDoubleArray<T>(this IList<T> inputArray) where T : IComparable
        {
            return inputArray.Select(x => x.ToDouble()).ToArray();
        }

        /// <summary>
        /// Converts an <see cref="IComparable"/> to DateTime
        /// </summary>
        /// <param name="c">The IComparable.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this IComparable c)
        {
            if (c is DateTime)
            {
                return (DateTime)c;
            }

            if (c is TimeSpan)
            {
                return new DateTime(((TimeSpan)c).Ticks);
            }

            if (c.IsDefined())
            {
                long localTicks = NumberUtil.Constrain((long)Convert.ChangeType(c, typeof(long), CultureInfo.InvariantCulture), DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks);
                return new DateTime(localTicks);
            }

            return new DateTime();
        }

        /// <summary>
        /// Converts an <see cref="IComparable"/> to TimeSpan
        /// </summary>
        /// <param name="c">The IComparable.</param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(this IComparable c)
        {
            if (c is TimeSpan)
            {
                return (TimeSpan)c;
            }

            if (c is DateTime)
            {
                return new TimeSpan(((DateTime)c).Ticks);
            }

            if (c.IsDefined())
            {
                long localTicks = NumberUtil.Constrain((long)Convert.ChangeType(c, typeof(long), CultureInfo.InvariantCulture), TimeSpan.MinValue.Ticks, TimeSpan.MaxValue.Ticks);
                return new TimeSpan(localTicks);
            }

            return new TimeSpan();
        }
    }
}
