namespace StackWithArray;

internal class Program
{
    static void Main(string[] args)
    {
        ArrayedStack stack = new ArrayedStack(5);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);
        stack.Display();
        Console.WriteLine("-----------------------------------");
        int item;
        if (stack.Pop(out item))
        {
            Console.WriteLine("Popped item is {0}", item);
        }
        stack.Display();

        Console.ReadKey();
    }
}


public class ArrayedStack
{
    private int[] arr;
    private int top;
    private int size;

    public ArrayedStack(int size)
    {
        arr = new int[size];
        top = -1;
        this.size = size;
    }

    public bool IsFull()
    {
        if (top == size - 1)
        {
            return true;
        }
        return false;
    }

    public bool IsEmpty()
    {
        if (top == -1)
        {
            return true;
        }
        return false;
    }

    public void Push(int data)
    {
        if (IsFull())
        {
            Console.WriteLine("Stack is full");
            return;
        }

        top++;
        arr[top] = data;
    }

    public bool Pop(out int item)
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty");
            item = 0;
            return false;
        }
        item = arr[top];
        arr[top] = 0;
        top--;
        return true;

    }


    public int Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty");
            return -1;
        }

        return arr[top];
    }

    public int Count()
    {
        return top + 1;
    }

    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty");
            return;
        }

        for (int i = top; i >= 0; i--)
        {
            Console.WriteLine(arr[i]);
        }

    }


}
