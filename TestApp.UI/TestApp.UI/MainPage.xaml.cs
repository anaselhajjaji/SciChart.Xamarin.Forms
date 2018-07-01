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
		    this.BindingContext = new MainViewModel();            
		}
	}
}
