using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SciChart.Xamarin.Views.Numerics.GenericMath
{
    internal sealed class ShortMath : IMath<short>
    {
        public short MinValue
        {
            get { return short.MinValue; }
        }

        public short MaxValue
        {
            get { return short.MaxValue; }
        }

        public short ZeroValue
        {
            get { return 0; }
        }

        public short Max(short a, short b)
        {
            return a > b ? a : b;
        }

        public short Min(short a, short b)
        {
            return a < b ? a : b;
        }

        public short MinGreaterThan(short floor, short a, short b)
        {
            var min = Min(a, b);
            var max = Max(a, b);
            return min.CompareTo(floor) > 0 ? min : max;
        }

        public bool IsNaN(short value)
        {
            return false;
        }

        public short Subtract(short a, short b)
        {
            return (short) (a - b);
        }

        public short Abs(short a)
        {
            return Math.Abs(a);
        }

        public double ToDouble(short value)
        {
            return value;
        }

        public short Mult(short lhs, short rhs)
        {
            return (short) (lhs * rhs);
        }

        public short Mult(short lhs, double rhs)
        {
            return (short)(lhs * rhs);
        }

        public short Div(short lhs, short rhs)
        {
            return (short) (lhs / rhs);
        }

        public short Add(short lhs, short rhs)
        {
            return (short) (lhs + rhs);
        }

        public short Inc(ref short value)
        {
            return ++value;
        }
        public short Dec(ref short value)
        {
            return --value;
        }

        public short FromDouble(double dValue)
        {
            return (short) dValue;
        }
    }
}
