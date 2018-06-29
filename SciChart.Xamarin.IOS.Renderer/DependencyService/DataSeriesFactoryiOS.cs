using System;
using SciChart.Xamarin.Views.Model.DataSeries;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    public class DataSeriesFactoryiOS : IDataSeriesFactory
    {
        public Views.Model.DataSeries.IXyDataSeries<TX, TY> NewXyDataSeries<TX, TY>() where TX : IComparable where TY : IComparable
        {
            return new XyDataSeriesiOS<TX, TY>();
        }
    }
}