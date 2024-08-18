using Library.DataStructures.Queue;

namespace Tests.DataStructures;

public class QueueTest
{
    [Fact]
    public void QueueShouldPeekNullWhenEmpty()
    {
        Queue q = new();
        Assert.Null(q.Peek());
    }

    [Fact]
    public void QueueRemoveShouldReturnNullWhenEmpty()
    {
        Queue q = new();
        Assert.Null(q.Remove());
    }

    [Fact]
    public void QueueShouldAddAndPeek()
    {
        Queue q = new();
        q.Add(0);
        Assert.Equal(0, q.Peek());
    }

    [Fact]
    public void QueueShouldAddAndRemove()
    {
        Queue q = new();
        q.Add(0);
        Assert.Equal(0, q.Remove());
    }

    [Fact]
    public void QueueShouldAddAndRemoveMultipleValues()
    {
        int[] keys = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
        Queue q = new();

        foreach (int key in keys)
        {
            q.Add(key);
        }

        foreach (int key in keys)
        {
            Assert.Equal(key, q.Peek());
            Assert.Equal(key, q.Remove());
        }

        Assert.Null(q.Peek());
        Assert.Null(q.Remove());
    }
}
