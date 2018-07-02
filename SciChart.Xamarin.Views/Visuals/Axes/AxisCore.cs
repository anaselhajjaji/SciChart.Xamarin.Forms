using System;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    public class AxisCore : View, IAxisCore
    {
        protected static readonly IAxisFactory Factory;

        public static string DefaultAxisId = "DefaultAxisId";

        /// <summary>
        /// Defines the XAxisId BindableProperty
        /// </summary>
        public static readonly BindableProperty IdProperty = BindableProperty.Create("Id", typeof(string), typeof(AxisCore), AxisCore.DefaultAxisId, BindingMode.Default, null, OnIdPropertyChanged, null, null, null);        

        static AxisCore()
        {
            Factory = DependencyService.Get<IAxisFactory>();
            if (Factory == null)
            {
                throw new InvalidOperationException(
                    "Cannot get Dependency IAxisFactory. Have you registered the dependency via attribute [assembly: Xamarin.Forms.Dependency(typeof(AxisFactory))] in your application?");
            }
        }

        public IAxisCore InnerAxis { get; set; }

        public string Id
        {
            get => (string) GetValue(IdProperty);
            set => SetValue(IdProperty, value);
        }

        private static void OnIdPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AxisCore)bindable).InnerAxis.Id = (string)newvalue;
        }
    }
}