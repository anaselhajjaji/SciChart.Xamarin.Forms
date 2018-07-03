using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using IRenderableSeries = SciChart.Xamarin.Views.Visuals.RenderableSeries.IRenderableSeries;

namespace SciChart.Xamarin.Wpf.Renderer.DependencyService
{    
    public class RenderableSeriesCollectionWpf : ObservableCollection<SciChart.Charting.Visuals.RenderableSeries.IRenderableSeries>
    {
        private readonly ObservableCollection<IRenderableSeries> _crossPlatformSeries;

        public RenderableSeriesCollectionWpf(ObservableCollection<IRenderableSeries> crossPlatformSeries)
        {
            _crossPlatformSeries = crossPlatformSeries;
            _crossPlatformSeries.CollectionChanged += OnCollectionChanged;

            OnCollectionChanged(null, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.Clear();
            foreach (var item in _crossPlatformSeries)
            {
                this.Add((SciChart.Charting.Visuals.RenderableSeries.IRenderableSeries)((CrossPlatformRenderableSeriesBase)item).InnerSeries);
            }
        }

        public void Dispose()
        {
            _crossPlatformSeries.CollectionChanged -= OnCollectionChanged;
        }
    }
}