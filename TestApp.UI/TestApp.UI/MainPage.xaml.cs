using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciChart.Xamarin.Views.Model.DataSeries;
using Xamarin.Forms;

namespace TestApp.UI
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

		    var factory = DependencyService.Get<IDataSeriesFactory>();
		    var dataSeries = factory.NewXyDataSeries<double, double>();

		    dataSeries.Append(0, 1);
		    dataSeries.Append(1, 2);

//		    var xValues = dataSeries.XValues;
//		    var yValues = dataSeries.YValues;
//
//		    for (int i = 0; i < dataSeries.Count; i++)
//		    {
//		        Console.WriteLine("XValue[{0}]: {1}, YValue[{0}]: {2}", i, xValues[i], yValues[i]);
//		    }
        }
	}
}
