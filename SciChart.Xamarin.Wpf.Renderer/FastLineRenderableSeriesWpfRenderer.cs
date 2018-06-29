using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Xamarin.Views.Helpers;
using Xamarin.Forms.Platform.WPF;
using FastLineRenderableSeriesX = SciChart.Xamarin.Views.Visuals.RenderableSeries.FastLineRenderableSeries;

namespace SciChart.Xamarin.Wpf.Renderer
{
    public class FastLineRenderableSeriesWpfRenderer : ViewRenderer<FastLineRenderableSeriesX, FastLineRenderableSeries>
    {
        private PropertyMapper<FastLineRenderableSeriesX, FastLineRenderableSeries> _propertyMapper;

        public FastLineRenderableSeriesWpfRenderer()
        {            

        }

        protected override void OnElementChanged(ElementChangedEventArgs<SciChart.Xamarin.Views.Visuals.RenderableSeries.FastLineRenderableSeries> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                // Set the new control
                this.SetNativeControl(new FastLineRenderableSeries());

                // Map properties 
                _propertyMapper = new PropertyMapper<FastLineRenderableSeriesX, FastLineRenderableSeries>(Control);
            }
        }
    }
}