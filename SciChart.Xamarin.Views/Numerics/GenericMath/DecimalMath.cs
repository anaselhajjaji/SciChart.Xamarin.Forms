using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SciChart.Xamarin.Views.Numerics.GenericMath
{
    internal sealed class DecimalMath : IMath<decimal>
    {
        public decimal MinValue
        {
            get { return decimal.MinValue; }
        }

        public decimal MaxValue
        {
            get { return decimal.MaxValue; }
        }

        public decimal ZeroValue
        {
            get { return 0; }
        }

        public decimal Max(decimal a, decimal b)
        {
            return a > b ? a : b;
        }

        public decimal Min(decimal a, decimal b)
        {
            return a < b ? a : b;
        }

        public decimal MinGreaterThan(decimal floor, decimal a, decimal b)
        {
            var min = Min(a, b);
            var max = Max(a, b);
            return min.CompareTo(floor) > 0 ? min : max;
        }

        public bool IsNaN(decimal value)
        {
            return false;
        }

        public decimal Subtract(decimal a, decimal b)
        {
            return a - b;
        }

        public decimal Abs(decimal a)
        {
            return Math.Abs(a);
        }

        public double ToDouble(decimal value)
        {
            return (double) value;
        }

        public decimal Mult(decimal lhs, decimal rhs)
        {
            return lhs*rhs;
        }

        public decimal Mult(decimal lhs, double rhs)
        {
            return lhs * (decimal) rhs;
        }

        public decimal Div(decimal lhs, decimal rhs)
        {
            return (lhs / rhs);
        }

        public decimal Add(decimal lhs, decimal rhs)
        {
            return lhs + rhs;
        }

        public decimal Inc(ref decimal value)
        {
            return ++value;
        }
        public decimal Dec(ref decimal value)
        {
            return --value;
        }

        public decimal FromDouble(double dValue)
        {
            return (decimal) dValue;
        }
    }
}
