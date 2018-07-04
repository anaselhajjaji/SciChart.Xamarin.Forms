using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using IRenderableSeriesXf = SciChart.Xamarin.Views.Visuals.RenderableSeries.IRenderableSeries;
using IRenderableSeriesiOS = SciChart.iOS.Charting.ISCIRenderableSeriesProtocol;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    public class RenderableSeriesCollectioniOS : CollectionMapper<SCIRenderableSeriesCollection, IRenderableSeriesXf>
    {
        public RenderableSeriesCollectioniOS(SCIRenderableSeriesCollection nativeCollection, ObservableCollection<IRenderableSeriesXf> xformsCollection)
            : base(nativeCollection, xformsCollection)
        {
        }

        protected override void OnCleared(SCIRenderableSeriesCollection destCollection)
        {
            destCollection.Clear();
        }

        protected override void OnAdded(SCIRenderableSeriesCollection destCollection, IRenderableSeriesXf item)
        {
            destCollection.Add((IRenderableSeriesiOS)((CrossPlatformRenderableSeriesBase)item).NativeSeries);
        }
    }
}