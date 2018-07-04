using System;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    public interface IAxisCore
    {
        /// <summary>
        /// Gets or sets the Axis Title
        /// </summary>
        /// <value>The axis title.</value>
        /// <remarks></remarks>
        string AxisTitle { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether to flip the tick and pixel coordinate generation for this axis, causing the axis ticks to decrement and chart to be flipped in the axis direction
        /// </summary>
        /// <value>
        ///   If <c>true</c> reverses the ticks and coordinates for the axis.
        /// </value>
        bool FlipCoordinates { get; set; }

        /// <summary>
        /// Gets or sets the Text Formatting String for Tick Labels on this axis
        /// </summary>
        /// <value>The text formatting.</value>
        /// <remarks></remarks>
        string TextFormatting { get; set; }

        /// <summary>
        /// If True, draws Minor Tick Lines, else skips this step
        /// </summary>
        /// <remarks></remarks>
        bool DrawMinorTicks { get; set; }

        /// <summary>
        /// If True, draw labels for each major tick on the Axis, else skips this step
        /// </summary>
        bool DrawLabels { get; set; }

        /// <summary>
        /// If True, draws Major Tick Lines, else skips this step
        /// </summary>
        /// <remarks></remarks>
        bool DrawMajorTicks { get; set; }

        /// <summary>
        /// If True, draws Major Grid Lines, else skips this step
        /// </summary>
        /// <remarks></remarks>
        bool DrawMajorGridLines { get; set; }

        /// <summary>
        /// If True, draws Minor Grid Lines, else skips this step
        /// </summary>
        /// <remarks></remarks>
        bool DrawMinorGridLines { get; set; }

        /// <summary>
        /// If True, draws Major Axis Bands (a filled area between major gridlines), else skips this step
        /// </summary>
        /// <remarks></remarks>
        bool DrawMajorBands { get; set; }

        /// <summary>
        /// Gets or sets the Fill of the Axis Bands. Also see <see cref="DrawMajorBands"/> to enable this behaviour
        /// </summary>
        /// <remarks></remarks>
        Color AxisBandsFill { get; set; }

        /// <summary>
        /// Gets or sets whether this current axis <see cref="AutoRange"/>. Default is AutoRange.Once
        /// </summary>
        /// <value>If AutoRange.Always, the axis should scale to fit the data, else AutoRange.Once, the axis will try to fit the data once. 
        /// If AutoRange.Never, then the axis will never autorange.</value>
        /// <remarks>GrowBy is applied when the axis scales to fit</remarks>
        AutoRange AutoRange { get; set; }

        /// <summary>
        /// Gets or sets the BindingContext for the axis 
        /// </summary>
        object BindingContext { get; set; }

        /// <summary>
        /// Gets or sets the String ID for this axis. An axis ID must be unique in the XAxes or YAxes collection of a <see cref="SciChartSurface"/>. RenderableSeries, Annotations and some modifiers are registered on an Axis via the properties like <see cref="IRenderableSeries.YAxisId"/> properties
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the VisibleRange of the Axis. In the case of XAxis, this will cause an align to X-Axis operation to take place
        /// </summary>
        /// <remarks>Setting the VisibleRange will cause the axis to redraw</remarks>
        IRange VisibleRange { get; set; }

        /// <summary>
        /// Gets or sets the GrowBy Factor. e.g. GrowBy(0.1, 0.2) will increase the axis extents by 10% (min) and 20% (max) outside of the data range
        /// </summary>
        DoubleRange GrowBy { get; set; }

        /// <summary>
        /// Raised when the VisibleRange is changed
        /// </summary>
        event EventHandler<VisibleRangeChangedEventArgs> VisibleRangeChanged;
    }
}