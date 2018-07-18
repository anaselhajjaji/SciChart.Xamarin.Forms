using System;
using Android.Content;
using SciChart.Charting.Visuals.Axes;
using SciChart.Xamarin.Android.Renderer.Utility;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Visuals.Axes;
using Xamarin.Forms;
using AutoRange = SciChart.Xamarin.Views.Visuals.Axes.AutoRange;
using AxisAlignment = SciChart.Xamarin.Views.Visuals.Axes.AxisAlignment;
using IAxis = SciChart.Xamarin.Views.Visuals.Axes.IAxis;
using IAxisCore = SciChart.Xamarin.Views.Visuals.Axes.IAxisCore;
using NumericAxis = SciChart.Charting.Visuals.Axes.NumericAxis;
using NumericAxisXf = SciChart.Xamarin.Views.Visuals.Axes.NumericAxis;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    internal class NumericAxisAndroid : NumericAxis, INumericAxis
    {
        private EventHandler<VisibleRangeChangedEventArgs> _visibleRangEventHandler;

        public NumericAxisAndroid(Context context) : base(context)
        {
            base.VisibleRangeChange += OnAxisVisibleRangeChanged;
        }

        public Color AxisBandsFill
        {
            get => ColorUtil.BrushToXamarinColor(base.AxisBandsStyle);
            set => base.AxisBandsStyle = ColorUtil.BrushFromXamarinColor(value);
        }

        AutoRange IAxisCore.AutoRange
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

        IRange IAxisCore.VisibleRange
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        IDoubleRange IAxisCore.GrowBy
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        event EventHandler<VisibleRangeChangedEventArgs> IAxisCore.VisibleRangeChanged
        {
            add => _visibleRangEventHandler += value;
            remove => _visibleRangEventHandler -= value;
        }

        AxisAlignment IAxis.AxisAlignment
        {
            get => AxisHelper.ToXfAxisAlignemnt(base.AxisAlignment);
            set => base.AxisAlignment = AxisHelper.FromXfAxisAlignment(value);
        }

        private void OnAxisVisibleRangeChanged(object sender, SciChart.Charting.Visuals.Axes.VisibleRangeChangeEventArgs e)
        {
            var handler = _visibleRangEventHandler;
            if (handler != null)
            {
               // TODO handler(sender, new VisibleRangeChangedEventArgs(e.OldRange, e.NewRange, e.IsAnimating));
            }
        }
    }
}