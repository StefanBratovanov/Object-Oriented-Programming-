

namespace _01_CustomLINQExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class LinqExtensions
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> filterPredicate)
        {
            return collection.Where(element => !filterPredicate(element)).ToList();
        }

        public static TSelector Max<TS, TSelector>(this IEnumerable<TS> collection,
                                                        Func<TS, TSelector> filterPredicate) where TSelector : IComparable
        {
            var max = default(TSelector);
            foreach (var element in collection)
            {
                if (filterPredicate(element).CompareTo(max) > 0)
                {
                    max = filterPredicate(element);
                }
            }

            return max;
        }
    }
}
