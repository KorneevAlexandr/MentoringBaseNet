using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCabinet.Console.Extensions
{
    public static class ObjectExtensions
    {
        public static bool In<T>(this T value, params T[] values) => values.Contains(value);

        public static bool NotIn<T>(this T value, params T[] values) => !values.Contains(value);

        public static void Show<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                System.Console.WriteLine(item.ToString());
                System.Console.WriteLine();
            }
        }
    }
}
