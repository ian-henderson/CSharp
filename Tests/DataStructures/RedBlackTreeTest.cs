using Library.DataStructures.RedBlackTree;

namespace Tests.DataStructures;

public class RedBlackTreeTest
{
    int[] _keys = Enumerable.Range(0, 10_000).ToArray();

    [Fact]
    public void RedBlackTreeShouldHaveCorrectHeightWhenEmpty()
    {
        RedBlackTree t = new();
        Assert.Equal(-1, t.GetHeight());
    }

    [Fact]
    public void RedBlackTreeShouldReturnNullForNoSearchResult()
    {
        RedBlackTree t = new();
        Assert.Null(t.Search(0));
    }

    [Fact]
    public void RedBlackTreeShouldHaveCorrectHeightWhenOneElement()
    {
        RedBlackTree t = new();
        t.Insert(0);
        Assert.Equal(0, t.GetHeight());
        Assert.Equal(0, t.Search(0));
    }

    [Fact]
    public void RedBlackTreeShouldInsertAndRemove()
    {
        RedBlackTree t = new();
        t.Insert(0);
        Assert.Equal(0, t.Search(0));
        t.Delete(0);
        Assert.Equal(-1, t.GetHeight());
        Assert.Null(t.Search(0));
    }

    [Fact]
    public void RedBlackTreeShouldInsertAndRemoveMultipleValues()
    {
        RedBlackTree t = new();

        foreach (int key in _keys)
        {
            t.Insert(key);
            Assert.Equal(key, t.Search(key));
        }

        foreach (int key in _keys)
        {
            t.Delete(key);
            Assert.Null(t.Search(key));
        }

        Assert.Equal(-1, t.GetHeight());
    }
}
