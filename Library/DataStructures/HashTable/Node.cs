namespace Library.DataStructures.HashTable;

public record Node(string Key, string Value)
{
    public Node? Next { get; set; }
    public Node? Previous { get; set; }
}
