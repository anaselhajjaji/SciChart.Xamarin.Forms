using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using SciChart.Charting.Model;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using IRenderableSeriesXf = SciChart.Xamarin.Views.Visuals.RenderableSeries.IRenderableSeries;
using IRenderableSeriesAndroid = SciChart.Charting.Visuals.RenderableSeries.IRenderableSeries;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{ 
    public class RenderableSeriesCollectionAndroid : CollectionMapper<RenderableSeriesCollection, IRenderableSeriesXf, IRenderableSeriesAndroid>
    {
        public RenderableSeriesCollectionAndroid(RenderableSeriesCollection nativeCollection, ObservableCollection<IRenderableSeriesXf> xformsCollection)
            : base(nativeCollection, xformsCollection)
        {
        }

        protected override void OnCleared(RenderableSeriesCollection destCollection)
        {
            destCollection.Clear();
        }

        protected override void OnAdded(RenderableSeriesCollection destCollection, IRenderableSeriesXf item)
        {
            destCollection.Add((IRenderableSeriesAndroid)((CrossPlatformRenderableSeriesBase)item).InnerSeries);
        }
    }
}