namespace Library.DataStructures.BinarySearchTree;

public record Node(int Key)
{
    public Node? Parent { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }
}
