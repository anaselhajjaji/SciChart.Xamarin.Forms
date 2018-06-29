using System;
using System.ComponentModel;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Data.Model;
using SciChart.Xamarin.Views;
using SciChart.Xamarin.Views.Helpers;
using SciChart.Xamarin.Wpf.Renderer.DependencyService;
using Xamarin.Forms.Platform.WPF;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

namespace SciChart.Xamarin.Wpf.Renderer.ViewRenderers
{
    public class SciChartSurfaceWpfRenderer : ViewRenderer<SciChartSurfaceX, SciChart.Charting.Visuals.SciChartSurface>
    {
        private static string _license;

        private PropertyMapper<SciChartSurfaceX, SciChartSurface> _propertyMapper;

        public SciChartSurfaceWpfRenderer()
        {
            // Apply license 
            if (_license == null)
            {
                _license = SciChartLicenseManager.GetLicense(SciChartPlatform.Wpf);
                if (_license != null)
                {
                    SciChartSurface.SetRuntimeLicenseKey(_license);
                }
            }            
        }                

        protected override void OnElementChanged(ElementChangedEventArgs<SciChart.Xamarin.Views.Visuals.SciChartSurface> e)
        {                        
            base.OnElementChanged(e);

            if (Control == null)
            {
                // Create the native control 
                this.SetNativeControl(new SciChartSurface());

                // Setup property mapper 
                _propertyMapper = new PropertyMapper<SciChartSurfaceX, SciChartSurface>(Control);
                _propertyMapper.Add(SciChartSurfaceX.RenderableSeriesProperty.PropertyName, OnRenderableSeriesChanged);
                _propertyMapper.Init(e.NewElement);

                // Some dummy data 
                Control.XAxes.Add(new NumericAxis());
                Control.YAxes.Add(new NumericAxis());
                Control.XAxes[0].VisibleRange = new DoubleRange(0, 10);
                Control.YAxes[0].VisibleRange = new DoubleRange(0, 10);
            }
        }        

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _propertyMapper?.OnElementPropertyChanged(sender, e);
            base.OnElementPropertyChanged(sender, e);
        }
            
        private void OnRenderableSeriesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            (target.RenderableSeries as IDisposable)?.Dispose();
            target.RenderableSeries = new RenderableSeriesCollectionWpf(source.RenderableSeries);
        }
    }
}

