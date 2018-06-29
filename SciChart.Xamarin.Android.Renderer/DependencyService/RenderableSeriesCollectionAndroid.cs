using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using SciChart.Charting.Model;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    public class RenderableSeriesCollectionAndroid : RenderableSeriesCollection, IDisposable
    {
        private readonly ObservableCollection<IRenderableSeries> _crossPlatformSeries;

        public RenderableSeriesCollectionAndroid(ObservableCollection<IRenderableSeries> crossPlatformSeries)
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