using System;

namespace SciChart.Xamarin.Views.Numerics.GenericMath
{
    internal sealed class Int32Math : IMath<int>
    {
        public int MaxValue
        {
            get { return Int32.MaxValue; }
        }

        public int MinValue
        {
            get { return Int32.MinValue; }
        }

        public int ZeroValue
        {
            get { return 0; }
        }

        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public int Min(int a, int b)
        {
            return a < b ? a : b;
        }

        public int MinGreaterThan(int floor, int a, int b)
        {
            var min = Min(a, b);
            var max = Max(a, b);
            return min.CompareTo(floor) > 0 ? min : max;
        }

        public bool IsNaN(int value)
        {
            return false;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Abs(int a)
        {
            return Math.Abs(a);
        }

        public double ToDouble(int value)
        {
            return value;
        }

        public int Mult(int lhs, int rhs)
        {
            return lhs * rhs;
        }

        public int Mult(int lhs, double rhs)
        {
            return (int) (lhs * rhs);
        }

        public int Div(int lhs, int rhs)
        {
            return lhs / rhs;
        }

        public int Add(int lhs, int rhs)
        {
            return lhs + rhs;
        }

        public int Inc(ref int value)
        {
            return ++value;
        }
        public int Dec(ref int value)
        {
            return --value;
        }

        public int FromDouble(double dValue)
        {
            return (int) dValue;
        }
    }
}
