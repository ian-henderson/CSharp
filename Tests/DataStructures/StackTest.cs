namespace Tests.DataStructures;

using Library.DataStructures.Stack;

public class StackTest
{
    [Fact]
    public void StackShouldPopNullWhenEmpty()
    {
        Stack s = new();
        Assert.Null(s.Pop());
    }

    [Fact]
    public void StackShouldPushAndPeek()
    {
        Stack s = new();
        s.Push(0);
        Assert.Equal(0, s.Peek());
    }

    [Fact]
    public void StackShouldPushAndPop()
    {
        int[] values = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
        Stack s = new();

        foreach (int value in values)
        {
            s.Push(value);
            Assert.Equal(value, s.Peek());
        }

        for (int i = values.Length - 1; i >= 0; i--)
        {
            Assert.Equal(values[i], s.Pop());
        }
    }
}
