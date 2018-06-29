using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using Xamarin.Forms;
using IDataSeriesX = SciChart.Xamarin.Views.Model.DataSeries.IDataSeries;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    public class FastLineRenderableSeriesiOS : SCIFastLineRenderableSeries, IFastLineRenderableSeries
    {
        private IDataSeriesX _dataSeries;

        public FastLineRenderableSeriesiOS()
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
                base.DataSeries = (SciChart.iOS.Charting.IDataSeries)((CrossPlatformDataSeriesBase)_dataSeries)?.InnerSeries;
            }
        }

        public object BindingContext { get; set; }
    }
}