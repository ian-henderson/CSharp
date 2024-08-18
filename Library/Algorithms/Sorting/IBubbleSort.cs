namespace Library.Algorithms.Sorting;

// https://en.wikipedia.org/wiki/Bubble_sort
// Worst-case performance: O(n^2), O(n^2) swaps
// Best-case performance:  O(n), O(1) swap
// Average-case performance: O(n^2), O(n^2) swaps
// Worst-case complexity:  O(n) total O(1) auxillary

public interface IBubbleSort
{
    public static void Sort(int[] array)
    {
        if (IUtilities.IsSorted(array))
        {
            return;
        }

        int n = array.Length;

        while (n > 1)
        {
            int newN = 0;

            for (int i = 1; i < n; i++)
            {
                if (array[i - 1] > array[i])
                {
                    IUtilities.Swap(array, i - 1, i);
                    newN = i;
                }
            }

            n = newN;
        }
    }
}
