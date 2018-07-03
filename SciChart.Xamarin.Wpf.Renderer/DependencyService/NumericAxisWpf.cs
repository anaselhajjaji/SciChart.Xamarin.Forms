using System;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Wpf.Renderer.Utility;
using Xamarin.Forms;
using NumericAxis = SciChart.Charting.Visuals.Axes.NumericAxis;


namespace SciChart.Xamarin.Wpf.Renderer.DependencyService
{
    internal class VisibleRangeMapper
    {        
    }

    internal class NumericAxisWpf : NumericAxis, INumericAxis
    {
        Color IAxisCore.AxisBandsFill
        {
            get => ColorUtil.ToXamarinColor(base.AxisBandsFill);
            set => base.AxisBandsFill = ColorUtil.FromXamarinColor(value);
        }

        AutoRange IAxisCore.AutoRange
        {
            get => AxisHelper.ToXfAutoRange(base.AutoRange);
            set => base.AutoRange = AxisHelper.FromXfAutoRange(value);
        }

        public object BindingContext
        {
            get => base.DataContext;
            set => base.DataContext = value;
        }

        IRange IAxisCore.VisibleRange
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        IRange<double> IAxisCore.GrowBy
        {
            get => new DoubleRange(base.GrowBy.Min, base.GrowBy.Max);
            set => base.GrowBy = new Data.Model.DoubleRange(value.Min, value.Max);
        }

        event EventHandler<VisibleRangeChangedEventArgs> IAxisCore.VisibleRangeChanged
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        AxisAlignment IAxis.AxisAlignment
        {
            get => AxisHelper.ToXfAxisAlignemnt(base.AxisAlignment);
            set => base.AxisAlignment = AxisHelper.FromXfAxisAlignment(value);
        }        
    }
}