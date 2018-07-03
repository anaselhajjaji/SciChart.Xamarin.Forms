using System;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Visuals.Axes;
using WpfAxisAlignment = SciChart.Charting.Visuals.Axes.AxisAlignment;
using WpfAutoRange = SciChart.Charting.Visuals.Axes.AutoRange;

namespace SciChart.Xamarin.Wpf.Renderer.Utility
{
    internal static class AxisHelper
    {
        internal static AxisAlignment ToXfAxisAlignemnt(WpfAxisAlignment wpfAxisAlignment)
        {
            if (wpfAxisAlignment == WpfAxisAlignment.Left) return AxisAlignment.Left;
            if (wpfAxisAlignment == WpfAxisAlignment.Bottom) return AxisAlignment.Bottom;
            if (wpfAxisAlignment == WpfAxisAlignment.Right) return AxisAlignment.Right;
            if (wpfAxisAlignment == WpfAxisAlignment.Top) return AxisAlignment.Top;
            if (wpfAxisAlignment == WpfAxisAlignment.Default) return AxisAlignment.Default;

            throw new NotImplementedException("The AxisAlignment " + wpfAxisAlignment.ToString() +
                                              " has not been handled");
        }

        internal static WpfAxisAlignment FromXfAxisAlignment(AxisAlignment xfAxisAlignment)
        {
            switch (xfAxisAlignment)
            {
                case AxisAlignment.Left: return WpfAxisAlignment.Left;
                case AxisAlignment.Bottom: return WpfAxisAlignment.Bottom;
                case AxisAlignment.Right: return WpfAxisAlignment.Right;
                case AxisAlignment.Top: return WpfAxisAlignment.Top;
                case AxisAlignment.Default: return WpfAxisAlignment.Default;
                default:
                    throw new NotImplementedException("The AxisAlignment " + xfAxisAlignment.ToString() +
                                                      " has not been handled");
            }
        }

        public static AutoRange ToXfAutoRange(Charting.Visuals.Axes.AutoRange wpfAutoRange)
        {
            switch (wpfAutoRange)
            {
                case WpfAutoRange.Always: return AutoRange.Always;
                case WpfAutoRange.Once: return AutoRange.Once;
                case WpfAutoRange.Never: return AutoRange.Never;
                default:
                    throw new NotImplementedException("The AutoRange value " + wpfAutoRange.ToString() + " has not been handled");
            }
        }

        public static Charting.Visuals.Axes.AutoRange FromXfAutoRange(AutoRange xfAutoRange)
        {
            switch (xfAutoRange)
            {
                case AutoRange.Always: return WpfAutoRange.Always;
                case AutoRange.Once: return WpfAutoRange.Once;
                case AutoRange.Never: return WpfAutoRange.Never;                
                default:
                    throw new NotImplementedException("The AutoRange value " + xfAutoRange.ToString() + " has not been handled");
            }
        }
    }
}