using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;


namespace SciChart.Xamarin.Wpf.Renderer.DependencyService
{
    public class RenderableSeriesFactoryWpf : IRenderableSeriesFactory
    {
        public IFastLineRenderableSeries NewLineSeries()
        {
            return new FastLineRenderableSeriesWpf();
        }
    }
}
