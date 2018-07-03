using System;
using SciChart.Xamarin.Views.Model;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    /// <summary>
    /// Event Args used by the <see cref="AxisCore.VisibleRangeChanged"/> event
    /// </summary>
    public class VisibleRangeChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the old <see cref="IAxisParams.VisibleRange"/> before the operation
        /// </summary>
        public IRange OldVisibleRange { get; private set; }

        /// <summary>
        /// Gets the new <see cref="IAxisParams.VisibleRange"/> before the operation
        /// </summary>
        public IRange NewVisibleRange { get; private set; }

        /// <summary>
        /// Gets the value, indicating whether the current notification was caused by animation
        /// </summary>
        public bool IsAnimating { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VisibleRangeChangedEventArgs" /> class.
        /// </summary>
        /// <param name="oldRange">The old range.</param>
        /// <param name="newRange">The new range.</param>
        /// <param name="isAnimationChange">The value, indicating whether the notification is fired during animation</param>
        public VisibleRangeChangedEventArgs(IRange oldRange, IRange newRange, bool isAnimationChange)
        {
            OldVisibleRange = oldRange;
            NewVisibleRange = newRange;

            IsAnimating = isAnimationChange;
        }
    }
}