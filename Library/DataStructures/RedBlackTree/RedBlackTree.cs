namespace Library.DataStructures.RedBlackTree;

public class RedBlackTree
{
    private Node? _root;

    public void Delete(int key)
    {
        Node? node = SearchNode(key);

        if (node == null)
        {
            return;
        }

        DeleteNode(node);
    }

    private void DeleteNode(Node v)
    {
        Node? parent = v.Parent;
        Node? u = ReplaceNode(v);
        bool uvBlack = (u == null || u.Color == Color.Black) && v.Color == Color.Black;

        if (u == null)
        {
            if (v == _root)
            {
                _root = null;
            }
            else
            {
                if (uvBlack)
                {
                    // u and v are both black. v is a leaf, fix double black at v
                    FixDoubleBlack(v);
                }
                else
                {
                    // u or v is red
                    Node? vSibling = GetSibling(v);

                    if (vSibling != null)
                    {
                        vSibling.Color = Color.Red;
                    }
                }

                // delete v
                if (NodeIsParentLeft(v))
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }

            return;
        }

        if (v.Left == null || v.Right == null)
        {
            // v has one child
            if (v == _root)
            {
                // v is root, assign value of u to v, then delete u
                v.Key = u.Key;
                v.Left = v.Right = null;
            }
            else
            {
                // Detach v from tree and move u up
                if (NodeIsParentLeft(v))
                {
                    parent.Left = u;
                }
                else
                {
                    parent.Right = u;
                }

                u.Parent = parent;

                if (uvBlack)
                {
                    // u and v are both black, fix double black at u
                    FixDoubleBlack(u);
                }
                else
                {
                    u.Color = Color.Black;
                }
            }

            return;
        }

        // v has two children, swap values with successor and recurse
        SwapNodeValues(u, v);

        DeleteNode(u);
    }

    private void FixDoubleBlack(Node node)
    {
        if (node == _root)
        {
            return;
        }

        Node? parent = node.Parent;
        Node? sibling = GetSibling(node);

        if (sibling == null) // No sibling, double black pushed up
        {
            FixDoubleBlack(parent);
        }
        else
        {
            if (sibling.Color == Color.Red)
            {
                parent.Color = Color.Red;
                sibling.Color = Color.Black;

                if (NodeIsParentLeft(sibling))
                {
                    RotateRight(parent);
                }
                else
                {
                    RotateLeft(parent);
                }

                FixDoubleBlack(parent);
            }
            else // Sibling is black
            {
                if (NodeHasRedChild(sibling))
                {
                    // At least 1 red child
                    if (sibling.Left != null && sibling.Left.Color == Color.Red)
                    {
                        if (NodeIsParentLeft(sibling)) // left left
                        {
                            sibling.Left.Color = sibling.Color;
                            sibling.Color = parent.Color;
                            RotateRight(parent);
                        }
                        else // right left
                        {
                            sibling.Left.Color = parent.Color;
                            RotateRight(sibling);
                            RotateLeft(parent);
                        }
                    }
                    else
                    {
                        if (NodeIsParentLeft(sibling)) // left right
                        {
                            sibling.Right.Color = parent.Color;
                            RotateLeft(sibling);
                            RotateRight(parent);
                        }
                        else // right right
                        {
                            sibling.Right.Color = sibling.Color;
                            sibling.Color = parent.Color;
                            RotateLeft(parent);
                        }
                    }

                    parent.Color = Color.Black;
                }
                else // Two black children
                {
                    sibling.Color = Color.Red;

                    if (parent.Color == Color.Black)
                    {
                        FixDoubleBlack(parent);
                    }
                    else
                    {
                        parent.Color = Color.Black;
                    }
                }
            }
        }
    }

