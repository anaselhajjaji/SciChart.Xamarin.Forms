using SciChart.Xamarin.Views.Visuals.Axes;

namespace SciChart.Xamarin.Wpf.Renderer.DependencyService
{
    public class AxisFactoryWpf : IAxisFactory
    {
        public INumericAxis NewNumericAxis(NumericAxis xfAxis)
        {
            return new NumericAxisWpf(xfAxis);
        }
    }
}