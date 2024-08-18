namespace Library.Algorithms.Sorting;

// https://en.wikipedia.org/wiki/Insertion_sort
// Worst case:                  O(n^2) comparisons and swaps
// Best case:                   O(n) comparisons and O(1) swaps
// Average performance:         O(n^2) comparisons and swaps
// Worst-case space complexity: O(n) total, O(1) auxillary

public interface IInsertionSort
{
    public static void Sort(int[] array)
    {
        if (IUtilities.IsSorted(array))
        {
            return;
        }

        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i;

            while (j > 0 && array[j - 1] > key)
            {
                array[j] = array[j - 1];
                j--;
            }

            array[j] = key;
        }
    }
}
