using System.Reflection.Metadata;

namespace Library.Algorithms.Sorting;

// https://en.wikipedia.org/wiki/Selection_sort
// Worst-case performance:      O(n^2) comparisons, O(n) swaps
// Best-case performance:       O(n^2) comparisons (O(n) with best-case check), O(1) swap
// Average performance:         O(n^2) comparisons, O(n) swaps
// Worst-case Space Complexity: O(1) auxillary

public interface ISelectionSort
{
    public static void Sort(int[] array)
    {
        if (IUtilities.IsSorted(array))
        {
            return;
        }

        for (int i = 0; i < array.Length - 1; i++)
        {
            int smallestIndex = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[smallestIndex])
                {
                    smallestIndex = j;
                }
            }

            if (i != smallestIndex)
            {
                IUtilities.Swap(array, i, smallestIndex);
            }
        }
    }
}
