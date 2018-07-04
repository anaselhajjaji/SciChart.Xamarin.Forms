using Android.App;
using SciChart.Xamarin.Views.Visuals.Axes;
using NumericAxisXf = SciChart.Xamarin.Views.Visuals.Axes.NumericAxis;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    public class AxisFactoryAndroid : IAxisFactory
    {        
        public INumericAxis NewNumericAxis(NumericAxisXf xfNumericAxis)
        {
            return new NumericAxisAndroid(Application.Context, xfNumericAxis);
        }
    }
}