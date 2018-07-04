using System;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model
{
    public abstract class RangeBase
    {
        protected static readonly IRangeFactory Factory;

        static RangeBase()
        {
            Factory = DependencyService.Get<IRangeFactory>();
            if (Factory == null)
            {
                if (Factory == null)
                {
                    throw new InvalidOperationException(
                        "Cannot get Dependency IRangeFactory. Have you registered the dependency via attribute [assembly: Xamarin.Forms.Dependency(typeof(RangeFactory))] in your application?");
                }
            }
        }

        public IRange NativeRange { get; protected set; }
    }
}