namespace Library.DataStructures.Stack;

public class Stack
{
    private Node? _head;

    public int? Peek()
    {
        if (_head == null)
        {
            return null;
        }

        return _head.Key;
    }

    public int? Pop()
    {
        if (_head == null)
        {
            return null;
        }

        int returnValue = _head.Key;
        _head = _head.Next;

        return returnValue;
    }

    public void Push(int key)
    {
        Node node = new(key);

        if (_head == null)
        {
            _head = node;
            return;
        }

        node.Next = _head;
        _head = node;
    }
}
