using System;
using Android.Content;
using SciChart.Charting.Visuals.Axes;
using SciChart.Xamarin.Android.Renderer.Utility;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Visuals.Axes;
using Xamarin.Forms;
using AutoRange = SciChart.Xamarin.Views.Model.AutoRange;
using AxisAlignment = SciChart.Xamarin.Views.Visuals.Axes.AxisAlignment;
using NumericAxis = SciChart.Charting.Visuals.Axes.NumericAxis;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    internal class NumericAxisAndroid : NumericAxis, INumericAxis
    {
        public event EventHandler<VisibleRangeChangedEventArgs> VisibleRangeChanged;

        public NumericAxisAndroid(Context context) : base(context)
        {
        }

        public Color AxisBandsFill
        {
            get => ColorUtil.BrushToXamarinColor(base.AxisBandsStyle);
            set => base.AxisBandsStyle = ColorUtil.BrushFromXamarinColor(value);
        }

        public AutoRange AutoRange
        {
            get => AxisHelper.ToXfAutoRange(base.AutoRange);
            set => base.AutoRange = AxisHelper.FromXfAutoRange(value);
        }

        public object BindingContext { get; set; }

        public string Id
        {
            get => base.AxisId;
            set => base.AxisId = value;
        }

        public IRange VisibleRange
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IRange<double> GrowBy
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }        

        public AxisAlignment AxisAlignment
        {
            get => AxisHelper.ToXfAxisAlignemnt(base.AxisAlignment);
            set => base.AxisAlignment = AxisHelper.FromXfAxisAlignment(value);
        }
    }
}