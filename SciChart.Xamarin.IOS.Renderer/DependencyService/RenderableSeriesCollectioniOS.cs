using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    public class RenderableSeriesCollectioniOS : SCIRenderableSeriesCollection, IDisposable
    {
        private readonly ObservableCollection<IRenderableSeries> _crossPlatformSeries;

        public RenderableSeriesCollectioniOS(ObservableCollection<IRenderableSeries> crossPlatformSeries)
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
                this.Add((ISCIRenderableSeriesProtocol)((CrossPlatformRenderableSeriesBase)item).InnerSeries);
            }
        }

        public void Dispose()
        {
            _crossPlatformSeries.CollectionChanged -= OnCollectionChanged;
        }
    }
}