namespace Library.Algorithms.Sorting;

// https://en.wikipedia.org/wiki/Heapsort
// Worst-case performance: O(n*log(n))
// Best-case performance:  O(n*log(n)) (distinct keys) or O(n) (equal keys)
//                         O(n) with best-case check
// Average performance:    O(n*log(n))
// Worst-case complexity:  O(n) total O(1) auxillary

public interface IHeapSort
{
    public static void Sort(int[] array)
    {
        if (IUtilities.IsSorted(array))
        {
            return;
        }

        int heapSize = array.Length;

        // build heap (rearrange array)
        for (int root = heapSize / 2 - 1; root >= 0; root--)
        {
            Heapify(array, heapSize, root);
        }

        // one by one, extract an element from the heap
        for (int i = heapSize - 1; i > 0; i--)
        {
            IUtilities.Swap(array, 0, i); // move current root to end
            Heapify(array, i, 0); // call max heapify on the reduced heap
        }
    }

    private static void Heapify(int[] array, int heapSize, int root)
    {
        int left = 2 * root + 1;
        int right = 2 * root + 2;
        int largest = root;

        // If left child is larger than root
        if (left < heapSize && array[left] > array[largest])
        {
            largest = left;
        }

        // If right child is larger than largest so far
        if (right < heapSize && array[right] > array[largest])
        {
            largest = right;
        }

        if (largest != root)
        {
            IUtilities.Swap(array, root, largest);

            // Recursively heapify the affected subtree
            Heapify(array, heapSize, largest);
        }
    }
}
