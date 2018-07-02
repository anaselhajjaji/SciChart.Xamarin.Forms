using System;
using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer.DependencyService;
using SciChart.Xamarin.iOS.Renderer.Utility;
using SciChart.Xamarin.Views.Helpers;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

namespace SciChart.Xamarin.iOS.Renderer
{
    public class SciChartSurfaceiOSPropertyMapper : PropertyMapper<SciChartSurfaceX, SCIChartSurface>
    {
        public SciChartSurfaceiOSPropertyMapper(SciChartSurfaceX sourceControl, SCIChartSurface targetControl) : base(targetControl)
        {
            this.Add(SciChartSurfaceX.RenderableSeriesProperty.PropertyName, OnRenderableSeriesChanged);
            this.Add(SciChartSurfaceX.ChartTitleProperty.PropertyName, (s, d) => { d.ChartTitle = s.ChartTitle; });
            this.Add(SciChartSurfaceX.BackgroundColorProperty.PropertyName, UpdateChartStyle);
            this.Add(SciChartSurfaceX.ForegroundColorProperty.PropertyName, UpdateChartStyle);
            this.Init(sourceControl);
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