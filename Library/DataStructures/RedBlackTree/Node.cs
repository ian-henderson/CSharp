namespace Library.DataStructures.RedBlackTree;

public class Node(int key)
{
    public Node? Parent { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }
    public Color Color { get; set; } = Color.Red;
    public int Key { get; set; } = key;
}
