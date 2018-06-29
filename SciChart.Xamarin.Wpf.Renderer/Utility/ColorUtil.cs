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
        internal static System.Windows.Media.Color FromXamarinColor(Color color)
        {
            return System.Windows.Media.Color.FromArgb((byte) color.A, (byte) color.R, (byte) color.G, (byte) color.B);
        }

        internal static Color ToXamarinColor(System.Windows.Media.Color color)
        {
            return new Color(color.R, color.G, color.B, color.A);
        }
    }
}
