namespace Library.Algorithms.DynamicProgramming;

public interface IFibonacci
{
    public static ulong Memoized(int n)
    {
        ulong[] memo = new ulong[n + 1];

        return MemoizedRecurse(memo, n);
    }

    private static ulong MemoizedRecurse(ulong[] memo, int n)
    {
        if (n <= 1)
        {
            return (ulong)n;
        }

        if (memo[n] != 0ul)
        {
            return memo[n];
        }

        memo[n] = MemoizedRecurse(memo, n - 2) + MemoizedRecurse(memo, n - 1);

        if (memo[n] < memo[n - 1])
        {
            throw new OverflowException();
        }

        return memo[n];
    }

    public static ulong Naive(int n)
    {
        if (n <= 1)
        {
            return (ulong)n;
        }

        ulong a = Naive(n - 2);
        ulong b = Naive(n - 1);
        ulong c = a + b;

        if (c < b)
        {
            throw new OverflowException();
        }

        return c;
    }

    public static ulong Tabulated(int n)
    {
        ulong[] memo = new ulong[n + 1];
        memo[0] = 0ul;
        memo[1] = 1ul;

        for (int i = 2; i <= n; i++)
        {
            memo[i] = memo[i - 1] + memo[i - 2];

            if (memo[i] < memo[i - 1])
            {
                throw new OverflowException();
            }
        }

        return memo[n];
    }

    public static ulong TabulatedOptimal(int n)
    {
        if (n <= 1)
        {
            return (ulong)n;
        }

        ulong a = 0, b = 1, temp;

        for (int i = 2; i <= n; i++)
        {
            temp = b;
            b += a;
            a = temp;

            if (b < a)
            {
                throw new OverflowException();
            }
        }

        return b;
    }
}
