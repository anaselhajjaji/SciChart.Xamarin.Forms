using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Foundation;
using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Visuals.Axes;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    [Register]
    public class AxisCollectioniOS : IDisposable
    {
        private readonly SCIAxisCollection _targetCollection;
        private readonly ObservableCollection<IAxis> _crossPlatformSeries;

        public AxisCollectioniOS(SCIAxisCollection targetCollection, ObservableCollection<IAxis> crossPlatformSeries)
        {
            _targetCollection = targetCollection;
            _crossPlatformSeries = crossPlatformSeries;
            _crossPlatformSeries.CollectionChanged += OnCollectionChanged;

            OnCollectionChanged(null, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            _targetCollection.Clear();
            foreach (var item in _crossPlatformSeries)
            {
                _targetCollection.Add((ISCIAxis2DProtocol)((AxisCore)item).InnerAxis);
            }
        }

        public void Dispose()
        {
            _crossPlatformSeries.CollectionChanged -= OnCollectionChanged;
        }
    }
}