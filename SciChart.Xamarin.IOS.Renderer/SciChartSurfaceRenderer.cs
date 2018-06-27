using System.ComponentModel;
using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace SciChart.Xamarin.iOS.Renderer
{
    public class SciChartSurfaceRenderer : ViewRenderer<SciChart.Xamarin.Views.Visuals.SciChartSurface, SciChart.iOS.Charting.SCIChartSurface>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SciChart.Xamarin.Views.Visuals.SciChartSurface> e)
        {
            var sciChartSurfaceView = e.NewElement as SciChart.Xamarin.Views.Visuals.SciChartSurface;
            if (Control == null)
            {
                this.SetNativeControl(new SCIChartSurface());

                // Some dummy data 
                Control.XAxes.Add(new SCINumericAxis());
                Control.YAxes.Add(new SCINumericAxis());
                Control.XAxes[0].VisibleRange = new SCIDoubleRange(0, 10);
                Control.YAxes[0].VisibleRange = new SCIDoubleRange(0, 10);
            }

            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }
}
