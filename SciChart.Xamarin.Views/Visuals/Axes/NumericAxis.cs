namespace SciChart.Xamarin.Views.Visuals.Axes
{
    public class NumericAxis : AxisBase, INumericAxis
    {
        public NumericAxis()
        {
            NativeAxis = Factory.NewNumericAxis(this);
        }
    }
}