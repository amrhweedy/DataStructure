using LinkedList;

namespace LinkedListStack;

internal class Program
{
    static void Main(string[] args)
    {
        LinkedListStack list = new LinkedListStack();
        list.Push(1);
        list.Push(2);
        list.Push(3);
        list.Display();

        Console.WriteLine("-----------------------------------");
        list.Pop(out int item);
        Console.WriteLine("Popped item: " + item);
        list.Display();
        Console.ReadKey();

    }
}

public class LinkedListStack
{
    public Node? Top;
    public LinkedListStack()
    {
        Top = null;
    }

    public void Push(int data)
    {
        Node newNode = new Node(data);
        newNode.Previous = Top; // in the first the top is null
        Top = newNode;
    }

    public bool Pop(out int item)
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty");
            item = 0;
            return false;
        }
        item = Top.Data;
        Top = Top.Previous;
        return true;

    }

    public bool IsEmpty()
    {
        return Top == null;
    }

    // Display the stack contents (from top to bottom)
    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty");
            return;
        }

        Console.Write("Stack (top to bottom): ");
        Node? current = Top;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Previous;
        }
        Console.WriteLine("null");
    }


}
