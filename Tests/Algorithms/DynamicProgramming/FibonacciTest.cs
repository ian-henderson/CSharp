namespace Tests.Algorithms.DynamicProgramming;

using Library.Algorithms.DynamicProgramming;

public class FibonacciTest
{
    [Fact]
    public void FibonacciMemoizedShouldBeCorrect()
    {
        Assert.Equal(9_227_465ul, IFibonacci.Memoized(35));
    }

    [Fact]
    public void FibonacciNaiveShouldBeCorrect()
    {
        Assert.Equal(9_227_465ul, IFibonacci.Naive(35));
    }

    [Fact]
    public void FibonacciTabulatedShouldBeCorrect()
    {
        Assert.Equal(9_227_465ul, IFibonacci.Tabulated(35));
    }

    [Fact]
    public void FibonacciTabulatedOptimalShouldBeCorrect()
    {
        Assert.Equal(9_227_465ul, IFibonacci.TabulatedOptimal(35));
    }
}
