using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SciChart.Xamarin.Views.Numerics.GenericMath
{
    internal sealed class Uint64Math : IMath<ulong>
    {
        public ulong MinValue
        {
            get { return UInt64.MinValue; }
        }

        public ulong MaxValue
        {
            get { return UInt64.MaxValue; }
        }

        public ulong ZeroValue
        {
            get { return 0; }
        }

        public ulong Max(ulong a, ulong b)
        {
            return a > b ? a : b;
        }

        public ulong Min(ulong a, ulong b)
        {
            return a < b ? a : b;
        }

        public ulong MinGreaterThan(ulong floor, ulong a, ulong b)
        {
            var min = Min(a, b);
            var max = Max(a, b);
            return min.CompareTo(floor) > 0 ? min : max;
        }

        public bool IsNaN(ulong value)
        {
            return false;
        }

        public ulong Subtract(ulong a, ulong b)
        {
            return a - b;
        }

        public ulong Abs(ulong a)
        {
            return a;
        }

        public double ToDouble(ulong value)
        {
            return value;
        }

        public ulong Mult(ulong lhs, ulong rhs)
        {
            return lhs * rhs;
        }

        public ulong Mult(ulong lhs, double rhs)
        {
            return (ulong) (lhs * rhs);
        }

        public ulong Div(ulong lhs, ulong rhs)
        {
            return (lhs / rhs);
        }

        public ulong Add(ulong lhs, ulong rhs)
        {
            return lhs + rhs;
        }

        public ulong Inc(ref ulong value)
        {
            return ++value;
        }
        public ulong Dec(ref ulong value)
        {
            return --value;
        }

        public ulong FromDouble(double dValue)
        {
            return (ulong) dValue;
        }
    }
}