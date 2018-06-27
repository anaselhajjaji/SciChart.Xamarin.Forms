using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals
{
    public interface ISciChartSurface
    {
        IAxis XAxis { get; set; }
        IAxis YAxis { get; set; }
        AxisCollection XAxes { get; set; }
        AxisCollection YAxes { get; set; }        
        ObservableCollection<IRenderableSeries> RenderableSeries { get; set; }
    }

    public class SciChartSurface : View, ISciChartSurface
    {
        /// <summary>
        /// Defines the XAxis BindableProperty
        /// </summary>
        public static readonly BindableProperty XAxisProperty = BindableProperty.Create("XAxis", typeof(IAxis), typeof(SciChartSurface), null, BindingMode.Default, null, OnXAxisChanged);

        /// <summary>
        /// Defines the YAxis BindableProperty
        /// </summary>
        public static readonly BindableProperty YAxisProperty = BindableProperty.Create("YAxis", typeof(IAxis), typeof(SciChartSurface), null, BindingMode.Default, null, OnYAxisChanged);

        /// <summary>
        /// Defines the YAxes BindableProperty
        /// </summary>
        public static readonly BindableProperty XAxesProperty = BindableProperty.Create("XAxes", typeof(AxisCollection), typeof(SciChartSurface), null, BindingMode.Default, null, OnXAxesBindablePropertyChanged);

        /// <summary>
        /// Defines the YAxes BindableProperty
        /// </summary>
        public static readonly BindableProperty YAxesProperty = BindableProperty.Create("YAxes", typeof(AxisCollection), typeof(SciChartSurface), null, BindingMode.Default, null, OnYAxesBindablePropertyChanged);

        /// <summary>
        /// Defines the RenderableSeries BindableProperty
        /// </summary>
        public static readonly BindableProperty RenderableSeriesProperty = BindableProperty.Create("RenderableSeries", typeof(ObservableCollection<IRenderableSeries>), typeof(SciChartSurface), null, BindingMode.Default, null, OnRenderableSeriesBindablePropertyChanged);

        /// <summary>
        /// Defines the RenderableSeries BindableProperty
        /// </summary>
        public static readonly BindableProperty AnnotationsProperty = BindableProperty.Create("Annotations", typeof(ObservableCollection<IRenderableSeries>), typeof(SciChartSurface), null, BindingMode.Default, null, OnRenderableSeriesBindablePropertyChanged);

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

        public AxisCollection YAxes
        {
            get => (AxisCollection)GetValue(YAxesProperty);
            set => SetValue(YAxesProperty, value);
        }

        public AxisCollection XAxes
        {
            get => (AxisCollection)GetValue(XAxesProperty); 
            set => SetValue(XAxesProperty, value);
        }

        public ObservableCollection<IRenderableSeries> RenderableSeries
        {
            get => (ObservableCollection<IRenderableSeries>)GetValue(XAxesProperty);
            set => SetValue(XAxesProperty, value);
        }

        private static void OnXAxisChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }

        private static void OnYAxisChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }

        private static void OnRenderableSeriesBindablePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }

        private static void OnYAxesBindablePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }

        private static void OnXAxesBindablePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }
    }
}
