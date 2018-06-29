using System;
using System.Collections.Generic;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    public class XyDataSeriesAndroid<TX, TY> : SciChart.Charting.Model.DataSeries.XyDataSeries<TX, TY>, Views.Model.DataSeries.IXyDataSeries<TX, TY>
        where TY : IComparable
        where TX : IComparable
    {
        public IList<TX> XValues { get {  throw new NotImplementedException(); } }
        public IList<TY> YValues { get { throw new NotImplementedException(); } }
    }
}