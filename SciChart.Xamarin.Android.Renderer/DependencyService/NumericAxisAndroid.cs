using Android.Content;
using SciChart.Charting.Visuals.Axes;
using SciChart.Xamarin.Android.Renderer.Utility;
using SciChart.Xamarin.Views.Visuals.Axes;
using AxisAlignment = SciChart.Xamarin.Views.Visuals.Axes.AxisAlignment;
using NumericAxis = SciChart.Charting.Visuals.Axes.NumericAxis;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    internal class NumericAxisAndroid : NumericAxis, INumericAxis
    {
        public NumericAxisAndroid(Context context) : base(context)
        {
        }

        public object BindingContext { get; set; }

        public string Id
        {
            get => base.AxisId;
            set => base.AxisId = value;
        }

        public AxisAlignment AxisAlignment
        {
            get => AxisHelper.ToXfAxisAlignemnt(base.AxisAlignment);
            set => base.AxisAlignment = AxisHelper.FromXfAxisAlignment(value);
        }
    }
}