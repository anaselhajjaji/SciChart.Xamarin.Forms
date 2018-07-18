using System;
using System.Collections.Generic;
using System.ComponentModel;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Wpf.Renderer.Utility;
using Xamarin.Forms;
using NumericAxisNative = SciChart.Charting.Visuals.Axes.NumericAxis;
using NumericAxisXf = SciChart.Xamarin.Views.Visuals.Axes.NumericAxis;


namespace SciChart.Xamarin.Wpf.Renderer.DependencyService
{    
    public class NumericAxisPropertyMapper : BiDirectionalPropertyMapper<NumericAxisXf, NumericAxisNative>
    {
        public NumericAxisPropertyMapper(NumericAxisXf sourceControl, NumericAxisNative targetControl) : base(sourceControl, targetControl)
        {
            //this.Add(AxisCore.AxisBandsFillProperty.PropertyName, (s,t) => t.AxisBandsFill = ColorUtil.FromXamarinColor(s.AxisBandsFill));
        }
    }

    internal class NumericAxisWpf : NumericAxisNative, INumericAxis
    {
        private NumericAxisPropertyMapper _mapper;

        public NumericAxisWpf()
        {
            //_mapper = new NumericAxisPropertyMapper(xfNumericAxis, this);
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

        IDoubleRange IAxisCore.GrowBy
        {
            get
            {
                var gb = base.GrowBy;
                if (gb == null) return new DoubleRange(0, 0);
                return new DoubleRange(gb.Min, gb.Max);
            }
            set => base.GrowBy = ((DoubleRangeWpf) ((RangeBase) value).NativeRange);
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

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}