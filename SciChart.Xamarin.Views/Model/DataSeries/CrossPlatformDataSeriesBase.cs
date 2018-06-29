using System;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    public abstract class CrossPlatformDataSeriesBase
    {
        internal static readonly IDataSeriesFactory Factory;

        static CrossPlatformDataSeriesBase()
        {
            Factory = DependencyService.Get<IDataSeriesFactory>();
            if (Factory == null)
            {
                throw new InvalidOperationException(
                "Cannot get Dependency IDataSeriesFactory. Have you registered the dependency via attribute [assembly: Xamarin.Forms.Dependency(typeof(DataSeriesFactory))] in your application?");
            }
        }

        public IDataSeries InnerSeries { get; set; }
    }
}