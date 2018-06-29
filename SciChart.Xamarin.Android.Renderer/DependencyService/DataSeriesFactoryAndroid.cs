using System;
using System.Collections;
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
using SciChart.Xamarin.Views.Visuals.RenderableSeries;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    public class DataSeriesFactoryAndroid : IDataSeriesFactory
    {
        public Views.Model.DataSeries.IXyDataSeries<TX, TY> NewXyDataSeries<TX, TY>() where TX : IComparable where TY : IComparable
        {
            return new XyDataSeriesAndroid<TX, TY>();
        }
    }
}