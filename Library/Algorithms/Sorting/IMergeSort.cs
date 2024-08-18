namespace Library.Algorithms.Sorting;

// https://en.wikipedia.org/wiki/Merge_sort
// Worst-case performance:      O(n*log(n))
// Best-case performance:       Omega(n*log(n)), O(n) with best-case check
// Average performance:         Theta(n*log(n))
// Worst-case space complexity: O(n) total with O(n) auxillary, O(1) auxillary
//                                  with linked lists

public interface IMergeSort
{
    public static void Sort(int[] array) { }

    private static void Recurse(int[] array, int begin, int end) { }

    private static void Merge(int[] array, int begin, int mid, int end) { }
}
