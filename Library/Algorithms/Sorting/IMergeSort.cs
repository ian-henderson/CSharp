using System.Security.AccessControl;

namespace Library.Algorithms.Sorting;

// https://en.wikipedia.org/wiki/Merge_sort
// Worst-case performance:      O(n*log(n))
// Best-case performance:       Omega(n*log(n)), O(n) with best-case check
// Average performance:         Theta(n*log(n))
// Worst-case space complexity: O(n) total with O(n) auxillary, O(1) auxillary
//                                  with linked lists

public interface IMergeSort
{
    public static void Sort(int[] array)
    {
        if (IUtilities.IsSorted(array))
        {
            return;
        }

        Recurse(array, 0, array.Length - 1);
    }

    private static void Recurse(int[] array, int left, int right)
    {
        if (left >= right)
        {
            return;
        }

        int mid = left + (right - left) / 2;
        Recurse(array, left, mid);
        Recurse(array, mid + 1, right);
        Merge(array, left, mid, right);
    }

    private static void Merge(int[] array, int left, int mid, int right)
    {
        int subArrayOne = mid - left + 1,
            subArrayTwo = right - mid;

        int[] leftArray = new int[subArrayOne],
              rightArray = new int[subArrayTwo];

        // Copy data to arrays
        for (int i = 0; i < subArrayOne; i++)
        {
            leftArray[i] = array[left + i];
        }
        for (int i = 0; i < subArrayTwo; i++)
        {
            rightArray[i] = array[mid + 1 + i];
        }

        int indexOfMergedArray = left,
            indexOfSubarrayOne = 0,
            indexOfSubarrayTwo = 0;

        // Merge arrays back into array[left..right]
        while (indexOfSubarrayOne < subArrayOne && indexOfSubarrayTwo < subArrayTwo)
        {
            if (leftArray[indexOfSubarrayOne] <= rightArray[indexOfSubarrayTwo])
            {
                array[indexOfMergedArray++] = leftArray[indexOfSubarrayOne++];
            }
            else
            {
                array[indexOfMergedArray++] = rightArray[indexOfSubarrayTwo++];
            }
        }

        // Copy the remaining elements of leftArray if there are any
        while (indexOfSubarrayOne < subArrayOne)
        {
            array[indexOfMergedArray++] = leftArray[indexOfSubarrayOne++];
        }

        // Copy the remaining elements of leftArray if there are any
        while (indexOfSubarrayTwo < subArrayTwo)
        {
            array[indexOfMergedArray++] = rightArray[indexOfSubarrayTwo++];
        }
    }
}
