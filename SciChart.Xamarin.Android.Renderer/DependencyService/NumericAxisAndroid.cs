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
        public NumericAxisAndroid(Context context) : base(context)
        {
        }

        public Color AxisBandsFill { get; set; }
        public AutoRange AutoRange { get; set; }
        public object BindingContext { get; set; }

        public string Id
        {
            get => base.AxisId;
            set => base.AxisId = value;
        }

        public IRange VisibleRange { get; set; }
        public IRange<double> GrowBy { get; set; }
        public event EventHandler<VisibleRangeChangedEventArgs> VisibleRangeChanged;

        public AxisAlignment AxisAlignment
        {
            get => AxisHelper.ToXfAxisAlignemnt(base.AxisAlignment);
            set => base.AxisAlignment = AxisHelper.FromXfAxisAlignment(value);
        }
    }
}