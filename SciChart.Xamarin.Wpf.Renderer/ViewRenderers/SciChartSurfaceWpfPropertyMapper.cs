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
        private RenderableSeriesCollectionWpf _rSeriesCollection;
        private AxisCollectionWpf _xAxesCollection;
        private AxisCollectionWpf _yAxesCollection;

        public SciChartSurfaceWpfPropertyMapper(SciChartSurfaceX sourceControl, SciChartSurface targetControl) : base(sourceControl, targetControl)
        {
            this.Add(SciChartSurfaceX.RenderableSeriesProperty.PropertyName, OnRenderableSeriesChanged);
            this.Add(SciChartSurfaceX.ChartTitleProperty.PropertyName, (s, d) => d.ChartTitle = s.ChartTitle);
            this.Add(SciChartSurfaceX.BackgroundColorProperty.PropertyName, (s, d) => d.Background = new SolidColorBrush(ColorUtil.FromXamarinColor(s.BackgroundColor)));
            this.Add(SciChartSurfaceX.ForegroundColorProperty.PropertyName, (s, d) => d.Foreground = new SolidColorBrush(ColorUtil.FromXamarinColor(s.ForegroundColor)));
            this.Add(SciChartSurfaceX.XAxesProperty.PropertyName, OnXAxesChanged);
            this.Add(SciChartSurfaceX.YAxesProperty.PropertyName, OnYAxesChanged);

            this.Init();
        }        

        private void OnRenderableSeriesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            _rSeriesCollection?.Dispose();
            _rSeriesCollection = new RenderableSeriesCollectionWpf(target.RenderableSeries, source.RenderableSeries);
        }

        private void OnXAxesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            _xAxesCollection?.Dispose();
            _xAxesCollection = new AxisCollectionWpf(target.XAxes, source.XAxes);
        }

        private void OnYAxesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            _yAxesCollection?.Dispose();
            _yAxesCollection = new AxisCollectionWpf(target.YAxes, source.YAxes);
        }
    }
}