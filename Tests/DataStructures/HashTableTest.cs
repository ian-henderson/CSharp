namespace Tests.DataStructures;

using Library.DataStructures.HashTable;

public class HashTableTest
{
    readonly (string, string)[] _entries = [
        ( "foo", "bar" ),
        ( "baz", "qux" ),
        ( "quux", "corge" ),
        ( "grault", "garply" ),
        ( "waldo", "fred" ),
        ( "plugh", "fred" ),
    ];

    [Fact]
    public void HashTableShouldReturnNullWhenNoValue()
    {
        HashTable t = new();
        Assert.Null(t.Get("some key"));
    }

    [Fact]
    public void HashTableShouldHandleMultipleValues()
    {
        HashTable t = new();

        foreach (var (key, value) in _entries)
        {
            t.Set(key, value);
            Assert.Equal(value, t.Get(key));
        }

        foreach (var (key, _) in _entries)
        {
            t.Delete(key);
            Assert.Null(t.Get(key));
        }
    }
}
