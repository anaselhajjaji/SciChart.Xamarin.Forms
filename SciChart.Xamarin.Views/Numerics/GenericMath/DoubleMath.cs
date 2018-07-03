using System;

namespace SciChart.Xamarin.Views.Numerics.GenericMath
{
    internal sealed class DoubleMath : IMath<double>
    {
        public double MaxValue
        {
            get
            {
                return double.MaxValue;
            }
        }

        public double MinValue
        {
            get
            {
                return double.MinValue;
            }
        }

        public double ZeroValue
        {
            get { return 0; }
        }

        public double Max(double a, double b)
        {
            if (Double.IsNaN(a)) return b;
            if (Double.IsNaN(b)) return a;

            return a > b ? a : b;
        }

        public double Min(double a, double b)
        {
            if (Double.IsNaN(a)) return b;
            if (Double.IsNaN(b)) return a;

            return a < b ? a : b;
        }

        public double MinGreaterThan(double floor, double a, double b)
        {
            var min = Min(a, b);
            var max = Max(a, b);
            return min.CompareTo(floor) > 0 ? min : max;
        }

        public bool IsNaN(double value)
        {
            return value.IsNaN();
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Abs(double a)
        {
            return Math.Abs(a);
        }

        public double ToDouble(double value)
        {
            return value;
        }

        public double Mult(double lhs, double rhs)
        {
            return lhs*rhs;
        }

        public double Div(double lhs, double rhs)
        {
            return lhs / rhs;
        }

        public double Add(double lhs, double rhs)
        {
            return lhs + rhs;
        }

        public double Inc(ref double value)
        {
            return ++value;
        }
        public double Dec(ref double value)
        {
            return --value;
        }

        public double FromDouble(double dValue)
        {
            return dValue;
        }
    }
}
