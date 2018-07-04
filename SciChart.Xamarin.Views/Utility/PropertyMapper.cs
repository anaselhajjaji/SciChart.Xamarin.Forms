using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SciChart.Xamarin.Views.Utility
{
    public class PropertyMapper<TSourceType, TDestType> : Dictionary<string, Action<TSourceType, TDestType>>
        where TSourceType:class, INotifyPropertyChanged
        where TDestType:class
    {
        private readonly TSourceType _xamarinType;
        private readonly TDestType _nativeType;

        public PropertyMapper(TSourceType xamarinType, TDestType nativeType)
        {
            _xamarinType = xamarinType;
            _nativeType = nativeType;
            xamarinType.PropertyChanged += OnSourcePropertyChanged;
        }        

        public void Init()
        {
            foreach (var key in Keys)
            {
                var handler = this[key];
                handler(_xamarinType, _nativeType);
            }
        }

        private void OnSourcePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.TryGetValue(e.PropertyName, out var handler))
            {
                var sourceControl = sender as TSourceType;
                handler(sourceControl, _nativeType);
            }
        }
    }
}
