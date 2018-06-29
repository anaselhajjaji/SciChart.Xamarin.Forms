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
                    "Cannot get Dependency IRenderableSeriesFactory. Have you registered the dependency via attribute [assembly: Xamarin.Forms.Dependency(typeof(RenderableSeriesFactory))] in your application?");
            }

            InnerSeries = factory.NewLineSeries();
        }               
    }
}