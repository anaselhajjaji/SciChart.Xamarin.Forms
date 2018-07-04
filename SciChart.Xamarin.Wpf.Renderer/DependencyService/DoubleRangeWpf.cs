using System;
using SciChart.Xamarin.Views.Model;
using DoubleRange = SciChart.Data.Model.DoubleRange;

namespace SciChart.Xamarin.Wpf.Renderer.DependencyService
{
    internal class DoubleRangeWpf : DoubleRange, IDoubleRange
    {
        public DoubleRangeWpf()
        {            
        }

        public DoubleRangeWpf(double min, double max) : base(min, max)
        {            
        }

        IComparable IRange.Min
        {
            get => base.Min;
            set => base.Min = (double) value;
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