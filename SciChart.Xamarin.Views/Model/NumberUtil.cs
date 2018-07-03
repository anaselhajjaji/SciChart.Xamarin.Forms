using System;

namespace SciChart.Xamarin.Views.Model
{
    internal static class NumberUtil
    {
        private const double EPSILON = 1E-15d;
        private static readonly decimal DecimalEpsilon = new decimal(1, 0, 0, false, 28); //1e-28m;

        public static double RoundUp(double value, double nearest)
        {
            return Math.Ceiling(value / nearest) * nearest;
        }

        public static double RoundDown(double value, double nearest)
        {
            return Math.Floor(value / nearest) * nearest;
        }

        public static bool IsDivisibleBy(double value, double divisor)
        {
            value = Math.Round(value, 15);

            if (Math.Abs(divisor - 0) < EPSILON)
                return false;

            var divided = Math.Abs(value / divisor);
            double epsilon = EPSILON * divided;
            return Math.Abs(divided - Math.Round(divided)) <= epsilon;
        }

        internal static bool IsDivisibleBy(decimal value, decimal divisor)
        {
            if (Math.Abs(divisor - 0M) < DecimalEpsilon)
                return false;

            var divided = Math.Abs(value / divisor);
            decimal epsilon = DecimalEpsilon * divided;
            return Math.Abs(divided - Math.Round(divided)) <= epsilon;
        }

        internal static decimal RoundUp(decimal value, decimal nearest)
        {
            return decimal.Ceiling(value / nearest) * nearest;
        }

        public static void Swap(ref int value1, ref int value2)
        {
            int temp = value2;
            value2 = value1;
            value1 = temp;
        }

        public static void Swap(ref long value1, ref long value2)
        {
            long temp = value2;
            value2 = value1;
            value1 = temp;
        }

        public static void Swap(ref double value1, ref double value2)
        {
            double temp = value2;
            value2 = value1;
            value1 = temp;
        }

        public static void Swap(ref float value1, ref float value2)
        {
            float temp = value2;
            value2 = value1;
            value1 = temp;
        }

        /// <summary>
        /// Swaps X1,X2 and Y1,Y2 so that the first coordinate pair is always to the left of the second coordinate pair
        /// </summary>
        /// <param name="xCoord1"></param>
        /// <param name="xCoord2"></param>
        /// <param name="yCoord1"></param>
        /// <param name="yCoord2"></param>
        public static void SortedSwap(ref double xCoord1, ref double xCoord2, ref double yCoord1, ref double yCoord2)
        {
            if (xCoord1 > xCoord2)
            {
                double temp = xCoord1;
                xCoord1 = xCoord2;
                xCoord2 = temp;

                temp = yCoord1;
                yCoord1 = yCoord2;
                yCoord2 = temp;
            }
        }

        public static int Constrain(int value, int lowerBound, int upperBound)
        {
            return value < lowerBound ? lowerBound : value > upperBound ? upperBound : value;
        }

        public static long Constrain(long value, long lowerBound, long upperBound)
        {
            return value < lowerBound ? lowerBound : value > upperBound ? upperBound : value;
        }

        public static double Constrain(double value, double lowerBound, double upperBound)
        {
            return value < lowerBound ? lowerBound : value > upperBound ? upperBound : value;
        }

        public static bool IsPowerOf(double value, double power, double logBase)
        {
            return Math.Abs(RoundUpPower(value, power, logBase) - (double)value) <= double.Epsilon;
        }

        public static double RoundUpPower(double value, double power, double logBase)
        {
            bool flip = Math.Sign(value) == -1;

            double logWithPowerBase = Math.Log(Math.Abs(value), logBase) / Math.Log(Math.Abs(power), logBase);

            // Round to mitigate a log calculation mistake
            logWithPowerBase = Math.Round(logWithPowerBase, 5);
            double exponent = Math.Ceiling(logWithPowerBase);

            if (Math.Abs(exponent - logWithPowerBase) < double.Epsilon) return value;

            exponent = flip ? exponent - 1 : exponent;

            double result = Math.Pow(power, exponent);
            return flip ? -result : result;
        }

        public static double RoundDownPower(double value, double power, double logBase)
        {
            bool flip = Math.Sign(value) == -1;

            double logWithPowerBase = Math.Log(Math.Abs(value), logBase) / Math.Log(Math.Abs(power), logBase);

            // Round to mitigate a log calculation mistake
            logWithPowerBase = Math.Round(logWithPowerBase, 5);
            double exponent = Math.Floor(logWithPowerBase);

            if (Math.Abs(exponent - logWithPowerBase) < double.Epsilon) return value;

            exponent = flip ? exponent - 1 : exponent;

            double result = Math.Pow(power, exponent);
            return flip ? -result : result;
        }

        public static bool IsIntegerType(Type type)
        {
            return type != typeof(double) &&
                type != typeof(float) &&
                type != typeof(DateTime) &&
                type != typeof(TimeSpan);
        }

        /// <summary>
        /// Determines whether a double value is NaN
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsNaN(double value)
        {
#pragma warning disable
            // ReSharper disable EqualExpressionComparison
            // ReSharper disable CompareOfFloatsByEqualityOperator
            return value != value;
            // ReSharper restore CompareOfFloatsByEqualityOperator
            // ReSharper restore EqualExpressionComparison
#pragma warning restore
        }

        public static double ToDegrees(double radians)
        {
            return (radians * 180) / Math.PI;
        }

        /// <summary>
        /// Converts two <see cref="long"/> values to two <see cref="double"/> values,
        /// with a guarantee that <see cref="double"/> values are different in case <see cref="long"/> values are different.
        /// </summary>
        /// <param name="leftLongs">Left long value.</param>
        /// <param name="rightLongs">Right long value.</param>
        /// <param name="leftDouble">Left double value.</param>
        /// <param name="rightDouble">Right double value.</param>
        public static void ConvertLongsToDoublesConsideringDifferance(long leftLongs, long rightLongs, out double leftDouble, out double rightDouble)
        {
            leftDouble = leftLongs;
            rightDouble = rightLongs;

            if (leftLongs != rightLongs && leftDouble == rightDouble)
            {
                if (leftLongs < rightLongs)
                {
                    rightDouble = rightDouble.UlpChange(1);
                }
                else
                {
                    leftDouble = leftDouble.UlpChange(1);
                }
            }
        }
    }
}