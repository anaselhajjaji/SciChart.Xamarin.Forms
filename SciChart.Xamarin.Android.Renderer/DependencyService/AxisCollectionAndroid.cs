using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using SciChart.Charting.Model;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Views.Visuals.Axes;
using IAxisXf = SciChart.Xamarin.Views.Visuals.Axes.IAxis;
using IAxisNative = SciChart.Charting.Visuals.Axes.IAxis;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    public class AxisCollectionAndroid : CollectionMapper<AxisCollection, IAxisXf, IAxisNative>
    {
        public AxisCollectionAndroid(AxisCollection nativeCollection, ObservableCollection<IAxisXf> xformsCollection) 
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