using System;

namespace SciChart.Xamarin.Views.Numerics.GenericMath
{
    internal sealed class Int64Math : IMath<long>
    {
        public long MaxValue
        {
            get { return long.MaxValue; }
        }

        public long MinValue
        {
            get { return long.MinValue; }
        }

        public long ZeroValue
        {
            get { return 0; }
        }

        public long Max(long a, long b)
        {
            return a > b ? a : b;
        }

        public long Min(long a, long b)
        {
            return a < b ? a : b;
        }

        public long MinGreaterThan(long floor, long a, long b)
        {
            var min = Min(a, b);
            var max = Max(a, b);
            return min.CompareTo(floor) > 0 ? min : max;
        }

        public bool IsNaN(long value)
        {
            return false;
        }

        public long Subtract(long a, long b)
        {
            return a - b;
        }

        public long Abs(long a)
        {
            return Math.Abs(a);
        }

        public double ToDouble(long value)
        {
            return value;
        }

        public long Mult(long lhs, long rhs)
        {
            return lhs * rhs;
        }

        public long Mult(long lhs, double rhs)
        {
            return ((long)(lhs* rhs));
        }

        public long Div(long lhs, long rhs)
        {
            return lhs / rhs;
        }

        public long Add(long lhs, long rhs)
        {
            return lhs + rhs;
        }

        public long Inc(ref long value)
        {
            return ++value;
        }
        public long Dec(ref long value)
        {
            return --value;
        }

        public long FromDouble(double dValue)
        {
            return (long) dValue;
        }
    }
}
