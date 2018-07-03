using System;
using System.Windows.Media;
using SciChart.Charting.Visuals;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Wpf.Renderer.DependencyService;
using SciChart.Xamarin.Wpf.Renderer.Utility;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

namespace SciChart.Xamarin.Wpf.Renderer.ViewRenderers
{
    /// <summary>
    /// Maps property changes from <see cref="SciChart.Xamarin.Views.Visuals.SciChartSurface"/> to platform-specific <see cref="SciChartSurface"/>
    /// </summary>
    public class SciChartSurfaceWpfPropertyMapper : PropertyMapper<SciChartSurfaceX, SciChartSurface>
    {
        public SciChartSurfaceWpfPropertyMapper(SciChartSurfaceX sourceControl, SciChartSurface targetControl) : base(targetControl)
        {
            this.Add(SciChartSurfaceX.RenderableSeriesProperty.PropertyName, OnRenderableSeriesChanged);
            this.Add(SciChartSurfaceX.ChartTitleProperty.PropertyName, (s, d) => d.ChartTitle = s.ChartTitle);
            this.Add(SciChartSurfaceX.BackgroundColorProperty.PropertyName, (s, d) => d.Background = new SolidColorBrush(ColorUtil.FromXamarinColor(s.BackgroundColor)));
            this.Add(SciChartSurfaceX.ForegroundColorProperty.PropertyName, (s, d) => d.Foreground = new SolidColorBrush(ColorUtil.FromXamarinColor(s.ForegroundColor)));
            this.Add(SciChartSurfaceX.XAxesProperty.PropertyName, OnXAxesChanged);
            this.Add(SciChartSurfaceX.YAxesProperty.PropertyName, OnYAxesChanged);

            this.Init(sourceControl);
        }        

        private void OnRenderableSeriesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            (target.RenderableSeries as IDisposable)?.Dispose();
            target.RenderableSeries = new RenderableSeriesCollectionWpf(source.RenderableSeries);
        }

        private void OnXAxesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            (target.XAxes as IDisposable)?.Dispose();
            target.XAxes = new AxisCollectionWpf(source.XAxes);
        }

        private void OnYAxesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            (target.YAxes as IDisposable)?.Dispose();
            target.YAxes = new AxisCollectionWpf(source.YAxes);
        }
    }
}