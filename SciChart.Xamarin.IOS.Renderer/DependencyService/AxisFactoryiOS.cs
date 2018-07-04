using SciChart.Xamarin.Views.Visuals.Axes;
using NumericAxisXf = SciChart.Xamarin.Views.Visuals.Axes.NumericAxis;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    public class AxisFactoryiOS : IAxisFactory
    {
        public INumericAxis NewNumericAxis(NumericAxisXf xfNumericAxis)
        {
            return new NumericAxisiOS(xfNumericAxis);
        }
    }
}