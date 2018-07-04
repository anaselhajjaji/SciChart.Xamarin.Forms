namespace SciChart.Xamarin.Views.Model
{
    public interface IRangeFactory
    {
        IDoubleRange NewDoubleRange(double min, double max);
    }
}