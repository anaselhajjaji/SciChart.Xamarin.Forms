using System;
using System.ComponentModel;

namespace SciChart.Xamarin.Views.Utility
{
    public class BiDirectionalPropertyMapper<TXamarinFormsType, TNativeType>
        where TXamarinFormsType : class, INotifyPropertyChanged
        where TNativeType : class, INotifyPropertyChanged
    {
        private readonly PropertyMapper<TXamarinFormsType, TNativeType> _forwardMap;
        private readonly PropertyMapper<TNativeType, TXamarinFormsType> _backwardMap;

        protected BiDirectionalPropertyMapper(TXamarinFormsType xamarinType, TNativeType nativeType)
        {
            _forwardMap = new PropertyMapper<TXamarinFormsType, TNativeType>(xamarinType, nativeType);
            _backwardMap = new PropertyMapper<TNativeType, TXamarinFormsType>(nativeType, xamarinType);
        }

        public void Add(string property, Action<TXamarinFormsType, TNativeType> handler)
        {
            _forwardMap.Add(property, handler);
        }

        public void AddBack(string property, Action<TNativeType, TXamarinFormsType> handler)
        {
            _backwardMap.Add(property, handler);
        }
    }
}