using System;
using System.Collections.Generic;
using System.Text;

namespace SciChart.Xamarin.Views
{
    internal static class Extensions
    {
        internal static void ForEachDo<T>(this IEnumerable<T> list, Action<T> operation)
        {
            if (list != null)
            {
                foreach (var item in list)
                {
                    operation(item);
                }
            }
        }
    }

   
}
