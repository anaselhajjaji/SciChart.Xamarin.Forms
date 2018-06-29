using System;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    public class FastLineRenderableSeries : CrossPlatformRenderableSeriesBase, IFastLineRenderableSeries
    {                
        public FastLineRenderableSeries()
        {
            var factory = DependencyService.Get<IRenderableSeriesFactory>();
            if (factory == null)
            {
                throw new InvalidOperationException(
                    "Make sure you register the dependency [assembly: Xamarin.Forms.Dependency(typeof(SciChart.Xamarin.Wpf.Renderer.DependencyService.RenderableSeriesFactory))]");
            }

            InnerSeries = factory.NewLineSeries();
        }               
    }
}