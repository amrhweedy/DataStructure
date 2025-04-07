namespace LinkedList;

internal class Program
{
    static void Main(string[] args)
    {
        LinkedList list = new LinkedList();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        list.Display();

        Console.WriteLine("-----------------------------------");

        list.Remove(2);


        list.Display();

        Console.WriteLine("----------------------------------- search -----------------------------------");

        Console.WriteLine(list.Search(3));

        Console.ReadLine();
    }
}

public class Node(int data)
{
    public int Data { get; set; } = data;
    public Node? Next { get; set; }
    public Node? Previous { get; set; }
}


public class LinkedList
{
    public Node? Head { get; set; }
    public Node? Tail { get; set; }

    public void Add(int data)
    {
        Node newNode = new Node(data);
        if (Head is null)
        {
            Head = Tail = newNode;
            return;
        }

        Tail.Next = newNode;
        newNode.Previous = Tail;
        Tail = newNode;

    }

    public Node? GetNodeByData(int data)
    {
        Node? current = Head;

        while (current is not null)
        {
            if (current.Data == data)
            {
                return current;
            }
            current = current.Next;
        }

        return null;
    }


    public void Remove(int data)
    {
        Node? node = GetNodeByData(data);
        if (node is null)
            return;

        if (node == Head)
        {
            if (node == Tail)
            {
                Head = Tail = null;

            }
            else
            {
                Head = Head.Next;
                Head.Previous = null;
            }
        }
        else if (node == Tail)
        {
            Tail = Tail.Previous;
            Tail.Next = null;
        }
        else
        {
            node.Previous!.Next = node.Next;
            node.Next!.Previous = node.Previous;
        }
    }

    public void Display()
    {
        Node? current = Head;
        while (current is not null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }

    public bool Search(int data)
    {
        Node? node = GetNodeByData(data);

        return node is not null;

    }
}