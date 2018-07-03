using System;
using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer.Utility;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Visuals.Axes;
using Xamarin.Forms;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    [Foundation.Register]
    internal class NumericAxisiOS : SCINumericAxis, INumericAxis
    {
        public bool DrawMinorTicks { get; set; }
        public bool DrawLabels { get; set; }
        public bool DrawMajorTicks { get; set; }
        public bool DrawMajorGridLines { get; set; }
        public bool DrawMinorGridLines { get; set; }
        public bool DrawMajorBands { get; set; }
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

        AxisAlignment IAxis.AxisAlignment
        {
            get => AxisHelper.ToXfAxisAlignemnt(base.AxisAlignment);
            set => base.AxisAlignment = AxisHelper.FromXfAxisAlignment(value);
        }
    }
}