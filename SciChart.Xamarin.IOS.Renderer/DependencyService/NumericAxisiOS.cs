using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer.Utility;
using SciChart.Xamarin.Views.Visuals.Axes;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    [Foundation.Register]
    internal class NumericAxisiOS : SCINumericAxis, INumericAxis
    {
        public object BindingContext { get; set; }

        public string Id
        {
            get => base.AxisId;
            set => base.AxisId = value;
        }

        AxisAlignment IAxis.AxisAlignment
        {
            get => AxisHelper.ToXfAxisAlignemnt(base.AxisAlignment);
            set => base.AxisAlignment = AxisHelper.FromXfAxisAlignment(value);
        }
    }
}