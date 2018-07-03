using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SciChart.Xamarin.Views.Utility
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

        public void Init(TSource sourceControl)
        {
            foreach (var key in Keys)
            {
                var handler = this[key];
                handler(sourceControl, _targetControl);
            }
        }
    }
}
