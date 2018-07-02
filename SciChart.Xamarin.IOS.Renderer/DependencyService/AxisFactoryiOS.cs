using SciChart.Xamarin.Views.Visuals.Axes;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    public class AxisFactoryiOS : IAxisFactory
    {
        public INumericAxis NewNumericAxis()
        {
            return new NumericAxisiOS();
        }
    }
}