namespace Library.DataStructures.HashTable;

public class HashTable
{
    private readonly Node[] _buffer;
    private readonly int _bufferLength = 50;

    public HashTable()
    {
        _buffer = new Node[_bufferLength];
    }

    public void Delete(string key)
    {
        int index = Hash(key);
        Node? current = _buffer[index], previous = null;

        if (current == null)
        {
            return;
        }

        while (current != null)
        {
            if (key == current.Key)
            {
                if (current == _buffer[index]) // head of list
                {
                    _buffer[index] = _buffer[index].Next;
                }
                else // middle or end of list
                {
                    previous.Next = current.Next;
                }

                break;
            }

            previous = current;
            current = current.Next;
        }
    }

    public string? Get(string key)
    {
        Node? current = _buffer[Hash(key)];

        while (current != null)
        {
            if (current.Key == key)
            {
                return current.Value;
            }

            current = current.Next;
        }

        return null;
    }

    private int Hash(string key)
    {
        int factor = 31, hash = 0, max = short.MaxValue;

        for (int i = 0; i < key.Length; i++)
        {
            hash = ((hash % _bufferLength)
                    + key[i] * factor % _bufferLength)
                % _bufferLength;
            factor = factor % max * (31 % max) % max;
        }

        return hash;
    }

    public void Set(string key, string value)
    {
        if (Get(key) == value)
        {
            return;
        }

        Node node = new(key, value);

        int index = Hash(key);

        if (_buffer[index] == null)
        {
            _buffer[index] = node;
        }
        else
        {
            node.Next = _buffer[index];
            _buffer[index] = node;
        }
    }
}
