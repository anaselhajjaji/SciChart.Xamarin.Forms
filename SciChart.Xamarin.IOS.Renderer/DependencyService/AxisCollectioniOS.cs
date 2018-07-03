using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Foundation;
using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Views.Visuals.Axes;
using IAxisXf = SciChart.Xamarin.Views.Visuals.Axes.IAxis;
using IAxisNative = SciChart.iOS.Charting.ISCIAxis2DProtocol;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    [Register]
    public class AxisCollectioniOS : CollectionMapper<SCIAxisCollection, IAxisXf, IAxisNative>
    {
        public AxisCollectioniOS(SCIAxisCollection nativeCollection, ObservableCollection<IAxis> xformsCollection) : base(nativeCollection, xformsCollection)
        {
        }

        protected override void OnCleared(SCIAxisCollection destCollection)
        {
            destCollection.Clear();
        }

        protected override void OnAdded(SCIAxisCollection destCollection, IAxisXf item)
        {
            destCollection.Add((IAxisNative)((AxisCore)item).InnerAxis);
        }
    }
}