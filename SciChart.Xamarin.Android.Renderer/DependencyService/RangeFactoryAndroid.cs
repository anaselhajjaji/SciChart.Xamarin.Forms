using System;
using SciChart.Xamarin.Views.Model;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    public class RangeFactoryAndroid : IRangeFactory
    {
        public IDoubleRange NewDoubleRange(double min, double max)
        {
            return new DoubleRangeAndroid(min, max);
        }
    }
}