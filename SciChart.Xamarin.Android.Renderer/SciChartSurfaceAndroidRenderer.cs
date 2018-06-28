using System;
using System.Collections.Generic;
using System.ComponentModel;
using Android.Content;
using Java.Util;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Data.Model;
using SciChart.Drawing.Canvas;
using SciChart.Drawing.OpenGL;
using SciChart.Xamarin.Android.Renderer;
using SciChart.Xamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SciChart.Xamarin.Views.Visuals.SciChartSurface), typeof(SciChartSurfaceAndroidRenderer))]

namespace SciChart.Xamarin.Android.Renderer
{
    public class SciChartSurfaceAndroidRenderer : ViewRenderer<SciChart.Xamarin.Views.Visuals.SciChartSurface, SciChart.Charting.Visuals.SciChartSurface>
    {
        private readonly Dictionary<string, Action<SciChart.Xamarin.Views.Visuals.SciChartSurface, SciChart.Charting.Visuals.SciChartSurface>> _propertyMap;
        
        public SciChartSurfaceAndroidRenderer(Context context) : base(context) 
        {
            _propertyMap = new Dictionary<string, Action<Views.Visuals.SciChartSurface, SciChartSurface>>
            {
                {"Width", OnWidthChanged},
                {"Height", OnHeightChanged}
            };

            var license = SciChartLicenseManager.GetLicense(SciChartPlatform.Android);
            if (license != null)
            {
                SciChartSurface.SetRuntimeLicenseKey(license);
            }
        }        

        protected override void OnElementChanged(ElementChangedEventArgs<Views.Visuals.SciChartSurface> e)
        {
            var sciChartSurfaceView = e.NewElement as SciChart.Xamarin.Views.Visuals.SciChartSurface;
            if (Control == null)
            {
                this.SetNativeControl(new SciChartSurface(Context));
                Control.RenderSurface = new RenderSurface(Context);
                
                // Some dummy data 
                Control.XAxes.Add(new NumericAxis(Context));
                Control.YAxes.Add(new NumericAxis(Context));
                //Control.XAxes[0].VisibleRange = new DoubleRange(0, 10);
                //Control.YAxes[0].VisibleRange = new DoubleRange(0, 10);
            }

            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_propertyMap.TryGetValue(e.PropertyName, out var handler))
            {
                var sciChartSurfaceView = sender as SciChart.Xamarin.Views.Visuals.SciChartSurface;
                handler(sciChartSurfaceView, Control);
            }
            base.OnElementPropertyChanged(sender, e);
        }

        private void OnWidthChanged(Views.Visuals.SciChartSurface scsView, SciChartSurface scsAndroid)
        {
            //scsAndroid.LayoutParameters.Width = (int) scsView.Width;
        }

        private void OnHeightChanged(Views.Visuals.SciChartSurface scsView, SciChartSurface scsAndroid)
        {
            //scsAndroid.LayoutParameters.Height = (int)scsView.Height;
        }
    }
}
