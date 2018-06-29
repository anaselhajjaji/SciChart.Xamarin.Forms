using System;

namespace SciChart.Xamarin.Wpf.Renderer.DependencyService
{
    internal class XyDataSeriesWpf<TX, TY> : SciChart.Charting.Model.DataSeries.XyDataSeries<TX, TY>, Views.Model.DataSeries.IXyDataSeries<TX, TY>
        where TY : IComparable
        where TX : IComparable
    {
    }
}