    public void FixInsert(Node node)
    {
        while (node != _root && node.Parent.Color == Color.Red)
        {
            if (node.Parent == node.Parent.Parent.Left)
            {
                Node uncle = node.Parent.Parent.Right;

                if (uncle != null && uncle.Color == Color.Red)
                {
                    node.Parent.Color = Color.Black;
                    uncle.Color = Color.Black;
                    node.Parent.Parent.Color = Color.Red;
                    node = node.Parent.Parent;
                }
                else
                {
                    if (node == node.Parent.Right)
                    {
                        node = node.Parent;
                        RotateLeft(node);
                    }

                    node.Parent.Color = Color.Black;
                    node.Parent.Parent.Color = Color.Red;
                    RotateRight(node.Parent.Parent);
                }
            }
            else
            {
                Node uncle = node.Parent.Parent.Left;

                if (uncle != null && uncle.Color == Color.Red)
                {
                    node.Parent.Color = Color.Black;
                    uncle.Color = Color.Black;
                    node.Parent.Parent.Color = Color.Red;
                    node = node.Parent.Parent;
                }
                else
                {
                    if (node == node.Parent.Left)
                    {
                        node = node.Parent;
                        RotateRight(node);
                    }

                    node.Parent.Color = Color.Black;
                    node.Parent.Parent.Color = Color.Red;
                    RotateLeft(node.Parent.Parent);
                }
            }
        }

        _root.Color = Color.Black;
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

    static private Node? GetSibling(Node node)
    {
        if (node.Parent == null)
        {
            return null;
        }

        if (node.Parent.Left == node)
        {
            return node.Parent.Right;
        }

        return node.Parent.Left;
    }

    static private Node? GetSuccessor(Node node)
    {
        Node successor = node;

        while (successor.Left != null)
        {
            successor = successor.Left;
        }

        return successor;
    }

    public void Insert(int key)
    {
        Node? current = _root, parent = null;

        while (current != null)
        {
            parent = current;

            if (key == current.Key)
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

        if (node.Parent == null)
        {
            node.Color = Color.Black;
            return;
        }

        if (node.Parent.Parent == null)
        {
            return;
        }

        FixInsert(node);
    }

    static private bool NodeHasRedChild(Node node)
    {
        if ((node.Right != null && node.Right.Color == Color.Red)
            || (node.Left != null && node.Left.Color == Color.Red))
        {
            return true;
        }

        return false;
    }

    static private bool NodeIsParentLeft(Node node)
    {
        if (node.Parent == null)
        {
            return false;
        }

        if (node.Parent.Left != node)
        {
            return false;
        }

        return true;
    }

    private Node? ReplaceNode(Node node)
    {
        if (node.Left != null && node.Right != null) // node has two children
        {
            return GetSuccessor(node.Right);
        }

        if (node.Left == null && node.Right == null) // node is a leaf
        {
            return null;
        }

        if (node.Left != null) // node has a single child
        {
            return node.Left;
        }

        return node.Right;
    }

    private void RotateLeft(Node x)
    {
        Node? y = x.Right;

        x.Right = y.Left;

        if (y.Left != null)
        {
            y.Left.Parent = x;
        }

        y.Parent = x.Parent;

        if (x.Parent == null)
        {
            _root = y;
        }
        else if (x == x.Parent.Left)
        {
            x.Parent.Left = y;
        }
        else
        {
            x.Parent.Right = y;
        }

        y.Left = x;
        x.Parent = y;
    }

    private void RotateRight(Node x)
    {
        Node? y = x.Left;

        x.Left = y.Right;

        if (y.Right != null)
        {
            y.Right.Parent = x;
        }

        y.Parent = x.Parent;

        if (x.Parent == null)
        {
            _root = y;
        }
        else if (x == x.Parent.Right)
        {
            x.Parent.Right = y;
        }
        else
        {
            x.Parent.Left = y;
        }

        y.Right = x;
        x.Parent = y;
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

    static private void SwapNodeValues(Node u, Node v)
    {
        int temp = u.Key;
        u.Key = v.Key;
        v.Key = temp;
    }
}
