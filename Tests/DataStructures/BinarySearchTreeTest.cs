using Library.DataStructures.BinarySearchTree;

namespace Tests.DataStructures;

public class BinarySearchTreeTest
{
    int[] _keys;

    public BinarySearchTreeTest()
    {
        int arrayLength = 10_000;
        _keys = new int[arrayLength];
        Random random = new Random();

        for (int i = 0; i < arrayLength; i++)
        {
            _keys[i] = random.Next();
        }
    }

    [Fact]
    public void BinarySearchTreeShouldHaveCorrectHeightWhenEmpty()
    {
        BinarySearchTree t = new();
        Assert.Equal(-1, t.GetHeight());
    }

    [Fact]
    public void BinarySearchTreeShouldReturnNullForNoSearchResult()
    {
        BinarySearchTree t = new();
        Assert.Null(t.Search(0));
    }

    [Fact]
    public void BinarySearchTreeShouldHaveCorrectHeightWhenOneElement()
    {
        BinarySearchTree t = new();
        t.Insert(0);
        Assert.Equal(0, t.GetHeight());
        Assert.Equal(0, t.Search(0));
    }

    [Fact]
    public void BinarySearchTreeShouldInsertAndRemove()
    {
        BinarySearchTree t = new();
        t.Insert(0);
        Assert.Equal(0, t.Search(0));
        t.Delete(0);
        Assert.Equal(-1, t.GetHeight());
        Assert.Null(t.Search(0));
    }

    [Fact]
    public void BinarySearchTreeShouldInsertAndRemoveMultipleValues()
    {
        BinarySearchTree t = new();

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

    [Fact]
    public void BinarySearchTreeGetPredecessorShouldReturnNullWhenKeyDoesNotExist()
    {
        BinarySearchTree t = new();
        Assert.Null(t.GetPredecessor(0));
    }

    [Fact]
    public void BinarySearchTreeGetPredecessorShouldReturnNullWhenPredecessorDoesNotExist()
    {
        BinarySearchTree t = new();
        t.Insert(0);
        Assert.Null(t.GetPredecessor(0));
    }

    [Fact]
    public void BinarySearchTreeGetPredecessorShouldReturnPredecessor()
    {
        BinarySearchTree t = new();
        t.Insert(0);
        t.Insert(1);
        Assert.Equal(0, t.GetPredecessor(1));
    }

    [Fact]
    public void BinarySearchTreeGetSuccessorShouldReturnNullWhenKeyDoesNotExist()
    {
        BinarySearchTree t = new();
        Assert.Null(t.GetSuccessor(0));
    }

    [Fact]
    public void BinarySearchTreeGetSuccessorShouldReturnNullWhenSuccessorDoesNotExist()
    {
        BinarySearchTree t = new();
        t.Insert(0);
        Assert.Null(t.GetSuccessor(0));
    }

    [Fact]
    public void BinarySearchTreeGetSuccessorShouldReturnSuccessor()
    {
        BinarySearchTree t = new();
        t.Insert(0);
        t.Insert(1);
        Assert.Equal(1, t.GetSuccessor(0));
    }

}
