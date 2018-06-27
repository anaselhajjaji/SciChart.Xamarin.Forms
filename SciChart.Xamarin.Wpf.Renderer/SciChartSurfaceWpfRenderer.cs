using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Data.Model;
using SciChart.Xamarin.Wpf.Renderer;
using Xamarin.Forms.Platform.WPF;

namespace SciChart.Xamarin.Wpf.Renderer
{    
    public class SciChartSurfaceWpfRenderer : ViewRenderer<SciChart.Xamarin.Views.Visuals.SciChartSurface, SciChart.Charting.Visuals.SciChartSurface>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SciChart.Xamarin.Views.Visuals.SciChartSurface> e)
        {                        
            base.OnElementChanged(e);

            var sciChartSurfaceView = e.NewElement as SciChart.Xamarin.Views.Visuals.SciChartSurface;
            if (Control == null)
            {
                this.SetNativeControl(new SciChartSurface());

                // Some dummy data 
                Control.XAxes.Add(new NumericAxis());
                Control.YAxes.Add(new NumericAxis());
                Control.XAxes[0].VisibleRange = new DoubleRange(0, 10);
                Control.YAxes[0].VisibleRange = new DoubleRange(0, 10);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }
}
