using System.Collections.ObjectModel;
using SciChart.Charting.Model;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Views.Visuals.Axes;
using IAxisXf = SciChart.Xamarin.Views.Visuals.Axes.IAxis;
using IAxisNative = SciChart.Charting.Visuals.Axes.IAxis;

namespace SciChart.Xamarin.Wpf.Renderer.DependencyService
{
    public class AxisCollectionWpf : CollectionMapper<AxisCollection, IAxisXf, IAxisNative>
    {
        public AxisCollectionWpf(AxisCollection nativeCollection, ObservableCollection<IAxis> xformsCollection)
            : base(nativeCollection, xformsCollection)
        {
        }

        protected override void OnCleared(AxisCollection destCollection)
        {
            destCollection.Clear();
        }

        protected override void OnAdded(AxisCollection destCollection, IAxisXf item)
        {
            destCollection.Add((IAxisNative)((AxisCore)item).InnerAxis);
        }
    }
}