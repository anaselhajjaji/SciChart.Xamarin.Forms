using System;
using SciChart.Xamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TestApp.UI
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            // Setup SciChart Licenses
		    string iosAndroidLicense = @"<LicenseContract>
              <Customer>elhajjajiana.s@gmail.com</Customer>
              <OrderId>Trial</OrderId>
              <LicenseCount>1</LicenseCount>
              <IsTrialLicense>true</IsTrialLicense>
              <SupportExpires>12/12/2019 00:00:00</SupportExpires>
              <ProductCode>SC-ANDROID-2D-ENTERPRISE-SRC</ProductCode>
              <KeyCode>2cfdbbf5a519adec79de947564e98432e6c629baa35b72059d51f8e515dc8382046a7450fd66df999763ab071d9c57cd43a03eee2a2a2ee52f74beef2d05461b4495cacda56aa2352338f8dc0a11f38970cb3caf79f1077c6fea68f509d6e3078379adc2bf016055dfa051d578992f3fe3b1f330982bf2f58e9cf0c743f4ccbf1423185fee948ac5395319e5f724217e48c24054ed5d407345a574235d406203f6df905e5057cdbf5b901cbce0201f441ff5</KeyCode>
            </LicenseContract>";

            SciChartLicenseManager.AddLicense(SciChartPlatform.Android, iosAndroidLicense);
		    SciChartLicenseManager.AddLicense(SciChartPlatform.iOS, iosAndroidLicense);

            MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
