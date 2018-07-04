using System;
using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer.Utility;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Visuals.Axes;
using Xamarin.Forms;
using NumericAxisXf = SciChart.Xamarin.Views.Visuals.Axes.NumericAxis;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    [Foundation.Register]
    internal class NumericAxisiOS : SCINumericAxis, INumericAxis
    {
        private NumericAxisXf _xfNumericAxis;

        public NumericAxisiOS(NumericAxisXf xfNumericAxis)
        {
            this._xfNumericAxis = xfNumericAxis;
        }

        event EventHandler<VisibleRangeChangedEventArgs> IAxisCore.VisibleRangeChanged
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        public bool DrawMinorTicks
        {
            get => base.Style.DrawMinorTicks;
            set => base.Style.DrawMinorTicks = value;
        }

        public bool DrawLabels
        {
            get => base.Style.DrawLabels;
            set => base.Style.DrawLabels = value;
        }
        public bool DrawMajorTicks
        {
            get => base.Style.DrawMajorTicks;
            set => base.Style.DrawMajorTicks = value;
        }

        bool IAxisCore.DrawMajorGridLines
        {
            get => base.Style.DrawMajorGridLines;
            set => base.Style.DrawMajorGridLines = value;
        }

        bool IAxisCore.DrawMinorGridLines
        {
            get => base.Style.DrawMinorGridLines;
            set => base.Style.DrawMinorGridLines = value;
        }

        bool IAxisCore.DrawMajorBands
        {
            get => base.Style.DrawMajorBands;
            set => base.Style.DrawMajorBands = value;
        }

        public Color AxisBandsFill
        {
            get => ColorUtil.BrushToXamarinColor(base.Style.GridBandBrush);
            set => base.Style.GridBandBrush = ColorUtil.BrushFromXamarinColor(value);
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

        public IDoubleRange GrowBy
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }        

        AxisAlignment IAxis.AxisAlignment
        {
            get => AxisHelper.ToXfAxisAlignemnt(base.AxisAlignment);
            set => base.AxisAlignment = AxisHelper.FromXfAxisAlignment(value);
        }
    }
}