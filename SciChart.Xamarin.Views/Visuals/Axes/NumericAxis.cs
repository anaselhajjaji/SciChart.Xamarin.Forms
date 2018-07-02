namespace SciChart.Xamarin.Views.Visuals.Axes
{
    public class NumericAxis : AxisBase, INumericAxis
    {
        public NumericAxis()
        {
            InnerAxis = Factory.NewNumericAxis();
        }
    }
}