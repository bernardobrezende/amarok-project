using System;
using System.Collections.Generic;
using Amarok.Framework.Contracts;

namespace Amarok.Framework.Extensions
{
    public static class IListExtensions
    {
        public static void Swap<T>(this IList<T> list, int currentIndex, int destinationIndex)
        {
            Ensure.That(currentIndex >= 0 && currentIndex < list.Count && destinationIndex >= 0 && destinationIndex < list.Count)
                .IsTrue()
                .Otherwise()
                .Throw<IndexOutOfRangeException>("Informed indexes cannot be out of the list's range.");
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