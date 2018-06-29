using System;
using System.Collections.Generic;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    public class XyDataSeriesiOS<TX, TY> : SciChart.iOS.Charting.XyDataSeries<TX, TY>,
        Views.Model.DataSeries.IXyDataSeries<TX, TY>
        where TY : IComparable
        where TX : IComparable
    {
        public bool AcceptsUnsortedData
        {
            get => this.AcceptUnsortedData;
            set => this.AcceptUnsortedData = value;
        }

        public IList<TX> XValues
        {
            get { throw new NotImplementedException(); }
        }

        public IList<TY> YValues
        {
            get { throw new NotImplementedException(); }
        }
    }
}