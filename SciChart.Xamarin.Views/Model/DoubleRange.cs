using System;
using System.Collections.Generic;
using System.Text;

namespace SciChart.Xamarin.Views.Model
{
    public enum AutoRange
    {
        Once,
        Always,
        Never
    }

    public class DoubleRange
    {
        public double Min { get; set; }
        public double Max { get; set; }
    }
}
