using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using SciChart.Xamarin.Views.Visuals.Annotations;
using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using Xamarin.Forms;
using SciChart.Xamarin.Views.Helpers;

namespace SciChart.Xamarin.Views.Visuals
{
    public interface ISciChartSurface
    {        
        ObservableCollection<IAxis> XAxes { get; set; }
        ObservableCollection<IAxis> YAxes { get; set; }        
        ObservableCollection<IRenderableSeries> RenderableSeries { get; set; }
        ObservableCollection<IAnnotation> Annotations { get; set; }
    }

    public class SciChartSurface : View, ISciChartSurface
    {        
        /// <summary>
        /// Defines the YAxes BindableProperty
        /// </summary>
        public static readonly BindableProperty XAxesProperty = BindableProperty.Create("XAxes", typeof(ObservableCollection<IAxis>), typeof(SciChartSurface), null, BindingMode.Default, null, OnXAxesDependencyPropertyChanged, null, null, (s) =>
        {
            var c = new ObservableCollection<IAxis>();
            c.CollectionChanged += ((SciChartSurface)s).OnAnyCollectionChanged;
            return c;
        });

        /// <summary>
        /// Defines the YAxes BindableProperty
        /// </summary>
        public static readonly BindableProperty YAxesProperty = BindableProperty.Create("YAxes", typeof(ObservableCollection<IAxis>), typeof(SciChartSurface), null, BindingMode.Default, null, OnYAxesDependencyPropertyChanged, null, null, (s) =>
        {
            var c = new ObservableCollection<IAxis>();
            c.CollectionChanged += ((SciChartSurface)s).OnAnyCollectionChanged;
            return c;
        });

        /// <summary>
        /// Defines the RenderableSeries BindableProperty
        /// </summary>
        public static readonly BindableProperty RenderableSeriesProperty = BindableProperty.Create("RenderableSeries", typeof(ObservableCollection<IRenderableSeries>), typeof(SciChartSurface), null, BindingMode.Default, null, OnRenderableSeriesDependencyPropertyChanged, null, null,
            (s) =>
            {
                var c = new ObservableCollection<IRenderableSeries>();
                c.CollectionChanged += ((SciChartSurface) s).OnAnyCollectionChanged;
                return c;
            });        

        /// <summary>
        /// Defines the RenderableSeries BindableProperty
        /// </summary>
        public static readonly BindableProperty AnnotationsProperty = BindableProperty.Create("Annotations", typeof(ObservableCollection<IAnnotation>), typeof(SciChartSurface), null, BindingMode.Default, null, null, null, null, (s) =>
        {
            var c = new ObservableCollection<IAnnotation>();
            c.CollectionChanged += ((SciChartSurface)s).OnAnyCollectionChanged;
            return c;
        });

        /// <summary>
        /// Defines the RenderableSeries BindableProperty
        /// </summary>
        public static readonly BindableProperty ChartTitleProperty = BindableProperty.Create("ChartTitle", typeof(string), typeof(SciChartSurface), null, BindingMode.Default, null, null, null, null, null);

        /// <summary>
        /// Defines the YAxes BindableProperty
        /// </summary>
        public static readonly BindableProperty ForegroundColorProperty = BindableProperty.Create("ForegroundColor", typeof(Color), typeof(SciChartSurface), Color.White, BindingMode.Default, null, null, null, null, null);

        public SciChartSurface()
        {
            this.BindingContextChanged += (s, e) => PropagateBindingContext();
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

        public Color ForegroundColor
        {
            get => (Color)GetValue(ForegroundColorProperty);
            set => SetValue(ForegroundColorProperty, value);
        }

        private static void OnRenderableSeriesDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            WireUpCollectionChanged<IRenderableSeries>(bindable, oldvalue, newvalue, ((SciChartSurface)bindable).OnAnyCollectionChanged);
        }

        private static void OnXAxisDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((IAxis)newvalue).BindingContext = ((SciChartSurface)bindable).BindingContext;
        }

        private static void OnYAxisDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((IAxis) newvalue).BindingContext = ((SciChartSurface) bindable).BindingContext;
        }

        private static void OnXAxesDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            WireUpCollectionChanged<IAxis>(bindable, oldvalue, newvalue, ((SciChartSurface)bindable).OnAnyCollectionChanged);
        }
        private static void OnYAxesDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            WireUpCollectionChanged<IAxis>(bindable, oldvalue, newvalue, ((SciChartSurface)bindable).OnAnyCollectionChanged);
        }

        private static void WireUpCollectionChanged<T>(BindableObject bindable, object oldvalue, object newvalue, NotifyCollectionChangedEventHandler handler)
        {
            var scs = ((SciChartSurface)bindable);
            var oldCollection = oldvalue as ObservableCollection<T>;
            var newCollection = newvalue as ObservableCollection<T>;

            if (oldCollection != null)
            {
                oldCollection.CollectionChanged -= handler;
            }
            if (newCollection != null)
            {
                newCollection.CollectionChanged += handler;
            }

            scs.OnAnyCollectionChanged(newCollection, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void OnAnyCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Reset) PropagateBindingContext();
        }

        private void PropagateBindingContext()
        {
            RenderableSeries.ForEachDo(x => x.BindingContext = BindingContext);
            XAxes.ForEachDo(x => x.BindingContext = BindingContext);
            YAxes.ForEachDo(x => x.BindingContext = BindingContext);
            Annotations.ForEachDo(x => x.BindingContext = BindingContext);       
        }
    }
}
