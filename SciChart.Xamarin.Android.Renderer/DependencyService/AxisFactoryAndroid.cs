using Android.App;
using SciChart.Xamarin.Views.Visuals.Axes;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    public class AxisFactoryAndroid : IAxisFactory
    {        
        public INumericAxis NewNumericAxis()
        {
            return new NumericAxisAndroid(Application.Context);
        }
    }
}