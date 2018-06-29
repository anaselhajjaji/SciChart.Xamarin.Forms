using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    public class XyDataSeries<TX,TY> : CrossPlatformDataSeriesBase, IXyDataSeries<TX,TY> 
        where TX:IComparable
        where TY:IComparable
    {
        private static readonly IDataSeriesFactory Factory = DependencyService.Get<IDataSeriesFactory>();

        public XyDataSeries()
        {
            InnerSeries = Factory.NewXyDataSeries<TX, TY>();
        }

        public string SeriesName
        {
            get => InnerSeries.SeriesName;
            set => InnerSeries.SeriesName = value;
        }

        public int Count
        {
            get => InnerSeries.Count;
        }

        public bool AcceptsUnsortedData
        {
            get => InnerSeries.AcceptsUnsortedData;
            set => InnerSeries.AcceptsUnsortedData = value;
        }

        public void Clear()
        {
            InnerSeries.Clear();
        }

        public void Append(TX x, TY y)
        {
            ((IXyDataSeries<TX,TY>)InnerSeries).Append(x,y);
        }

        public IList<TX> XValues
        {
            get => ((IXyDataSeries<TX, TY>)InnerSeries).XValues;
        }

        public IList<TY> YValues
        {
            get => ((IXyDataSeries<TX, TY>)InnerSeries).YValues;
        }
    }
}
