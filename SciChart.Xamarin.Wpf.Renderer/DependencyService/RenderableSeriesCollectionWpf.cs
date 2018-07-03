using System.Collections.ObjectModel;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using IRenderableSeriesXf = SciChart.Xamarin.Views.Visuals.RenderableSeries.IRenderableSeries;
using IRenderableSeriesWpf = SciChart.Charting.Visuals.RenderableSeries.IRenderableSeries;

namespace SciChart.Xamarin.Wpf.Renderer.DependencyService
{    
    public class RenderableSeriesCollectionWpf : CollectionMapper<ObservableCollection<IRenderableSeriesWpf>, IRenderableSeriesXf>
    {
        public RenderableSeriesCollectionWpf(ObservableCollection<IRenderableSeriesWpf> nativeCollection, ObservableCollection<IRenderableSeriesXf> xformsCollection) 
            : base(nativeCollection, xformsCollection)
        {
        }

        protected override void OnCleared(ObservableCollection<IRenderableSeriesWpf> destCollection)
        {
            destCollection.Clear();            
        }

        protected override void OnAdded(ObservableCollection<IRenderableSeriesWpf> destCollection, IRenderableSeriesXf item)
        {
            destCollection.Add((IRenderableSeriesWpf)((CrossPlatformRenderableSeriesBase)item).InnerSeries);
        }
    }
}