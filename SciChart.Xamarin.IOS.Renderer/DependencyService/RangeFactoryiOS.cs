using SciChart.Xamarin.Views.Model;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    public class RangeFactoryiOS : IRangeFactory
    {
        public IDoubleRange NewDoubleRange(double min, double max)
        {
            return new DoubleRangeiOS(min, max);
        }
    }
}