namespace SciChart.Xamarin.Views.Visuals.Axes
{
    public enum AxisAlignment
    {
        /// <summary>
        /// Axis is on the Right-side of the chart surface
        /// </summary>
        Right,

        /// <summary>
        /// Axis is on the Left-side of the chart surface
        /// </summary>
        Left,

        /// <summary>
        /// Axis is on the Top-edge of the chart surface
        /// </summary>
        Top,

        /// <summary>
        /// Axis is on the Bottom-edge of the chart surface
        /// </summary>
        Bottom,

        /// <summary>
        /// Axis is on the Bottom-edge of the chart surface
        /// </summary>
        Default
    }

    public interface IAxis : IAxisCore
    {
        AxisAlignment AxisAlignment { get; set; }
    }
}