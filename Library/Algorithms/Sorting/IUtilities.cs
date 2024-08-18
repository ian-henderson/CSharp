namespace Library.Algorithms.Sorting;

public interface IUtilities
{
    public static bool IsSorted(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i + 1] < array[i])
            {
                return false;
            }
        }

        return true;
    }

    public static void Swap(int[] array, int i, int j)
    {
        (array[j], array[i]) = (array[i], array[j]);
    }
}
