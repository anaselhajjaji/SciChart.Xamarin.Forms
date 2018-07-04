using System;
using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Model;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    internal class DoubleRangeiOS : SCIDoubleRange, IDoubleRange
    {
        public DoubleRangeiOS()
        {
        }

        public DoubleRangeiOS(double min, double max) : base(min, max)
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