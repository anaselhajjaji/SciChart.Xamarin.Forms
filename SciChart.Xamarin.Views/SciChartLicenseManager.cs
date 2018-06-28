using System;
using System.Collections.Generic;
using System.Text;

namespace SciChart.Xamarin.Views
{
    public enum SciChartPlatform
    {
        iOS,
        Android,
        Wpf,
    }

    public static class SciChartLicenseManager
    {
        private static IDictionary<SciChartPlatform, string> _licenses = new Dictionary<SciChartPlatform, string>();

        public static void AddLicense(SciChartPlatform platform, string licenseKey)
        {
            _licenses.Add(platform, licenseKey);
        }

        public static string GetLicense(SciChartPlatform platform)
        {
            if (_licenses.TryGetValue(platform, out string licenseKey))
            {
                return licenseKey;
            }
            return null;
        }

    }
}
