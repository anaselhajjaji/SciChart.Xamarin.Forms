using System;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    public class FastLineRenderableSeries : CrossPlatformRenderableSeriesBase, IFastLineRenderableSeries
    {                
        public FastLineRenderableSeries()
        {
            NativeSeries = Factory.NewLineSeries();
        }               
    }
}