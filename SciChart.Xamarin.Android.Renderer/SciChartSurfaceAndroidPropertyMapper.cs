using System;
using SciChart.Charting.Visuals;
using SciChart.Xamarin.Android.Renderer.DependencyService;
using SciChart.Xamarin.Views.Utility;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

namespace SciChart.Xamarin.Android.Renderer
{
    public class SciChartSurfaceAndroidPropertyMapper : PropertyMapper<SciChartSurfaceX, SciChartSurface>
    {
        public SciChartSurfaceAndroidPropertyMapper(SciChartSurfaceX sourceControl, Charting.Visuals.SciChartSurface targetControl) : base(targetControl)
        {
            this.Add(SciChartSurfaceX.RenderableSeriesProperty.PropertyName, OnRenderableSeriesChanged);
            this.Add(SciChartSurfaceX.ChartTitleProperty.PropertyName, (s, d) => { }); // TODO: ChartTitle not supported in android
//            this.Add(SciChartSurfaceX.BackgroundColorProperty.PropertyName, (s, d) => d.Background = new SolidColorBrush(ColorUtil.FromXamarinColor(s.BackgroundColor)));
//            this.Add(SciChartSurfaceX.ForegroundColorProperty.PropertyName, (s, d) => d.Foreground = new SolidColorBrush(ColorUtil.FromXamarinColor(s.ForegroundColor)));
            this.Add(SciChartSurfaceX.XAxesProperty.PropertyName, OnXAxesChanged);
            this.Add(SciChartSurfaceX.YAxesProperty.PropertyName, OnYAxesChanged);
            this.Init(sourceControl);
        }

        private void OnRenderableSeriesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            (target.RenderableSeries as IDisposable)?.Dispose();
            target.RenderableSeries = new RenderableSeriesCollectionAndroid(source.RenderableSeries);
        }

        private void OnXAxesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            (target.XAxes as IDisposable)?.Dispose();
            target.XAxes = new AxisCollectionAndroid(source.XAxes);
        }

        private void OnYAxesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            (target.YAxes as IDisposable)?.Dispose();
            target.YAxes = new AxisCollectionAndroid(source.YAxes);
        }
    }
}