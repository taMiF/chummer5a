/*  This file is part of Chummer5a.
 *
 *  Chummer5a is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  Chummer5a is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Chummer5a.  If not, see <http://www.gnu.org/licenses/>.
 *
 *  You can obtain the full source code for Chummer5a at
 *  https://github.com/chummer5a/chummer5a
 */

using System;
using System.Collections.Generic;
using System.Linq;
using Chummer.Annotations;

namespace Chummer
{
    public static class ListExtensions
    {
        public static void AddWithSort<T>(this IList<T> lstCollection, T objNewItem, Action<T, T> funcOverrideIfEquals = null) where T : IComparable
        {
            if (lstCollection == null)
                throw new ArgumentNullException(nameof(lstCollection));
            // Binary search for the place where item should be inserted
            int intIntervalStart = 0;
            int intIntervalEnd = lstCollection.Count - 1;
            int intTargetIndex = intIntervalEnd / 2;
            for (; intIntervalStart <= intIntervalEnd; intTargetIndex = (intIntervalStart + intIntervalEnd) / 2)
            {
                T objLoopExistingItem = lstCollection[intTargetIndex];
                int intCompareResult = objLoopExistingItem.CompareTo(objNewItem);
                if (intCompareResult == 0)
                {
                    // Make sure we insert new items at the end of any equalities (so that order is maintained when adding multiple items)
                    for (int i = intTargetIndex + 1; i < lstCollection.Count; ++i)
                    {
                        T objInnerLoopExistingItem = lstCollection[i];
                        if (objInnerLoopExistingItem.CompareTo(objNewItem) == 0)
                        {
                            ++intTargetIndex;
                            objLoopExistingItem = objInnerLoopExistingItem;
                        }
                        else
                            break;
                    }
                    if (funcOverrideIfEquals != null)
                    {
                        funcOverrideIfEquals.Invoke(objLoopExistingItem, objNewItem);
                        return;
                    }
                    break;
                }
                if (intIntervalStart == intIntervalEnd)
                {
                    if (intCompareResult > 0)
                        intTargetIndex += 1;
                    break;
                }
                if (intCompareResult > 0)
                    intIntervalStart = intTargetIndex + 1;
                else
                    intIntervalEnd = intTargetIndex - 1;
            }
            lstCollection.Insert(intTargetIndex, objNewItem);
        }

