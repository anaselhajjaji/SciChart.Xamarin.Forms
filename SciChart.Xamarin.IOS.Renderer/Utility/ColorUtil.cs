using UIKit;
using Xamarin.Forms;

namespace SciChart.Xamarin.iOS.Renderer.Utility
{
    public static class ColorUtil
    {
        public static UIColor FromXamarinColor(Color xfColor)
        {
            UIKit.UIColor uiColor = UIColor.FromRGBA(
                (byte)(xfColor.R * 255),
                (byte)(xfColor.G * 255),
                (byte)(xfColor.B * 255),
                (byte)(xfColor.A * 255));

            return uiColor;
        }
    }
}