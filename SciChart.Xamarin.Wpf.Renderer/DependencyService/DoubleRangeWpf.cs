using System;
using SciChart.Data.Model;
using SciChart.Xamarin.Views.Model;
using DoubleRangeNative = SciChart.Data.Model.DoubleRange;
using IRangeXf = SciChart.Xamarin.Views.Model.IRange;

namespace SciChart.Xamarin.Wpf.Renderer.DependencyService
{
    internal class DoubleRangeWpf : DoubleRangeNative, IDoubleRange
    {
        public DoubleRangeWpf()
        {            
        }

        public DoubleRangeWpf(IRange<double> nativeRange) 
        {
            if (nativeRange != null)
            {
                this.Min = nativeRange.Min;
                this.Max = nativeRange.Max;
            }
        }

        public DoubleRangeWpf(double min, double max) : base(min, max)
        {            
        }

        IComparable IRangeXf.Min
        {
            get => base.Min;
            set => base.Min = (double) value;
        }

        IComparable IRangeXf.Max
        {
            get => base.Max;
            set => base.Max = (double)value;
        }

        IDoubleRange IRangeXf.AsDoubleRange()
        {
            return this;
        }
    }
}