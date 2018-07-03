using System;

namespace SciChart.Xamarin.Views.Numerics.GenericMath
{
    internal sealed class FloatMath : IMath<float>
    {
        public float MaxValue
        {
            get { return float.MaxValue; }
        }

        public float MinValue
        {
            get { return float.MinValue; }
        }
        public float ZeroValue
        {
            get { return 0; }
        }

        public float Max(float a, float b)
        {
            if (IsNaN(a)) return b;
            if (IsNaN(b)) return a;

            return a > b ? a : b;
        }

        private bool IsDefined(float a)
        {
            return !float.IsInfinity(a) && !float.IsNaN(a);
        }

        public float Min(float a, float b)
        {
            if (IsNaN(a)) return b;
            if (IsNaN(b)) return a;

            return a < b ? a : b;
        }

        public float MinGreaterThan(float floor, float a, float b)
        {
            var min = Min(a, b);
            var max = Max(a, b);
            return min.CompareTo(floor) > 0 ? min : max;
        }

        public bool IsNaN(float value)
        {
            return value.IsNaN();
        }

        public float Subtract(float a, float b)
        {
            return a - b;
        }

        public float Abs(float a)
        {
            return Math.Abs(a);
        }

        public double ToDouble(float value)
        {
            return value;
        }

        public float Mult(float lhs, float rhs)
        {
            return lhs * rhs;
        }

        public float Mult(float lhs, double rhs)
        {
            return (float) (lhs * rhs);
        }

        public float Div(float lhs, float rhs)
        {
            return lhs / rhs;
        }

        public float Add(float lhs, float rhs)
        {
            return lhs + rhs;
        }

        public float Inc(ref float value)
        {
            return ++value;
        }
        public float Dec(ref float value)
        {
            return --value;
        }

        public float FromDouble(double dValue)
        {
            return (float) dValue;
        }
    }
}
