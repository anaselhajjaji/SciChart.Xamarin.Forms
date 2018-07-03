namespace SciChart.Xamarin.Views.Numerics.GenericMath
{
    internal sealed class ByteMath : IMath<byte>
    {
        public byte MinValue
        {
            get { return byte.MinValue; }
        }

        public byte MaxValue
        {
            get { return byte.MaxValue; }
        }

        public byte ZeroValue
        {
            get { return 0; }
        }

        public byte Max(byte a, byte b)
        {
            return a > b ? a : b;
        }

        public byte Min(byte a, byte b)
        {
            return a < b ? a : b;
        }

        public byte MinGreaterThan(byte floor, byte a, byte b)
        {
            var min = Min(a, b);
            var max = Max(a, b);
            return min.CompareTo(floor) > 0 ? min : max;
        }

        public bool IsNaN(byte value)
        {
            return false;
        }

        public byte Subtract(byte a, byte b)
        {
            return (byte) (a - b);
        }

        public byte Abs(byte a)
        {
            return a;
        }

        public double ToDouble(byte value)
        {
            return value;
        }

        public byte Mult(byte lhs, byte rhs)
        {
            return (byte) (lhs * rhs);
        }

        public byte Mult(byte lhs, double rhs)
        {
            return (byte) (lhs*rhs);
        }

        public byte Div(byte lhs, byte rhs)
        {
            return (byte) (lhs / rhs);
        }

        public byte Add(byte lhs, byte rhs)
        {
            return (byte) (lhs + rhs);
        }

        public byte Inc(ref byte value)
        {
            return ++value;
        }
        public byte Dec(ref byte value)
        {
            return --value;
        }

        public byte FromDouble(double dValue)
        {
            return (byte) dValue;
        }
    }
}