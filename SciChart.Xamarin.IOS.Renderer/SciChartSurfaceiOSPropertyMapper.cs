using System;
using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer.DependencyService;
using SciChart.Xamarin.iOS.Renderer.Utility;
using SciChart.Xamarin.Views.Utility;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

namespace SciChart.Xamarin.iOS.Renderer
{
    public class SciChartSurfaceiOSPropertyMapper : PropertyMapper<SciChartSurfaceX, SCIChartSurface>
    {
        private AxisCollectioniOS _xAxesCollection;
        private AxisCollectioniOS _yAxesCollection;
        private RenderableSeriesCollectioniOS _rSeriesCollection;

        public SciChartSurfaceiOSPropertyMapper(SciChartSurfaceX sourceControl, SCIChartSurface targetControl) : base(sourceControl, targetControl)
        {
            this.Add(SciChartSurfaceX.RenderableSeriesProperty.PropertyName, OnRenderableSeriesChanged);
            this.Add(SciChartSurfaceX.ChartTitleProperty.PropertyName, (s, d) => { d.ChartTitle = s.ChartTitle; });
            this.Add(SciChartSurfaceX.BackgroundColorProperty.PropertyName, UpdateChartStyle);
            this.Add(SciChartSurfaceX.ForegroundColorProperty.PropertyName, UpdateChartStyle);
            this.Add(SciChartSurfaceX.XAxesProperty.PropertyName, OnXAxesChanged);
            this.Add(SciChartSurfaceX.YAxesProperty.PropertyName, OnYAxesChanged);
            this.Init();
        }

        private void OnRenderableSeriesChanged(SciChartSurfaceX source, SCIChartSurface target)
        {
            _rSeriesCollection?.Dispose();
            _rSeriesCollection = new RenderableSeriesCollectioniOS(target.RenderableSeries, source.RenderableSeries);
        }

        private void UpdateChartStyle(SciChartSurfaceX source, SCIChartSurface target)
        {
            target.ChartTitleColor = ColorUtil.FromXamarinColor(source.ForegroundColor);
            target.BackgroundColor = ColorUtil.FromXamarinColor(source.BackgroundColor);
            target.Opaque = Math.Abs(source.BackgroundColor.A - 1.0) < 0.01;
        }

        private void OnXAxesChanged(SciChartSurfaceX source, SCIChartSurface target)
        {
            _xAxesCollection?.Dispose();
            _xAxesCollection = new AxisCollectioniOS(target.XAxes, source.XAxes);
        }

        private void OnYAxesChanged(SciChartSurfaceX source, SCIChartSurface target)
        {
            _yAxesCollection?.Dispose();
            _yAxesCollection = new AxisCollectioniOS(target.YAxes, source.YAxes);
        }
    }
}