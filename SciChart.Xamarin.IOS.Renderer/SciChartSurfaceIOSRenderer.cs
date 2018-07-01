using System;
using System.ComponentModel;
using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer;
using SciChart.Xamarin.iOS.Renderer.DependencyService;
using SciChart.Xamarin.iOS.Renderer.Utility;
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
        private readonly string _license;

        public SciChartSurfaceIosRenderer()
        {
            // Apply license 
            if (_license == null)
            {
                _license = SciChartLicenseManager.GetLicense(SciChartPlatform.iOS);
                if (_license != null)
                {
                    SCIChartSurface.SetRuntimeLicenseKey(_license);
                }
            }
        }

        // Note Crashes before any breakpoints hit 
        protected override void OnElementChanged(ElementChangedEventArgs<SciChart.Xamarin.Views.Visuals.SciChartSurface> e)
        {
            if (Control == null)
            {
                // Create the native control
                this.SetNativeControl(new SCIChartSurface());

                Control.TranslatesAutoresizingMaskIntoConstraints = true;

                // Set property mapper
                _propertyMapper = new PropertyMapper<SciChartSurfaceX, SCIChartSurface>(Control);
                _propertyMapper.Add(SciChartSurfaceX.RenderableSeriesProperty.PropertyName, OnRenderableSeriesChanged);
                _propertyMapper.Add(SciChartSurfaceX.ChartTitleProperty.PropertyName, (s, d) => { d.ChartTitle = s.ChartTitle; });
                _propertyMapper.Add(SciChartSurfaceX.BackgroundColorProperty.PropertyName, UpdateChartStyle);
                _propertyMapper.Add(SciChartSurfaceX.ForegroundColorProperty.PropertyName, UpdateChartStyle);
                _propertyMapper.Init(e.NewElement);

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

        private void OnRenderableSeriesChanged(SciChartSurfaceX source, SCIChartSurface target)
        {
            target.RenderableSeries = new RenderableSeriesCollectioniOS(source.RenderableSeries);
        }

        private void UpdateChartStyle(SciChartSurfaceX source, SCIChartSurface target)
        {
            target.ChartTitleColor = ColorUtil.FromXamarinColor(source.ForegroundColor);
            target.BackgroundColor = ColorUtil.FromXamarinColor(source.BackgroundColor);
            target.Opaque = Math.Abs(source.BackgroundColor.A - 1.0) < 0.01;
        }
    }
}
