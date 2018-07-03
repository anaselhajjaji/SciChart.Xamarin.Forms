using System;

namespace SciChart.Xamarin.Views.Numerics.GenericMath
{
    internal sealed class TimeSpanMath : IMath<TimeSpan>
    {
        public TimeSpan MinValue
        {
            get { return TimeSpan.MinValue; }
        }

        public TimeSpan MaxValue
        {
            get { return TimeSpan.MaxValue; }
        }

        public TimeSpan ZeroValue
        {
            get { return TimeSpan.Zero; }
        }

        public TimeSpan Max(TimeSpan a, TimeSpan b)
        {
            return a.Ticks > b.Ticks ? a : b;
        }

        public TimeSpan Min(TimeSpan a, TimeSpan b)
        {
            return a.Ticks < b.Ticks ? a : b;
        }

        public TimeSpan MinGreaterThan(TimeSpan floor, TimeSpan a, TimeSpan b)
        {
            var min = Min(a, b);
            var max = Max(a, b);
            return min.CompareTo(floor) > 0 ? min : max;
        }

        public bool IsNaN(TimeSpan value)
        {
            return false;
        }

        public TimeSpan Subtract(TimeSpan a, TimeSpan b)
        {
            return a - b;
        }

        public TimeSpan Abs(TimeSpan a)
        {
            return a;
        }

        public double ToDouble(TimeSpan value)
        {
            return value.Ticks;
        }

        public TimeSpan Mult(TimeSpan lhs, TimeSpan rhs)
        {
            return new TimeSpan(lhs.Ticks * rhs.Ticks);
        }

        public TimeSpan Mult(TimeSpan lhs, double rhs)
        {
            return new TimeSpan((long)(lhs.Ticks * rhs));
        }

        public TimeSpan Div(TimeSpan lhs, TimeSpan rhs)
        {
            return new TimeSpan(lhs.Ticks / rhs.Ticks);
        }

        public TimeSpan Add(TimeSpan lhs, TimeSpan rhs)
        {
            return new TimeSpan(lhs.Ticks + rhs.Ticks);
        }

        public TimeSpan Inc(ref TimeSpan value)
        {
            return new TimeSpan(value.Ticks + 1);
        }
        public TimeSpan Dec(ref TimeSpan value)
        {
            return new TimeSpan(value.Ticks - 1);
        }

        public TimeSpan FromDouble(double dValue)
        {
            return TimeSpan.FromTicks((long)dValue);
        }
    }
}