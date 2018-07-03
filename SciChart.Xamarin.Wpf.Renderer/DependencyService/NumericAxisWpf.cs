using System;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Wpf.Renderer.Utility;
using Xamarin.Forms;
using NumericAxis = SciChart.Charting.Visuals.Axes.NumericAxis;


namespace SciChart.Xamarin.Wpf.Renderer.DependencyService
{
    internal class NumericAxisWpf : NumericAxis, INumericAxis
    {
        public event EventHandler<VisibleRangeChangedEventArgs> VisibleRangeChanged;

        public Color AxisBandsFill
        {
            get => ColorUtil.ToXamarinColor(base.AxisBandsFill);
            set => base.AxisBandsFill = ColorUtil.FromXamarinColor(value);
        }

        public AutoRange AutoRange
        {
            get => AxisHelper.ToXfAutoRange(base.AutoRange);
            set => base.AutoRange = AxisHelper.FromXfAutoRange(value);
        }

        public object BindingContext
        {
            get => base.DataContext;
            set => base.DataContext = value;
        }

        public IRange VisibleRange
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IRange<double> GrowBy
        {
            get => new DoubleRange(base.GrowBy.Min, base.GrowBy.Max);
            set => base.GrowBy = new Data.Model.DoubleRange(value.Min, value.Max);
        }        

        public AxisAlignment AxisAlignment
        {
            get => AxisHelper.ToXfAxisAlignemnt(base.AxisAlignment);
            set => base.AxisAlignment = AxisHelper.FromXfAxisAlignment(value);
        }        
    }
}