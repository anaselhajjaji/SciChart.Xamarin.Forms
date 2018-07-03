using System;
using SciChart.Xamarin.Views.Model;

namespace SciChart.Xamarin.Views
{
    /// <summary>
    /// Extension methods for <see cref="double"/> types
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Determines whether this double is a real number
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
		public static bool IsRealNumber(this double number)
        {
            return (!(double.IsNaN(number) || double.IsInfinity(number) || double.MaxValue.Equals(number) || double.MinValue.Equals(number)));
        }

        /// <summary>
        /// Determines whether the <see cref="double"/> is a NaN
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsNaN(this double value)
        {
            // Fast NaN check. 
            // NOTE: Value != Value check is intentional
            // http://stackoverflow.com/questions/3286492/can-i-improve-the-double-isnan-x-function-call-on-embedded-c
            // 

            // ReSharper disable EqualExpressionComparison
            // ReSharper disable CompareOfFloatsByEqualityOperator
#pragma warning disable 1718
            return value != value;
#pragma warning restore 1718
            // ReSharper restore CompareOfFloatsByEqualityOperator
            // ReSharper restore EqualExpressionComparison
        }

        /// <summary>
        /// Rounds the <see cref="double"/> 
        /// </summary>
        /// <param name="d">The Double.</param>
        /// <returns></returns>
        public static double RoundOff(this double d)
        {
            return Math.Round(d);
        }

        /// <summary>
        /// Rounds the <see cref="Double"/> with the specified <see cref="MidpointRounding"/> mode
        /// </summary>
        /// <param name="d">The Double.</param>
        /// <param name="mode">The MidpointRoudningMode</param>
        /// <returns></returns>
        public static double RoundOff(this double d, MidpointRounding mode)
        {
            return d.RoundOff(0, mode);
        }

        /// <summary>
        /// Rounds using arithmetic (5 rounds up) symmetrical (up is away from zero) rounding
        /// </summary>
        /// <param name="d">A double number to be rounded.</param>
        /// <param name="decimals">The number of significant fractional digits (precision) in the return value.</param>
        /// <param name="mode">The midpoint rounding mode</param>
        /// <returns>The number nearest d with precision equal to decimals. If d is halfway between two numbers, then the nearest whole number away from zero is returned.</returns>
        public static double RoundOff(this double d, int decimals, MidpointRounding mode)
        {
            if (mode == MidpointRounding.ToEven)
            {
                return Math.Round(d, decimals);
            }

            decimal factor = Convert.ToDecimal(Math.Pow(10, decimals));
            int sign = Math.Sign(d);
            return (double)(Decimal.Truncate((decimal)d * factor + 0.5m * sign) / factor);
        }

        /// <summary>
        /// Converts a <see cref="System.Double"/> to <see cref="System.DateTime"/> 
        /// </summary>
        /// <param name="ticks">The ticks as Double.</param>
        /// <returns>The equivalent DateTime</returns>
        public static DateTime ToDateTime(this double ticks)
        {
            long localTicks = NumberUtil.Constrain((long)ticks, DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks);
            return new DateTime(localTicks);
        }

        /// <summary>
        /// Converts a <see cref="System.Double"/> to <see cref="System.Decimal"/> 
        /// </summary>
        /// <param name="value">The Double.</param>
        /// <returns>The equivalent Decimal.</returns>
        public static decimal ToDecimal(this double value)
        {
            return Convert.ToDecimal(value);
        }

        /// <summary>
        /// Converts a <see cref="Double"/> to <see cref="Int32"/> while avoiding arithmetic overflow
        /// </summary>
        /// <param name="d">The Double.</param>
        /// <returns>The equivalent Int32</returns>
        public static double ClipToInt(this double d)
        {
            if (d > int.MaxValue)
                return int.MaxValue;

            if (d < int.MinValue)
                return int.MinValue;

            return d;
        }

        /// <summary>
        /// Converts a <see cref="Double"/> to <see cref="Int32"/> while avoiding arithmetic overflow
        /// </summary>
        /// <param name="d">The Double.</param>
        /// <returns>The equivalent Int32</returns>
        internal static int ClipToIntValue(this double d)
        {
            if (d > int.MaxValue)
                return int.MaxValue;

            if (d < int.MinValue)
                return int.MinValue;

            return (int)d;
        }

        /// <summary>
        /// Equivalency check between two Double arrays
        /// </summary>
        /// <param name="thisArray">The this array.</param>
        /// <param name="thatArray">The that array.</param>
        /// <returns></returns>
        internal static bool IsEquivalentTo(this double[] thisArray, double[] thatArray)
        {
            if (thisArray == null) return thatArray == null;
            if (thatArray == null) return false;
            if (thisArray.Length != thatArray.Length) return false;

            for (int i = 0; i < thatArray.Length; i++)
                if (thisArray[i] != thatArray[i])
                    return false;

            return true;
        }

        /// <summary>
        /// Change <see cref="double"/> value by ULP (unit in the last place).
        /// For more information see:
        /// https://stackoverflow.com/questions/2927694/c-sharp-incrementing-a-double-value-1-212e25
        /// https://en.wikipedia.org/wiki/Unit_in_the_last_place</summary>
        /// <param name="d">This double.</param>
        /// <param name="ulp">UPL value.</param>
        /// <returns></returns>
        internal static double UlpChange(this double d, long ulp)
        {
            if (!Double.IsInfinity(d) && !Double.IsNaN(d))
            {
                //should probably do something if we are at max or min values 
                //but its not clear what
                long bits = BitConverter.DoubleToInt64Bits(d);
                return BitConverter.Int64BitsToDouble(bits + ulp);
            }
            return d;
        }
    }
}