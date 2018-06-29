using System.ComponentModel;
using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer;
using SciChart.Xamarin.Views;
using SciChart.Xamarin.Views.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

namespace SciChart.Xamarin.iOS.Renderer
{
    public class SciChartSurfaceIosRenderer : ViewRenderer<SciChartSurfaceX, SCIChartSurface>
    {
        private PropertyMapper<SciChartSurfaceX, SCIChartSurface> _propertyMapper;

        public SciChartSurfaceIosRenderer()
        {
            // Apply license
            var license = SciChartLicenseManager.GetLicense(SciChartPlatform.iOS);
            if (license != null)
            {
                SCIChartSurface.SetRuntimeLicenseKey(license);
            }
        }

        // Note Crashes before any breakpoints hit 
        protected override void OnElementChanged(ElementChangedEventArgs<SciChart.Xamarin.Views.Visuals.SciChartSurface> e)
        {
            if (Control == null)
            {
                // Create the native control
                this.SetNativeControl(new SCIChartSurface());

                // Set property mapper
                _propertyMapper = new PropertyMapper<SciChartSurfaceX, SCIChartSurface>(Control);

                // Some dummy data TODO Remove 
                Control.XAxes.Add(new SCINumericAxis());
                Control.YAxes.Add(new SCINumericAxis());
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
