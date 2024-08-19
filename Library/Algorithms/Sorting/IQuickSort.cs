using System.Collections.Concurrent;
using System.Reflection.Metadata;

namespace Library.Algorithms.Sorting;

// https://en.wikipedia.org/wiki/Quicksort
// Worst-case performance:      O(n^2)
// Best-case performance:       O(n*log(n)) (simple partition),
//                                  O(n) (three-way partition and equal keys)
//                                  O(n) with best-case check
// Average performance:         O(n*log(n))
// Worst-case Space Complexity: O(n) auxillary (naive)
//                              O(log(n)) auxillary (Hoare 1962)

public interface IQuickSort
{
    public static void Sort(int[] array)
    {
        if (IUtilities.IsSorted(array))
        {
            return;
        }

        Recurse(array, 0, array.Length - 1);
    }

    private static void Recurse(int[] array, int low, int high)
    {
        if (low >= high)
        {
            return;
        }

        int partitionIndex = Partition(array, low, high);
        Recurse(array, low, partitionIndex - 1);
        Recurse(array, partitionIndex + 1, high);
    }

    // Partition takes the last element as pivot, places the pivot element at
    // its correct position in sorted array, and places all smaller to left of
    // pivot and all greater elements to the right of pivot.
    private static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];

        // Index of smaller element and indicates the right position of the 
        // pivot found so far.
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            // If current element is smaller than the pivot
            if (array[j] < pivot)
            {
                IUtilities.Swap(array, ++i, j);
            }
        }

        IUtilities.Swap(array, i + 1, high);

        return i + 1;
    }
}
