using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using SciChart.Charting.Model;
using SciChart.Xamarin.Views.Visuals.Axes;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    public class AxisCollectionAndroid : AxisCollection, IDisposable
    {
        private readonly ObservableCollection<IAxis> _crossPlatformSeries;

        public AxisCollectionAndroid(ObservableCollection<IAxis> crossPlatformSeries)
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
                this.Add((SciChart.Charting.Visuals.Axes.IAxis)((AxisCore)item).InnerAxis);
            }
        }

        public void Dispose()
        {
            _crossPlatformSeries.CollectionChanged -= OnCollectionChanged;
        }
    }
}