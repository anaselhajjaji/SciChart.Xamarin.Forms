using System;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Visuals.Axes;
using AndroidAutoRange = SciChart.Charting.Visuals.Axes.AutoRange;
using XfAutoRange = SciChart.Xamarin.Views.Model.AutoRange;

namespace SciChart.Xamarin.Android.Renderer.Utility
{
    public static class AxisHelper
    {
        public static AxisAlignment ToXfAxisAlignemnt(Charting.Visuals.Axes.AxisAlignment androidAxisAlignment)
        {
            if (androidAxisAlignment == Charting.Visuals.Axes.AxisAlignment.Left) return AxisAlignment.Left;
            if (androidAxisAlignment == Charting.Visuals.Axes.AxisAlignment.Bottom) return AxisAlignment.Bottom;
            if (androidAxisAlignment == Charting.Visuals.Axes.AxisAlignment.Right) return AxisAlignment.Right;
            if (androidAxisAlignment == Charting.Visuals.Axes.AxisAlignment.Top) return AxisAlignment.Top;
            if (androidAxisAlignment == Charting.Visuals.Axes.AxisAlignment.Auto) return AxisAlignment.Default;

            throw new NotImplementedException("The AxisAlignment " + androidAxisAlignment.ToString() +
                                              " has not been handled");
        }

        public static Charting.Visuals.Axes.AxisAlignment FromXfAxisAlignment(AxisAlignment xfAxisAlignment)
        {
            switch (xfAxisAlignment)
            {
                case AxisAlignment.Left: return Charting.Visuals.Axes.AxisAlignment.Left;
                case AxisAlignment.Bottom: return Charting.Visuals.Axes.AxisAlignment.Bottom;
                case AxisAlignment.Right: return Charting.Visuals.Axes.AxisAlignment.Right;
                case AxisAlignment.Top: return Charting.Visuals.Axes.AxisAlignment.Top;
                case AxisAlignment.Default: return Charting.Visuals.Axes.AxisAlignment.Auto;
                default:
                    throw new NotImplementedException("The AxisAlignment " + xfAxisAlignment.ToString() +
                                                      " has not been handled");
            }
        }

        public static XfAutoRange ToXfAutoRange(AndroidAutoRange nativeAutoRange)
        {
            if (nativeAutoRange == AndroidAutoRange.Once) return XfAutoRange.Once;
            if (nativeAutoRange == AndroidAutoRange.Always) return XfAutoRange.Always;
            if (nativeAutoRange == AndroidAutoRange.Never) return XfAutoRange.Never;

            throw new NotImplementedException("The AutoRange value " + nativeAutoRange.ToString() + " has not been handled");
        }

        public static AndroidAutoRange FromXfAutoRange(XfAutoRange xfAutoRange)
        {
            switch (xfAutoRange)
            {
                case XfAutoRange.Always: return AndroidAutoRange.Always;
                case XfAutoRange.Once: return AndroidAutoRange.Once;
                case XfAutoRange.Never: return AndroidAutoRange.Never;
                default:
                    throw new NotImplementedException("The AutoRange value " + xfAutoRange.ToString() + " has not been handled");
            }
        }
    }
}