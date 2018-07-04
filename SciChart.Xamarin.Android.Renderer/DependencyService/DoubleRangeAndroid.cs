using System;
using SciChart.Xamarin.Views.Model;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    internal class DoubleRangeAndroid : DoubleRange, IDoubleRange
    {
        public DoubleRangeAndroid()
        {
        }

        public DoubleRangeAndroid(double min, double max) : base(min, max)
        {
        }

        IComparable IRange.Min
        {
            get => base.Min;
            set => base.Min = (double)value;
        }

        IComparable IRange.Max
        {
            get => base.Max;
            set => base.Max = (double)value;
        }

        IDoubleRange IRange.AsDoubleRange()
        {
            return this;
        }
    }
}