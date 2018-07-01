using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using SciChart.Xamarin.Views.Visuals.Annotations;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
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
        public static readonly BindableProperty RenderableSeriesProperty = BindableProperty.Create("RenderableSeries", typeof(ObservableCollection<IRenderableSeries>), typeof(SciChartSurface), null, BindingMode.Default, null, OnRenderableSeriesCollectionPropertyChanged, null, null,
            (s) =>
            {
                var c = new ObservableCollection<IRenderableSeries>();
                c.CollectionChanged += ((SciChartSurface) s).OnRenderableSeriesCollectionChanged;
                return c;
            });        

        /// <summary>
        /// Defines the RenderableSeries BindableProperty
        /// </summary>
        public static readonly BindableProperty AnnotationsProperty = BindableProperty.Create("Annotations", typeof(ObservableCollection<IAnnotation>), typeof(SciChartSurface), null, BindingMode.Default, null, null, null, null, (s) => new ObservableCollection<IAnnotation>());

        /// <summary>
        /// Defines the RenderableSeries BindableProperty
        /// </summary>
        public static readonly BindableProperty ChartTitleProperty = BindableProperty.Create("ChartTitle", typeof(string), typeof(SciChartSurface), null, BindingMode.Default, null, null, null, null, null);

        public SciChartSurface()
        {
            this.BindingContextChanged += (s, e) => PropagateBindingContext();
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
            get => (ObservableCollection<IRenderableSeries>)GetValue(RenderableSeriesProperty);
            set => SetValue(RenderableSeriesProperty, value);
        }

        public ObservableCollection<IAnnotation> Annotations
        {
            get => (ObservableCollection<IAnnotation>)GetValue(AnnotationsProperty);
            set => SetValue(AnnotationsProperty, value);
        }

        public string ChartTitle
        {
            get => (string)GetValue(ChartTitleProperty);
            set => SetValue(ChartTitleProperty, value);
        }

        private static void OnRenderableSeriesCollectionPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var scs = ((SciChartSurface) bindable);
            var oldCollection = oldvalue as ObservableCollection<IRenderableSeries>;
            var newCollection = newvalue as ObservableCollection<IRenderableSeries>;
            if (oldCollection != null)
            {
                oldCollection.CollectionChanged -= scs.OnRenderableSeriesCollectionChanged;
            }
            if (newCollection != null)
            {
                newCollection.CollectionChanged += scs.OnRenderableSeriesCollectionChanged;
            }

            scs.OnRenderableSeriesCollectionChanged(newCollection, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void OnRenderableSeriesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            PropagateBindingContext();
        }

        private void PropagateBindingContext()
        {
            foreach (var item in RenderableSeries)
            {
                item.BindingContext = this.BindingContext;
            }

            // TODO:  Axis, ChartModifier, Annotations
        }
    }
}
