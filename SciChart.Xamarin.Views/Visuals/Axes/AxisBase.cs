using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    public class AxisBase : AxisCore, IAxis
    {
        public static readonly BindableProperty AxisAlignmentProperty = BindableProperty.Create("AxisAlignment", typeof(AxisAlignment), typeof(AxisCore), AxisAlignment.Default, BindingMode.Default, null, OnAxisAlignmentChanged, null, null, null);

        private static void OnAxisAlignmentChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((IAxis)((AxisBase)bindable).NativeAxis).AxisAlignment = (AxisAlignment)newvalue;
        }

        public AxisAlignment AxisAlignment
        {
            get => (AxisAlignment) GetValue(AxisAlignmentProperty);
            set => SetValue(AxisAlignmentProperty, value);
        }
    }
}