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
                  <Customer>ABT Test</Customer>
                  <OrderId>ABT Test</OrderId>
                  <LicenseCount>1</LicenseCount>
                  <IsTrialLicense>true</IsTrialLicense>
                  <SupportExpires>07/28/2018 00:00:00</SupportExpires>
                  <ProductCode>SC-IOS-ANDROID-2D-PRO</ProductCode>
                  <KeyCode>27289309f935227d91c4f89a69a0513d7da9c976c61122821344bdadb805e4b9367e51a3670dbf460bf1c5ead5bdffec185585c99d48b98e2e55be9d1968e2e0c53803a6fedbe8e821b8f888930dfa1a968b757cc53a8a907f0b7fc58a8b5a425a42e8fade27682c46c39d34a488080cf060b9bb533ab8d44f918d2b0d42d237281f66022c009bd3b3a737d95119d6757f534182b636991d528f159c13f9</KeyCode>
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
