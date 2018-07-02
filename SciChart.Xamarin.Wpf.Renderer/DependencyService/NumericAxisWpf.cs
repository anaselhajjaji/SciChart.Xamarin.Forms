using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Wpf.Renderer.Utility;
using NumericAxis = SciChart.Charting.Visuals.Axes.NumericAxis;


namespace SciChart.Xamarin.Wpf.Renderer.DependencyService
{
    internal class NumericAxisWpf : NumericAxis, INumericAxis
    {
        public object BindingContext
        {
            get => base.DataContext;
            set => base.DataContext = value;
        }

        public AxisAlignment AxisAlignment
        {
            get => AxisHelper.ToXfAxisAlignemnt(base.AxisAlignment);
            set => base.AxisAlignment = AxisHelper.FromXfAxisAlignment(value);
        }
    }
}