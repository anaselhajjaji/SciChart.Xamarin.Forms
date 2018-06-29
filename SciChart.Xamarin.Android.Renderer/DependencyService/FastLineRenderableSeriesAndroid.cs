using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using Xamarin.Forms;
using FastLineRenderableSeries = SciChart.Charting.Visuals.RenderableSeries.FastLineRenderableSeries;
using IDataSeriesX = SciChart.Xamarin.Views.Model.DataSeries.IDataSeries;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    public class FastLineRenderableSeriesAndroid : FastLineRenderableSeries, IFastLineRenderableSeries
    {
        private IDataSeriesX _dataSeries;

        public FastLineRenderableSeriesAndroid()
        {
        }

        public Color Stroke { get; set; }
        public int StrokeThickness { get; set; }

        IDataSeriesX IRenderableSeries.DataSeries
        {
            get => _dataSeries;
            set
            {
                _dataSeries = value;
                base.DataSeries = (Charting.Model.DataSeries.IDataSeries)((CrossPlatformDataSeriesBase)_dataSeries)?.InnerSeries;
            }
        }

        public object BindingContext { get; set; }
    }
}