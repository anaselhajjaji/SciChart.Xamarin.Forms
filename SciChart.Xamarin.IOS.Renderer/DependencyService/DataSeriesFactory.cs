// *************************************************************************************
// SCICHART® Copyright SciChart Ltd. 2011-2016. All rights reserved.
//  
// Web: http://www.scichart.com
//   Support: support@scichart.com
//   Sales:   sales@scichart.com
// 
// DataSeriesFactory.cs is part of the SCICHART® Examples. Permission is hereby granted
// to modify, create derivative works, distribute and publish any part of this source
// code whether for commercial, private or personal use. 
// 
// The SCICHART® examples are distributed in the hope that they will be useful, but
// without any warranty. It is provided "AS IS" without warranty of any kind, either
// expressed or implied. 
// *************************************************************************************

using System;
using System.Collections.Generic;
using SciChart.Xamarin.Views.Model.DataSeries;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    public class XyDataSeries<TX, TY> : SciChart.iOS.Charting.XyDataSeries<TX, TY>,
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


    public class DataSeriesFactory : IDataSeriesFactory
    {
        public Views.Model.DataSeries.IXyDataSeries<TX, TY> NewXyDataSeries<TX, TY>() where TX : IComparable where TY : IComparable
        {
            return new XyDataSeries<TX, TY>();
        }
    }
}