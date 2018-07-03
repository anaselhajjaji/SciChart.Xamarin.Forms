namespace SciChart.Xamarin.Views
{
    /// <summary>
    /// Extension methods for <see cref="System.Single"/> types
    /// </summary>
    public static class FloatExtensions
    {
        /// <summary>
        /// Converts a <see cref="float"/> to <see cref="int"/> while avoiding arithmetic overflow
        /// </summary>
        /// <param name="d">The Double.</param>
        /// <returns>The equivalent Int32</returns>
        public static float ClipToInt(this float d)
        {
            if (d > int.MaxValue)
                return int.MaxValue;

            if (d < int.MinValue)
                return int.MinValue;

            return d;
        }

        /// <summary>
        /// Determines whether the <see cref="float"/> is a NaN
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsNaN(this float value)
        {
            // Fast NaN check. 
            // NOTE: Value != Value check is intentional
            // http://stackoverflow.com/questions/3286492/can-i-improve-the-double-isnan-x-function-call-on-embedded-c
            // 

            // ReSharper disable EqualExpressionComparison
            // ReSharper disable CompareOfFloatsByEqualityOperator
#pragma warning disable 1718
            return value != value;
#pragma warning restore 1718
            // ReSharper restore CompareOfFloatsByEqualityOperator
            // ReSharper restore EqualExpressionComparison
        }
    }
}