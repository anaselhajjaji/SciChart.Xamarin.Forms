using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SciChart.Xamarin.Views.Visuals;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Helpers
{
    public class PropertyMapper<TSource, TTarget> : Dictionary<string, Action<TSource, TTarget>>
        where TSource:class
        where TTarget:class
    {
        private readonly TTarget _targetControl;

        public PropertyMapper(TTarget targetControl)
        {
            _targetControl = targetControl;
        }

        public void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.TryGetValue(e.PropertyName, out var handler))
            {
                var sourceControl = sender as TSource;
                handler(sourceControl, _targetControl);
            }
        }
    }
}
