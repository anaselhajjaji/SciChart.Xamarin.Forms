﻿using System;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Wpf.Renderer.Utility;
using Xamarin.Forms;
using NumericAxisNative = SciChart.Charting.Visuals.Axes.NumericAxis;
using NumericAxisXf = SciChart.Xamarin.Views.Visuals.Axes.NumericAxis;


namespace SciChart.Xamarin.Wpf.Renderer.DependencyService
{
    internal class NumericAxisWpf : NumericAxisNative, INumericAxis
    {
        private readonly NumericAxis _xfNumericAxis;

        public NumericAxisWpf(NumericAxisXf xfNumericAxis)
        {
            _xfNumericAxis = xfNumericAxis;
        }

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

        DoubleRange IAxisCore.GrowBy
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
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