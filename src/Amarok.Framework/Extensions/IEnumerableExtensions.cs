using System;
using System.Collections.Generic;
using System.Linq;

namespace Amarok.Framework.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> OnlyNotNull<T>(this IEnumerable<T> collection)
        {
            return collection != null ? collection.Where(x => x != null) : Activator.CreateInstance<List<T>>();
        }
    }
}