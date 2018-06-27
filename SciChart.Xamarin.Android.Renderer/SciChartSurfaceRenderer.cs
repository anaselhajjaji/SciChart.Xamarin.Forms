using System;
using System.ComponentModel;
using Android.Content;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Data.Model;
using SciChart.Xamarin.Android.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SciChart.Xamarin.Views.Visuals.SciChartSurface), typeof(SciChartSurfaceRenderer))]

namespace SciChart.Xamarin.Android.Renderer
{
    public class SciChartSurfaceRenderer : ViewRenderer<SciChart.Xamarin.Views.Visuals.SciChartSurface, SciChart.Charting.Visuals.SciChartSurface>
    {
        protected SciChartSurfaceRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Views.Visuals.SciChartSurface> e)
        {
            var sciChartSurfaceView = e.NewElement as SciChart.Xamarin.Views.Visuals.SciChartSurface;
            if (Control == null)
            {
                this.SetNativeControl(new SciChartSurface(Context));

                // Some dummy data 
                Control.XAxes.Add(new NumericAxis(Context));
                Control.YAxes.Add(new NumericAxis(Context));
                Control.XAxes[0].VisibleRange = new DoubleRange(0, 10);
                Control.YAxes[0].VisibleRange = new DoubleRange(0, 10);
            }

            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }
}
