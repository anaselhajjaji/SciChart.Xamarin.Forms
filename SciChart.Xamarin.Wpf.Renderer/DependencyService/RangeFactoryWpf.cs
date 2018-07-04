using SciChart.Xamarin.Views.Model;

namespace SciChart.Xamarin.Wpf.Renderer.DependencyService
{
    public class RangeFactoryWpf : IRangeFactory
    {
        public IDoubleRange NewDoubleRange(double min, double max)
        {
            return new DoubleRangeWpf(min, max);
        }
    }
}