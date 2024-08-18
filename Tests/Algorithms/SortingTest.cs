namespace Tests.Algorithms;

using Library.Algorithms.Sorting;

public class SortingTest
{
    private int[] _unsortedArray;

    public SortingTest()
    {
        int n = 10_000;
        _unsortedArray = new int[n];
        Random random = new();

        for (int i = 0; i < n; i++)
        {
            _unsortedArray[i] = random.Next();
        }
    }

    private int[] CopyUnsortedArray()
    {
        return (int[])_unsortedArray.Clone();
    }

    [Fact]
    public void BubbleSortShouldSortArray()
    {
        int[] array = CopyUnsortedArray();
        IBubbleSort.Sort(array);
        Assert.True(IUtilities.IsSorted(array));
    }

    [Fact]
    public void HeapSortShouldSortArray()
    {
        int[] array = CopyUnsortedArray();
        IHeapSort.Sort(array);
        Assert.True(IUtilities.IsSorted(array));
    }

    [Fact]
    public void InsertionSortShouldSortArray()
    {
        int[] array = CopyUnsortedArray();
        IInsertionSort.Sort(array);
        Assert.True(IUtilities.IsSorted(array));
    }
}
