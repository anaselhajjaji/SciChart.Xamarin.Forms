using System.ComponentModel;

namespace SciChart.Xamarin.Views.Model
{
    /// <summary>
    ///  Provides data for the System.ComponentModel.INotifyPropertyChanged.PropertyChanged event.
    /// </summary>
    public class PropertyChangedEventArgsWithValues : PropertyChangedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the PropertyChangedEventArgsWithValues class
        /// </summary>
        /// <param name="propertyName"> The name of the property that changed.</param>
        /// <param name="oldValue"> Old value of the property that changed. </param>
        /// <param name="newValue"> New value of the property that changed. </param>
        public PropertyChangedEventArgsWithValues(string propertyName, object oldValue, object newValue) : base(propertyName)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>
        /// Gets an old value of property that changed
        /// </summary>
        public object OldValue
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets a new value of property that changed
        /// </summary>
        public object NewValue
        {
            get;
            protected set;
        }
    }
}