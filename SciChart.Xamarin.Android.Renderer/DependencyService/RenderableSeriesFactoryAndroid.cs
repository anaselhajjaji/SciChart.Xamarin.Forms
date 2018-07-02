using System;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    public class RenderableSeriesFactoryAndroid : IRenderableSeriesFactory
    {
        public IFastLineRenderableSeries NewLineSeries()
        {
            return new FastLineRenderableSeriesAndroid();
        }
    }
}