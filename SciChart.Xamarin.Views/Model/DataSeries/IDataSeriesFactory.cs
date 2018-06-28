using System;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    public interface IDataSeriesFactory
    {
        IXyDataSeries<TX,TY> NewXyDataSeries<TX, TY>() where TX : IComparable where TY : IComparable;
    }
}