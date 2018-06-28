using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SciChart.Data.Model;
using SciChart.Xamarin.Views.Model.DataSeries;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    public class XyDataSeries<TX, TY> : SciChart.Charting.Model.DataSeries.XyDataSeries<TX, TY>, Views.Model.DataSeries.IXyDataSeries<TX, TY>
        where TY : IComparable
        where TX : IComparable
    {
        public IList<TX> XValues { get {  throw new NotImplementedException(); } }
        public IList<TY> YValues { get { throw new NotImplementedException(); } }
    }


    public class DataSeriesFactory : IDataSeriesFactory
    {
        public Views.Model.DataSeries.IXyDataSeries<TX, TY> NewXyDataSeries<TX, TY>() where TX : IComparable where TY : IComparable
        {
            return new XyDataSeries<TX, TY>();
        }
    }
}