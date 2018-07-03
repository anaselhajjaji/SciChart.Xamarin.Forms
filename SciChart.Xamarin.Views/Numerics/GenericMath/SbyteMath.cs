using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SciChart.Xamarin.Views.Numerics.GenericMath
{
    internal sealed class SbyteMath : IMath<sbyte>
    {
        public sbyte MinValue
        {
            get { return sbyte.MinValue; }
        }

        public sbyte MaxValue
        {
            get { return sbyte.MaxValue; }
        }

        public sbyte ZeroValue
        {
            get { return 0; }
        }

        public sbyte Max(sbyte a, sbyte b)
        {
            return a > b ? a : b;
        }

        public sbyte Min(sbyte a, sbyte b)
        {
            return a < b ? a : b;
        }

        public sbyte MinGreaterThan(sbyte floor, sbyte a, sbyte b)
        {
            var min = Min(a, b);
            var max = Max(a, b);
            return min.CompareTo(floor) > 0 ? min : max;
        }

        public bool IsNaN(sbyte value)
        {
            return false;
        }

        public sbyte Subtract(sbyte a, sbyte b)
        {
            return (sbyte) (a - b);
        }

        public sbyte Abs(sbyte a)
        {
            return Math.Abs(a);
        }

        public double ToDouble(sbyte value)
        {
            return value;
        }

        public sbyte Mult(sbyte lhs, sbyte rhs)
        {
            return (sbyte) (lhs * rhs);
        }

        public sbyte Mult(sbyte lhs, double rhs)
        {
            return ((sbyte)(lhs* rhs));
        }

        public sbyte Div(sbyte lhs, sbyte rhs)
        {
            return (sbyte) (lhs / rhs);
        }

        public sbyte Add(sbyte lhs, sbyte rhs)
        {
            return (sbyte) (lhs + rhs);
        }

        public sbyte Inc(ref sbyte value)
        {
            return ++value;
        }
        public sbyte Dec(ref sbyte value)
        {
            return --value;
        }

        public sbyte FromDouble(double dValue)
        {
            return (sbyte) dValue;
        }
    }
}