        public static void AddWithSort<T>(this IList<T> lstCollection, T objNewItem, IComparer<T> comparer, Action<T, T> funcOverrideIfEquals = null)
        {
            if (lstCollection == null)
                throw new ArgumentNullException(nameof(lstCollection));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));
            // Binary search for the place where item should be inserted
            int intIntervalStart = 0;
            int intIntervalEnd = lstCollection.Count - 1;
            int intTargetIndex = intIntervalEnd / 2;
            for (; intIntervalStart <= intIntervalEnd; intTargetIndex = (intIntervalStart + intIntervalEnd) / 2)
            {
                T objLoopExistingItem = lstCollection[intTargetIndex];
                int intCompareResult = comparer.Compare(objLoopExistingItem, objNewItem);
                if (intCompareResult == 0)
                {
                    // Make sure we insert new items at the end of any equalities (so that order is maintained when adding multiple items)
                    for (int i = intTargetIndex + 1; i < lstCollection.Count; ++i)
                    {
                        T objInnerLoopExistingItem = lstCollection[i];
                        if (comparer.Compare(objInnerLoopExistingItem, objNewItem) == 0)
                        {
                            ++intTargetIndex;
                            objLoopExistingItem = objInnerLoopExistingItem;
                        }
                        else
                            break;
                    }
                    if (funcOverrideIfEquals != null)
                    {
                        funcOverrideIfEquals.Invoke(objLoopExistingItem, objNewItem);
                        return;
                    }
                    break;
                }
                if (intIntervalStart == intIntervalEnd)
                {
                    if (intCompareResult > 0)
                        intTargetIndex += 1;
                    break;
                }
                if (intCompareResult > 0)
                    intIntervalStart = intTargetIndex + 1;
                else
                    intIntervalEnd = intTargetIndex - 1;
            }
            lstCollection.Insert(intTargetIndex, objNewItem);
        }

        public static void AddWithSort<T>(this IList<T> lstCollection, T objNewItem, Comparison<T> funcComparison, Action<T, T> funcOverrideIfEquals = null)
        {
            if (lstCollection == null)
                throw new ArgumentNullException(nameof(lstCollection));
            if (funcComparison == null)
                throw new ArgumentNullException(nameof(funcComparison));
            // Binary search for the place where item should be inserted
            int intIntervalStart = 0;
            int intIntervalEnd = lstCollection.Count - 1;
            int intTargetIndex = intIntervalEnd / 2;
            for (; intIntervalStart <= intIntervalEnd; intTargetIndex = (intIntervalStart + intIntervalEnd) / 2)
            {
                T objLoopExistingItem = lstCollection[intTargetIndex];
                int intCompareResult = funcComparison.Invoke(objLoopExistingItem, objNewItem);
                if (intCompareResult == 0)
                {
                    // Make sure we insert new items at the end of any equalities (so that order is maintained when adding multiple items)
                    for (int i = intTargetIndex + 1; i < lstCollection.Count; ++i)
                    {
                        T objInnerLoopExistingItem = lstCollection[i];
                        if (funcComparison.Invoke(objInnerLoopExistingItem, objNewItem) == 0)
                        {
                            ++intTargetIndex;
                            objLoopExistingItem = objInnerLoopExistingItem;
                        }
                        else
                            break;
                    }
                    if (funcOverrideIfEquals != null)
                    {
                        funcOverrideIfEquals.Invoke(objLoopExistingItem, objNewItem);
                        return;
                    }
                    break;
                }
                if (intIntervalStart == intIntervalEnd)
                {
                    if (intCompareResult > 0)
                        intTargetIndex += 1;
                    break;
                }
                if (intCompareResult > 0)
                    intIntervalStart = intTargetIndex + 1;
                else
                    intIntervalEnd = intTargetIndex - 1;
            }
            lstCollection.Insert(intTargetIndex, objNewItem);
        }

        public static void AddRange<T>(this IList<T> lstCollection, IEnumerable<T> lstToAdd)
        {
            if (lstCollection == null)
                throw new ArgumentNullException(nameof(lstCollection));
            if (lstToAdd == null)
                throw new ArgumentNullException(nameof(lstToAdd));
            foreach (T objItem in lstToAdd)
                lstCollection.Add(objItem);
        }

        public static void AddRangeWithSort<T>(this IList<T> lstCollection, IEnumerable<T> lstToAdd, Action<T, T> funcOverrideIfEquals = null) where T : IComparable
        {
            if (lstCollection == null)
                throw new ArgumentNullException(nameof(lstCollection));
            if (lstToAdd == null)
                throw new ArgumentNullException(nameof(lstToAdd));
            foreach (T objItem in lstToAdd)
                AddWithSort(lstCollection, objItem, funcOverrideIfEquals);
        }

        public static void AddRangeWithSort<T>(this IList<T> lstCollection, IEnumerable<T> lstToAdd, IComparer<T> comparer, Action<T, T> funcOverrideIfEquals = null)
        {
            if (lstCollection == null)
                throw new ArgumentNullException(nameof(lstCollection));
            if (lstToAdd == null)
                throw new ArgumentNullException(nameof(lstToAdd));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));
            foreach (T objItem in lstToAdd)
                AddWithSort(lstCollection, objItem, comparer, funcOverrideIfEquals);
        }

        public static void AddRangeWithSort<T>(this IList<T> lstCollection, IEnumerable<T> lstToAdd, Comparison<T> funcComparison, Action<T, T> funcOverrideIfEquals = null)
        {
            if (lstCollection == null)
                throw new ArgumentNullException(nameof(lstCollection));
            if (lstToAdd == null)
                throw new ArgumentNullException(nameof(lstToAdd));
            if (funcComparison == null)
                throw new ArgumentNullException(nameof(funcComparison));
            foreach (T objItem in lstToAdd)
                AddWithSort(lstCollection, objItem, funcComparison, funcOverrideIfEquals);
        }

        public static void RemoveRange<T>(this IList<T> lstCollection, int index, int count)
        {
            if (lstCollection == null)
                throw new ArgumentNullException(nameof(lstCollection));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (lstCollection.Count == 0)
                return;
            if (index >= lstCollection.Count)
                throw new ArgumentException(nameof(index));
            if (count == 0)
                throw new ArgumentException(nameof(count));
            for (int i = Math.Min(index + count - 1, lstCollection.Count); i >= index; --i)
                lstCollection.RemoveAt(i);
        }

        public static void RemoveAll<T>(this IList<T> lstCollection, Predicate<T> predicate)
        {
            if (lstCollection == null)
                throw new ArgumentNullException(nameof(lstCollection));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            for (int i = lstCollection.Count - 1; i >= 0; --i)
            {
                if (predicate(lstCollection[i]))
                {
                    lstCollection.RemoveAt(i);
                }
            }
        }

        public static void InsertRange<T>(this IList<T> lstCollection, int index, [NotNull] IEnumerable<T> collection)
        {
            foreach (T item in collection.Reverse())
            {
                lstCollection.Insert(index, item);
            }
        }

        public static int BinarySearch<T>(this IList<T> lstCollection, T objItem) where T : IComparable
        {
            int intLastIntervalBounds = lstCollection.Count - 1;
            int intBase = 0;
            for (int i = intLastIntervalBounds / 2; i > 0; i = intLastIntervalBounds / 2)
            {
                int intLoopIndex = intBase + i;
                int intCompareResult = objItem.CompareTo(lstCollection[intLoopIndex]);
                if (intCompareResult == 0)
                    return intLoopIndex;
                if (intCompareResult > 0)
                {
                    intBase += intLastIntervalBounds - i;
                    intLastIntervalBounds -= i; // Makes sure that for odd sizes, we end up spanning every item
                }
                else
                {
                    intLastIntervalBounds = i;
                }
            }

            return ~(intBase + 1); // Bitwise complement of next item larger than this one, just like List.BinarySearch
        }

        public static int BinarySearch<T>(this IList<T> lstCollection, T objItem, IComparer<T> comparer)
        {
            int intLastIntervalBounds = lstCollection.Count - 1;
            int intBase = 0;
            for (int i = intLastIntervalBounds / 2; i > 0; i = intLastIntervalBounds / 2)
            {
                int intLoopIndex = intBase + i;
                int intCompareResult = comparer.Compare(objItem, lstCollection[intLoopIndex]);
                if (intCompareResult == 0)
                    return intLoopIndex;
                if (intCompareResult > 0)
                {
                    intBase += intLastIntervalBounds - i;
                    intLastIntervalBounds -= i; // Makes sure that for odd sizes, we end up spanning every item
                }
                else
                {
                    intLastIntervalBounds = i;
                }
            }

            return ~(intBase + 1); // Bitwise complement of next item larger than this one, just like List.BinarySearch
        }

        public static int BinarySearch<T>(this IList<T> lstCollection, int index, int count, T objItem, IComparer<T> comparer)
        {
            int intLastIntervalBounds = count - 1;
            int intBase = index;
            for (int i = intLastIntervalBounds / 2; i > 0; i = intLastIntervalBounds / 2)
            {
                int intLoopIndex = intBase + i;
                int intCompareResult = comparer.Compare(objItem, lstCollection[intLoopIndex]);
                if (intCompareResult == 0)
                    return intLoopIndex;
                if (intCompareResult > 0)
                {
                    intBase += intLastIntervalBounds - i;
                    intLastIntervalBounds -= i; // Makes sure that for odd sizes, we end up spanning every item
                }
                else
                {
                    intLastIntervalBounds = i;
                }
            }

            return ~(intBase + 1); // Bitwise complement of next item larger than this one, just like List.BinarySearch
        }

        public static int FindIndex<T>(this IList<T> lstCollection, Predicate<T> predicate)
        {
            for (int i = 0; i < lstCollection.Count; ++i)
            {
                if (predicate(lstCollection[i]))
                    return i;
            }
            return -1;
        }

        public static int FindIndex<T>(this IList<T> lstCollection, int startIndex, Predicate<T> predicate)
        {
            for (int i = startIndex; i < lstCollection.Count; ++i)
            {
                if (predicate(lstCollection[i]))
                    return i;
            }
            return -1;
        }

        public static int FindIndex<T>(this IList<T> lstCollection, int startIndex, int count, Predicate<T> predicate)
        {
            int intUpperBounds = count - startIndex;
            for (int i = startIndex; i < Math.Min(lstCollection.Count, intUpperBounds); ++i)
            {
                if (predicate(lstCollection[i]))
                    return i;
            }
            return -1;
        }

        public static int FindLastIndex<T>(this IList<T> lstCollection, Predicate<T> predicate)
        {
            for (int i = lstCollection.Count - 1; i >= 0; --i)
            {
                if (predicate(lstCollection[i]))
                    return i;
            }
            return -1;
        }

        public static int FindLastIndex<T>(this IList<T> lstCollection, int startIndex, Predicate<T> predicate)
        {
            for (int i = startIndex; i >= 0; --i)
            {
                if (predicate(lstCollection[i]))
                    return i;
            }
            return -1;
        }

        public static int FindLastIndex<T>(this IList<T> lstCollection, int startIndex, int count, Predicate<T> predicate)
        {
            int intLowerBounds = startIndex - count;
            for (int i = startIndex; i >= Math.Max(0, intLowerBounds); --i)
            {
                if (predicate(lstCollection[i]))
                    return i;
            }
            return -1;
        }

        public static int LastIndexOf<T>(this IList<T> lstCollection, T objItem)
        {
            if (lstCollection == null)
                throw new ArgumentNullException(nameof(lstCollection));
            if (objItem == null)
                throw new ArgumentNullException(nameof(objItem));
            for (int i = lstCollection.Count - 1; i >= 0; --i)
            {
                if (lstCollection[i].Equals(objItem))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
