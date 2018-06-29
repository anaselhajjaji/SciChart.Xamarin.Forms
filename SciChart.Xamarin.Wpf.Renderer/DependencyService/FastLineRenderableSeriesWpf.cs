using System;
using SciChart.Charting.Model.DataSeries;
using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using SciChart.Xamarin.Wpf.Renderer.Utility;
using Xamarin.Forms;
using FastLineRenderableSeries = SciChart.Charting.Visuals.RenderableSeries.FastLineRenderableSeries;
using IDataSeries = SciChart.Xamarin.Views.Model.DataSeries.IDataSeries;

namespace SciChart.Xamarin.Wpf.Renderer.DependencyService
{
    internal class FastLineRenderableSeriesWpf : FastLineRenderableSeries, IFastLineRenderableSeries
    {
        private IDataSeries _dataSeries;

        public FastLineRenderableSeriesWpf()
        {
        }

        Color IRenderableSeries.Stroke
        {
            get => ColorUtil.ToXamarinColor(base.Stroke);
            set => base.Stroke = ColorUtil.FromXamarinColor(value);
        }

        IDataSeries IRenderableSeries.DataSeries
        {
            get => _dataSeries;
            set
            {
                _dataSeries = value;
                base.DataSeries = (Charting.Model.DataSeries.IDataSeries) ((CrossPlatformDataSeriesBase) _dataSeries)?.InnerSeries;
            }
        }

        public object BindingContext
        {
            get => base.DataContext;
            set => base.DataContext = value;
        }
    }
}