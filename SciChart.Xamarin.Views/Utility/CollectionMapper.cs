using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace SciChart.Xamarin.Views.Utility
{
    /// <summary>
    /// Utility class to map an ObservableCollection of type <see cref="TFrom"/> from Xamarin Forms to native platform collections. 
    /// When the underlying collection updates, the native collection will update too
    /// </summary>
    /// <typeparam name="TCollectionType"></typeparam>
    /// <typeparam name="TFrom"></typeparam>
    /// <typeparam name="TTo"></typeparam>
    public abstract class CollectionMapper<TCollectionType, TFrom, TTo>
    {
        private readonly TCollectionType _nativeCollection;
        private readonly ObservableCollection<TFrom> _xformsCollection;

        protected CollectionMapper(TCollectionType nativeCollection, ObservableCollection<TFrom> xformsCollection)
        {
            _nativeCollection = nativeCollection;
            _xformsCollection = xformsCollection;
            _xformsCollection.CollectionChanged += OnCollectionChanged;

            OnCollectionChanged(null, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.OnCleared(_nativeCollection);
            foreach (var item in _xformsCollection)
            {
                this.OnAdded(_nativeCollection, item);
            }
        }

        protected abstract void OnCleared(TCollectionType destCollection);
        protected abstract void OnAdded(TCollectionType destCollection, TFrom item);

        public void Dispose()
        {
            _xformsCollection.CollectionChanged -= OnCollectionChanged;
        }
    }
}
