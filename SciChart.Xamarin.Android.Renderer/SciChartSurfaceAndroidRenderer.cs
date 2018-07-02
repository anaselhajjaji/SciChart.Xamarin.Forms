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
using SciChart.Xamarin.Views.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

[assembly: ExportRenderer(typeof(SciChartSurfaceX), typeof(SciChartSurfaceAndroidRenderer))]

namespace SciChart.Xamarin.Android.Renderer
{
    public class SciChartSurfaceAndroidRenderer : ViewRenderer<SciChartSurfaceX, SciChartSurface>
    {
        private PropertyMapper<SciChartSurfaceX, SciChartSurface> _propertyMapper;
        private string _license;

        public SciChartSurfaceAndroidRenderer(Context context) : base(context) 
        {
            // Apply license 
            if (_license == null)
            {
                _license = SciChartLicenseManager.GetLicense(SciChartPlatform.Android);
                if (_license != null)
                {
                    SciChartSurface.SetRuntimeLicenseKey(_license);
                }
            }
        }        

        protected override void OnElementChanged(ElementChangedEventArgs<Views.Visuals.SciChartSurface> e)
        {
            if (Control == null)
            {
                // Create the native control 
                this.SetNativeControl(new SciChartSurface(Context));
                Control.RenderSurface = new RenderSurface(Context);

                // Setup the property mapper 
                _propertyMapper = new SciChartSurfaceAndroidPropertyMapper(e.NewElement, Control);                

                // Some dummy params. TODO Remove these
                Control.XAxes.Add(new NumericAxis(Context));
                Control.YAxes.Add(new NumericAxis(Context));                
            }

            base.OnElementChanged(e);
        }        

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _propertyMapper?.OnElementPropertyChanged(sender, e);   
            base.OnElementPropertyChanged(sender, e);
        }
    }
}
