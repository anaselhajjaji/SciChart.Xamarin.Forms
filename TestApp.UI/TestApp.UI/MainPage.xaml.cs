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

		    var dataSeries = new XyDataSeries<double, double>();

		    for (int i = 0; i < 100; i++)
		    {
		        dataSeries.Append(i, Math.Sin(i*0.05));
		    }

		    LineSeries.DataSeries = dataSeries;
		}
	}
}
