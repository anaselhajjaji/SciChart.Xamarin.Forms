using SciChart.Xamarin.Views.Visuals.RenderableSeries;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    public class RenderableSeriesFactoryiOS : IRenderableSeriesFactory
    {
        public IFastLineRenderableSeries NewLineSeries()
        {
            return new FastLineRenderableSeriesiOS();
        }
    }
}