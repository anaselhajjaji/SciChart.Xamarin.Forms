using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace SciChart.Xamarin.Views.Visuals
{
    /// <summary>
    /// Contains a collection of Axes and allows getting of axis by Id
    /// </summary>
    public partial class AxisCollection : ObservableCollection<IAxis>
    {
        private ISciChartSurface _parentSurface;

        /// <summary>
        /// Initializes a new instance of the <see cref="AxisCollection"/> class.
        /// </summary>
        public AxisCollection()
        {
            SetUpCollection();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AxisCollection"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public AxisCollection(IEnumerable<IAxis> collection)
            : base(collection)
        {
            SetUpCollection();
        }

        internal AxisCollection(ObservableCollection<IAxis> obsCollection) : this((IEnumerable<IAxis>)obsCollection)
        {
            obsCollection.CollectionChanged += OnInnerCollectionChanged;
        }

        private void OnInnerCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                this.Clear();
                foreach (var item in ((ObservableCollection<IAxis>)sender))
                    this.Add(item);
            }
            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    this.Remove((IAxis)item);
                }
            }

            if (e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    this.Add((IAxis)item);
                }
            }
        }

        /// <summary>
        /// Returns true if any of the Axes inЗел the collection have <see cref="AxisBase.IsPrimaryAxis"/> set to true
        /// </summary>
        protected bool HasPrimaryAxis
        {
            get { return this.Any(x => x.IsPrimaryAxis); }
        }

        /// <summary>
        /// Gets the primary axis in the collection. This is the first that has <see cref="AxisBase.IsPrimaryAxis"/> set to true, or null if none exists. 
        /// </summary>
        protected IAxis PrimaryAxis
        {
            get { return this.FirstOrDefault(x => x.IsPrimaryAxis); }
        }

        /// <summary>
        /// Gets the default axis, which is equal to the axis with the <see cref="AxisCore.DefaultAxisId"/>, else null
        /// </summary>
        public IAxis Default
        {
            get { return Count > 0 ? GetAxisById(AxisCore.DefaultAxisId) : null; }
        }

        /// <summary>
        /// Gets the axis specified by Id, else null
        /// </summary>
        /// <param name="axisId">The axis identifier.</param>
        /// <param name="assertAxisExists">if set to <c>true</c> assert and throw if the axis does not exist.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public IAxis GetAxisById(string axisId, bool assertAxisExists = false)
        {
            IAxis axis = null;

            try
            {
                axis = this.SingleOrDefault(x => x.Id == axisId);
            }
            catch
            {
                throw new InvalidOperationException(string.Format("AxisCollection.GetAxisById('{0}') returned more than one axis with the ID={0}. Please check you have assigned correct axis Ids when you have multiple axes in SciChart", axisId ?? "NULL"));
            }

            if (assertAxisExists && axis == null)
            {
                throw new InvalidOperationException(string.Format("AxisCollection.GetAxisById('{0}') returned no axis with ID={0}. Please check you have added an axis with this Id to the AxisCollection", axisId ?? "NULL"));
            }
            return axis;
        }

        private void SetUpCollection()
        {
            CollectionChanged -= AxisCollectionChanged;
            CollectionChanged += AxisCollectionChanged;

            var firstAxis = this.FirstOrDefault();
            if (!HasPrimaryAxis && firstAxis != null)
            {
                firstAxis.IsPrimaryAxis = true;
//                var cFirstAxis = firstAxis as AxisCore;
//                if (cFirstAxis != null && cFirstAxis.DataContext != null && cFirstAxis.DataContext is IAxisViewModel)
//                {
//                    (cFirstAxis.DataContext as IAxisViewModel).IsPrimaryAxis = true;
//                }
            }
        }

        private void AxisCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // If user added a new primary axis, preserve this
            var primaryAxis = e.NewItems != null ? e.NewItems.Cast<IAxis>().FirstOrDefault(x => x.IsPrimaryAxis) : null;

            if (primaryAxis == null)
            {
                // Try the existing primary
                primaryAxis = PrimaryAxis;
                if (primaryAxis == null)
                {
                    // If no new primary axis and no existing primary, then set the first axis in the collection to primary
                    primaryAxis = this.FirstOrDefault();
                    if (primaryAxis != null)
                        primaryAxis.IsPrimaryAxis = true;
                }
            }

            // All other axes (non primary) must be reset
            foreach (var axis in this)
            {
                if (axis == primaryAxis) continue;
                axis.IsPrimaryAxis = false;
            }
        }
    }
}