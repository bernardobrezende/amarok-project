using System;
using System.Collections.Generic;

namespace Amarok.Framework.Extensions
{
    public static class IListExtensions
    {
        public static void Swap<T>(this IList<T> list, int currentIndex, int destinationIndex)
        {
            if (currentIndex > list.Count || currentIndex < 0 ||
                destinationIndex > list.Count || destinationIndex < 0)
                throw new IndexOutOfRangeException("Informed indexes cannot be out of the list's range.");
            //
            if (currentIndex != destinationIndex)
            {
                T currentDestinationObj = list[destinationIndex];
                list[destinationIndex] = list[currentIndex];
                list[currentIndex] = currentDestinationObj;
            }
        }

        public static void Swap<T>(this IList<T> list, T currentElement, T destinationElement)
        {
            int firstIndex = list.IndexOf(currentElement);
            int destinationIndex = list.IndexOf(destinationElement);
            //
            list.Swap(firstIndex, destinationIndex);
        }
    }
}