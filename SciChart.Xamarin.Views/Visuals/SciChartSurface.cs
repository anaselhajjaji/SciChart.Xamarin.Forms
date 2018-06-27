using System.Collections.ObjectModel;
using System.Text;
using SciChart.Xamarin.Views.Visuals.Annotations;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals
{
    public interface ISciChartSurface
    {
        IAxis XAxis { get; set; }
        IAxis YAxis { get; set; }
        ObservableCollection<IAxis> XAxes { get; set; }
        ObservableCollection<IAxis> YAxes { get; set; }        
        ObservableCollection<IRenderableSeries> RenderableSeries { get; set; }
        ObservableCollection<IAnnotation> Annotations { get; set; }
    }

    public class SciChartSurface : View, ISciChartSurface
    {
        /// <summary>
        /// Defines the XAxis BindableProperty
        /// </summary>
        public static readonly BindableProperty XAxisProperty = BindableProperty.Create("XAxis", typeof(IAxis), typeof(SciChartSurface), null, BindingMode.Default, null, null, null, null, null);

        /// <summary>
        /// Defines the YAxis BindableProperty
        /// </summary>
        public static readonly BindableProperty YAxisProperty = BindableProperty.Create("YAxis", typeof(IAxis), typeof(SciChartSurface), null, BindingMode.Default, null, null, null, null, null);

        /// <summary>
        /// Defines the YAxes BindableProperty
        /// </summary>
        public static readonly BindableProperty XAxesProperty = BindableProperty.Create("XAxes", typeof(ObservableCollection<IAxis>), typeof(SciChartSurface), null, BindingMode.Default, null, null, null, null, (s) => new ObservableCollection<IAxis>());

        /// <summary>
        /// Defines the YAxes BindableProperty
        /// </summary>
        public static readonly BindableProperty YAxesProperty = BindableProperty.Create("YAxes", typeof(ObservableCollection<IAxis>), typeof(SciChartSurface), null, BindingMode.Default, null, null, null, null, (s) => new ObservableCollection<IAxis>());

        /// <summary>
        /// Defines the RenderableSeries BindableProperty
        /// </summary>
        public static readonly BindableProperty RenderableSeriesProperty = BindableProperty.Create("RenderableSeries", typeof(ObservableCollection<IRenderableSeries>), typeof(SciChartSurface), null, BindingMode.Default, null, null, null, null, (s) => new ObservableCollection<IRenderableSeries>());

        /// <summary>
        /// Defines the RenderableSeries BindableProperty
        /// </summary>
        public static readonly BindableProperty AnnotationsProperty = BindableProperty.Create("Annotations", typeof(ObservableCollection<IAnnotation>), typeof(SciChartSurface), null, BindingMode.Default, null, null, null, null, (s) => new ObservableCollection<IAnnotation>());

        public SciChartSurface()
        {            
        }

        public IAxis XAxis
        {
            get => (IAxis)GetValue(XAxisProperty);
            set => SetValue(XAxisProperty, value);
        }

        public IAxis YAxis
        {
            get => (IAxis)GetValue(YAxisProperty);
            set => SetValue(YAxisProperty, value);
        }

        public ObservableCollection<IAxis> YAxes
        {
            get => (ObservableCollection<IAxis>)GetValue(YAxesProperty);
            set => SetValue(YAxesProperty, value);
        }

        public ObservableCollection<IAxis> XAxes
        {
            get => (ObservableCollection<IAxis>)GetValue(XAxesProperty); 
            set => SetValue(XAxesProperty, value);
        }

        public ObservableCollection<IRenderableSeries> RenderableSeries
        {
            get => (ObservableCollection<IRenderableSeries>)GetValue(XAxesProperty);
            set => SetValue(XAxesProperty, value);
        }

        public ObservableCollection<IAnnotation> Annotations
        {
            get => (ObservableCollection<IAnnotation>)GetValue(AnnotationsProperty);
            set => SetValue(AnnotationsProperty, value);
        }
    }
}
