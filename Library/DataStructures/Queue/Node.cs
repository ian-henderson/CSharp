namespace Library.DataStructures.Queue;

public record Node(int Key)
{
    public Node? Next { get; set; }
    public Node? Previous { get; set; }
}
