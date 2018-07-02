using System;
using SciChart.Charting.Visuals;
using SciChart.Xamarin.Android.Renderer.DependencyService;
using SciChart.Xamarin.Views.Helpers;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

namespace SciChart.Xamarin.Android.Renderer
{
    public class SciChartSurfaceAndroidPropertyMapper : PropertyMapper<SciChartSurfaceX, SciChartSurface>
    {
        public SciChartSurfaceAndroidPropertyMapper(SciChartSurfaceX sourceControl, Charting.Visuals.SciChartSurface targetControl) : base(targetControl)
        {
            this.Add(SciChartSurfaceX.RenderableSeriesProperty.PropertyName, OnRenderableSeriesChanged);
            this.Add(SciChartSurfaceX.ChartTitleProperty.PropertyName, (s, d) => { }); // TODO: ChartTitle not supported in android
            this.Init(sourceControl);
        }

        private void OnRenderableSeriesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            (target.RenderableSeries as IDisposable)?.Dispose();
            target.RenderableSeries = new RenderableSeriesCollectionAndroid(source.RenderableSeries);
        }
    }
}