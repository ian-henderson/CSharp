namespace Library.DataStructures.Queue;

public class Queue
{
    private Node? _head;
    private Node? _tail;

    public void Add(int key)
    {
        Node node = new(key);

        if (_head == null)
        {
            _head = _tail = node;
            return;
        }

        node.Previous = _tail;
        _tail.Next = node;
        _tail = node;
    }

    public int? Peek()
    {
        if (_head == null)
        {
            return null;
        }

        return _head.Key;
    }

    public int? Remove()
    {
        if (_head == null)
        {
            return null;
        }

        int key = _head.Key;
        _head = _head.Next;

        if (_head == null)
        {
            _tail = null;
        }

        return key;
    }
}
