namespace Library.DataStructures.BinarySearchTree;

public class BinarySearchTree
{
    private Node? _root;

    public void Delete(int key)
    {
        Node? current = _root, parent;

        while (current != null && current.Key != key)
        {
            if (key < current.Key)
            {
                current = current.Left;
            }
            else
            {
                current = current.Right;
            }
        }

        if (current == null) // key not found
        {
            return;
        }

        if (current.Left == null)
        {
            Transplant(current, current.Right);
        }
        else if (current.Right == null)
        {
            Transplant(current, current.Left);
        }
        else
        {
            parent = GetNodeMinimum(current.Right);

            if (parent != current.Right)
            {
                Transplant(parent, parent.Right);
                parent.Right = current.Right;
                parent.Right.Parent = parent;
            }

            Transplant(current, parent);
            parent.Left = current.Left;
            parent.Left.Parent = parent;
        }
    }

    public int GetHeight()
    {
        return GetNodeHeight(_root);
    }

    static private int GetNodeHeight(Node? node)
    {
        if (node == null)
        {
            return -1;
        }

        int max = Math.Max(GetNodeHeight(node.Left), GetNodeHeight(node.Right));

        return max + 1;
    }

    static private Node GetNodeMaximum(Node node)
    {
        while (node.Right != null)
        {
            node = node.Right;
        }

        return node;
    }

    static private Node GetNodeMinimum(Node node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }

        return node;
    }

    static private Node? GetNodePredecessor(Node node)
    {
        if (node.Left != null)
        {
            return GetNodeMaximum(node.Left);
        }

        // Find the highest ancestor of node whose right child is an ancestor
        // of node
        Node current = node;
        Node? parent = node.Parent;

        while (parent != null && current == parent.Left)
        {
            current = parent;
            parent = parent.Parent;
        }

        return parent;
    }

    static private Node? GetNodeSuccessor(Node node)
    {
        if (node.Right != null)
        {
            return GetNodeMinimum(node.Right);
        }

        // Find the lowest ancestor of node whose left child is an ancestor 
        // of node
        Node current = node;
        Node? parent = node.Parent;

        while (parent != null && current == parent.Right)
        {
            current = parent;
            parent = parent.Parent;
        }

        return parent;
    }

    public int? GetPredecessor(int key)
    {
        Node? node = SearchNode(key);

        if (node == null)
        {
            return null;
        }

        Node? predecessor = GetNodePredecessor(node);

        if (predecessor == null)
        {
            return null;
        }

        return predecessor.Key;
    }

    public int? GetSuccessor(int key)
    {
        Node? node = SearchNode(key);

        if (node == null)
        {
            return null;
        }

        Node? successor = GetNodeSuccessor(node);

        if (successor == null)
        {
            return null;
        }

        return successor.Key;
    }

    public void Insert(int key)
    {
        Node? current = _root, parent = null;

        while (current != null)
        {
            parent = current;

            if (key == current.Key) // duplicate key
            {
                return;
            }

            if (key < current.Key)
            {
                current = current.Left;
            }
            else
            {
                current = current.Right;
            }
        }

        Node node = new(key)
        {
            Parent = parent
        };

        if (parent == null)
        {
            _root = node;
        }
        else if (node.Key < parent.Key)
        {
            parent.Left = node;
        }
        else
        {
            parent.Right = node;
        }
    }

    public int? Search(int key)
    {
        Node? result = SearchNode(key);

        if (result == null)
        {
            return null;
        }

        return result.Key;
    }

    private Node? SearchNode(int key)
    {
        Node? current = _root;

        while (current != null)
        {
            if (key == current.Key)
            {
                return current;
            }

            if (key < current.Key)
            {
                current = current.Left;
            }
            else
            {
                current = current.Right;
            }
        }

        return null;
    }

    private void Transplant(Node u, Node? v)
    {
        if (u.Parent == null)
        {
            _root = v;
        }
        else if (u == u.Parent.Left)
        {
            u.Parent.Left = v;
        }
        else
        {
            u.Parent.Right = v;
        }

        if (v != null)
        {
            v.Parent = u.Parent;
        }
    }
}
