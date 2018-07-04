using System;
using System.Collections.Generic;
using System.Text;
using SciChart.Wpf.UI.Reactive.Observability;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Model.DataSeries;
using Xamarin.Forms;

namespace TestApp.UI
{
    public class MainViewModel : ObservableObjectBase
    {
        public MainViewModel()
        {
            var dataSeries = new XyDataSeries<double, double>();

            for (int i = 0; i < 100; i++)
            {
                dataSeries.Append(i, Math.Sin(i * 0.05));
            }

            LineSeries = dataSeries;

            ChartTitle = "Hello World!";
            LineStroke = Color.FromHex("#FFFF6600");
            StrokeThickness = 1;
        }

        public IXyDataSeries<double, double> LineSeries
        {
            get => GetDynamicValue<IXyDataSeries<double, double>>();
            set => SetDynamicValue(value);
        }

        public Color LineStroke
        {
            get => GetDynamicValue<Color>();
            set => SetDynamicValue(value);
        }

        public int StrokeThickness
        {
            get => GetDynamicValue<int>();
            set => SetDynamicValue(value);
        }

        public string ChartTitle
        {
            get => GetDynamicValue<string>();
            set => SetDynamicValue(value);
        }
    }
}
