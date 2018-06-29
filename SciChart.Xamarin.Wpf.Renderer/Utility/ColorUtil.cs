using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SciChart.Xamarin.Wpf.Renderer.Utility
{
    internal static class ColorUtil
    {
        internal const double OneOver255 = 1.0 / 255;

        internal static System.Windows.Media.Color FromXamarinColor(Color xfColor)
        {
            System.Windows.Media.Color wpColor = System.Windows.Media.Color.FromArgb(
                (byte)(xfColor.A * 255),
                (byte)(xfColor.R * 255),
                (byte)(xfColor.G * 255),
                (byte)(xfColor.B * 255));

            return wpColor;
        }

        internal static Color ToXamarinColor(System.Windows.Media.Color wpColor)
        {
            return new Color(wpColor.R * OneOver255, wpColor.G * OneOver255, wpColor.B * OneOver255, wpColor.A * OneOver255);
        }
    }
}
