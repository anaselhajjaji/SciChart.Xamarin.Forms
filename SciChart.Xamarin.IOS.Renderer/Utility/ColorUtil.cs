using SciChart.iOS.Charting;
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

        private static Color ToXamarinColor(UIColor color)
        {
            System.nfloat r, g, b, a;
            color.GetRGBA(out r, out g, out b, out a);
            return new Color(r, g, b, a);
        }

        public static Color BrushToXamarinColor(SCIBrushStyle sciBrush)
        {
            return ToXamarinColor(sciBrush.Color);
        }        

        public static SCIBrushStyle BrushFromXamarinColor(Color value)
        {
            return new SCIBrushStyle() { Color = FromXamarinColor(value )};
        }
    }
}