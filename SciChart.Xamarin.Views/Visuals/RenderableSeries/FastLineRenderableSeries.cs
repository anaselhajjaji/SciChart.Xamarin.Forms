using System;
using SciChart.Xamarin.Views.Model.DataSeries;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    public class FastLineRenderableSeries : View, IFastLineRenderableSeries
    {
        /// <summary>
        /// Defines the XAxisId BindableProperty
        /// </summary>
        public static readonly BindableProperty XAxisIdProperty = BindableProperty.Create("XAxisId", typeof(string), typeof(SciChartSurface), AxisCore.DefaultAxisId, BindingMode.Default, null, OnXAxisIdPropertyChanged, null, null, null);        

        /// <summary>
        /// Defines the YAxisId BindableProperty
        /// </summary>
        public static readonly BindableProperty YAxisIdProperty = BindableProperty.Create("YAxisId", typeof(string), typeof(SciChartSurface), AxisCore.DefaultAxisId, BindingMode.Default, null, OnYAxisIdPropertyChanged, null, null, null);        

        /// <summary>
        /// Defines the Stroke BindableProperty
        /// </summary>
        public static readonly BindableProperty StrokeProperty = BindableProperty.Create("Stroke", typeof(Color), typeof(SciChartSurface), Color.White, BindingMode.Default, null, OnStrokePropertyChanged, null, null, null);

        /// <summary>
        /// Defines the StrokeThickness BindableProperty
        /// </summary>
        public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.Create("StrokeThickness", typeof(int), typeof(SciChartSurface), 1, BindingMode.Default, null, OnStrokeThicknessPropertyChanged, null, null, null);        

        /// <summary>
        /// Defines the DataSeries BindableProperty
        /// </summary>
        public static readonly BindableProperty DataSeriesProperty = BindableProperty.Create("DataSeries", typeof(IDataSeries), typeof(SciChartSurface), null, BindingMode.Default, null, OnDataSeriesPropertyChanged, null, null, null);

        // Platform specific line series implementation 
        private IFastLineRenderableSeries _lineSeries;

        public FastLineRenderableSeries()
        {
            var factory = DependencyService.Get<IRenderableSeriesFactory>();
            if (factory == null)
            {
                throw new InvalidOperationException(
                    "Make sure you register the dependency [assembly: Xamarin.Forms.Dependency(typeof(SciChart.Xamarin.Wpf.Renderer.DependencyService.RenderableSeriesFactory))]");
            }

            _lineSeries = factory.NewLineSeries();
        }

        public string XAxisId
        {
            get => (string)GetValue(XAxisIdProperty);
            set => SetValue(XAxisIdProperty, value);
        }

        public string YAxisId
        {
            get => (string)GetValue(YAxisIdProperty);
            set => SetValue(YAxisIdProperty, value);
        }

        public Color Stroke
        {
            get => (Color)GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }

        public int StrokeThickness
        {
            get => (int)GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }

        public IDataSeries DataSeries
        {
            get => (IDataSeries)GetValue(DataSeriesProperty);
            set => SetValue(DataSeriesProperty, value);
        }

        private static void OnXAxisIdPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((FastLineRenderableSeries)bindable)._lineSeries.XAxisId = (string)newvalue;
        }

        private static void OnYAxisIdPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((FastLineRenderableSeries)bindable)._lineSeries.YAxisId = (string)newvalue;
        }
        private static void OnStrokePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((FastLineRenderableSeries)bindable)._lineSeries.Stroke = (Color)newvalue;
        }
        private static void OnStrokeThicknessPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((FastLineRenderableSeries)bindable)._lineSeries.StrokeThickness = (int)newvalue;
        }

        private static void OnDataSeriesPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((FastLineRenderableSeries)bindable)._lineSeries.DataSeries = (IDataSeries)newvalue;
        }
    }
}