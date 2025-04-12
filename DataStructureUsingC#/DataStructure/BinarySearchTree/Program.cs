namespace BinarySearchTree;

internal class Program
{
    static void Main(string[] args)
    {
        Tree tree = new Tree();
        tree.Add(5);
        tree.Add(3);
        tree.Add(2);
        tree.Add(4);
        tree.Add(7);
        tree.Add(6);
        tree.Add(8);

        tree.Remove(3);
        tree.Traverse();

        Console.ReadKey();
    }
}

public class Node
{
    public int Data { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public Node(int data)
    {
        Data = data;
        Left = Right = null;

    }
}


public class Tree
{

    private Node? root;
    public Tree()
    {
        root = null;
    }

    public void Add(int data)
    {
        Node node = new Node(data);
        if (root == null)
        {
            root = node;

        }
        else
        {

            Node? current = root;
            Node? parent = null;

            while (current != null)
            {
                parent = current;

                if (data > current.Data)
                {
                    current = current.Right;

                }
                else
                {
                    current = current.Left;
                }
            }

            if (data > parent.Data)
            {
                parent.Right = node;
            }
            else
            {
                parent.Left = node;
            }


        }
    }

    public Node? GetNodeByData(int data)
    {
        Node? current = root;

        while (current != null)
        {
            if (data == current.Data)
            {
                return current;
            }

            if (data > current.Data)
            {
                current = current.Right;
            }
            else
            {
                current = current.Left;
            }

        }
        return null;
    }

    public Node? GetParent(Node node)
    {
        Node? current = root;
        Node? parent = null;

        while (current != null)
        {
            if (current == node)
            {
                return parent;
            }
            else
            {
                parent = current;
                if (node.Data > current.Data)
                {
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }
        }

        return null;
    }

    public Node? GetMaxRight(Node node)
    {
        while (node.Right != null)
        {
            node = node.Right;
        }

        return node;
    }

    public void Traverse()
    {
        Display(root);
    }

    private void Display(Node? node) // using LDR ( Left,Data ,Right)
    {
        if (node == null)
        {
            return;
        }
        else
        {
            Display(node.Left);
            Console.WriteLine(node.Data);
            Display(node.Right);
        }
    }

    public void Remove(int data)
    {
        // there are 2 main cases => 1- if the node is the root 2- if the node is not the root
        // first case : if the node is the root => there are 4 cases=>
        //1-  if the root has no children => root = null
        //2- if the root has one left child 
        //3- if the root has one right child
        //4- if the root has two children

        Node? node = GetNodeByData(data);
        if (node is null) return;

        if (node == root)
        {
            if (node.Left is null && node.Right is null)
            {
                root = null;
            }
            else if (node.Right is null)
            {
                root = root.Left;
            }
            else if (node.Left is null)
            {
                root = root.Right;
            }
            else
            {
                Node? newNode = root.Left;
                Node? maxRight = GetMaxRight(newNode);
                maxRight.Right = root.Right;
                root = newNode;
            }
        }

        else  // if the node is not the root
        {
            Node? parent = GetParent(node);
            if (node.Left is null && node.Right is null)
            {
                if (parent.Left == node)
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }
            else if (node.Right is null)
            {
                if (parent.Left == node)
                {
                    parent.Left = node.Left;
                }
                else
                {
                    parent.Right = node.Left;
                }
            }

            else if (node.Left is null)
            {
                if (parent.Left == node)
                {
                    parent.Left = node.Right;
                }
                else
                {
                    parent.Right = node.Right;
                }
            }
            else
            {
                Node? newNode = node.Left;
                Node? maxRight = GetMaxRight(newNode);

                maxRight.Right = node.Right;

                if (parent.Left == node)
                {
                    parent.Left = newNode;
                }
                else
                {
                    parent.Right = newNode;
                }
            }
        }

    }
}
