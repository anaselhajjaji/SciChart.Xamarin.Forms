namespace SciChart.Xamarin.Views.Numerics.GenericMath
{
    internal sealed class UShortMath : IMath<ushort>
    {
        public ushort MinValue
        {
            get { return ushort.MinValue; }
        }

        public ushort MaxValue
        {
            get { return ushort.MaxValue; }
        }

        public ushort ZeroValue
        {
            get { return 0; }
        }

        public ushort Max(ushort a, ushort b)
        {
            return a > b ? a : b;
        }

        public ushort Min(ushort a, ushort b)
        {
            return a < b ? a : b;
        }

        public ushort MinGreaterThan(ushort floor, ushort a, ushort b)
        {
            var min = Min(a, b);
            var max = Max(a, b);
            return min.CompareTo(floor) > 0 ? min : max;
        }

        public bool IsNaN(ushort value)
        {
            return false;   
        }

        public ushort Subtract(ushort a, ushort b)
        {
            return (ushort) (a - b);
        }

        public ushort Abs(ushort a)
        {
            return a;
        }

        public double ToDouble(ushort value)
        {
            return value;
        }

        public ushort Mult(ushort lhs, ushort rhs)
        {
            return (ushort)(lhs * rhs);
        }

        public ushort Mult(ushort lhs, double rhs)
        {
            return (ushort)(lhs * rhs);
        }

        public ushort Div(ushort lhs, ushort rhs)
        {
            return (ushort) (lhs / rhs);
        }

        public ushort Add(ushort lhs, ushort rhs)
        {
            return (ushort)(lhs + rhs);
        }

        public ushort Inc(ref ushort value)
        {
            return ++value;
        }
        public ushort Dec(ref ushort value)
        {
            return --value;
        }

        public ushort FromDouble(double dValue)
        {
            return (ushort) dValue;
        }
    }
}