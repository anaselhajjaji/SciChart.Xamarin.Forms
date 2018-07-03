using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace SciChart.Xamarin.Views.Model
{
    /// <summary>
    /// Provides a base-type for classes that need to raise <see cref="INotifyPropertyChanged"/> events
    /// </summary>
    public class NotifyPropertyChangedImpl : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <remarks></remarks>
        protected event PropertyChangedEventHandler _propertyChanged;

        /// <summary>
        /// Raises the <see cref="INotifyPropertyChanged.PropertyChanged"/> event
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <remarks></remarks>
        protected void OnPropertyChanged(string propertyName)
        {
            RaisePropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises the <see cref="INotifyPropertyChanged.PropertyChanged"/> event
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="oldValue">Old value of the property.</param>
        /// <param name="newValue">New value of the property.</param>
        /// <remarks></remarks>
        protected void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            RaisePropertyChanged(new PropertyChangedEventArgsWithValues(propertyName, oldValue, newValue));
        }

        // Explicit interface implementation
        private int _refCounter = 0;
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                _propertyChanged += value;

                // HACK (or workaround ;-)). To prevent serious hanging in Silverlight on Theme Change after lots of drawing, we fire a property changed 
                // once in a blue moon. This causes the binding engine to collect (unsubscribe) old bindings to theme properties. 
                // Hanging only occurs in Silverlight, WPF seems to cope with this issue quite well, nevertheless we leave this in for both platforms
                if (Interlocked.Increment(ref _refCounter) > 100)
                {
                    _refCounter = 0;
                    RaisePropertyChanged(new PropertyChangedEventArgs("Nothing"));
                }
            }
            remove
            {
                //Debug.WriteLine("Removing event: Type={0}", GetType().Name);
                _propertyChanged -= value;
            }
        }

        private void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            var handler = _propertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}
