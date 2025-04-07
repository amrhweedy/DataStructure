namespace ArrayedQueue;

internal class Program
{
    static void Main(string[] args)
    {

        ArrayQueue<int> arrayQueue = new ArrayQueue<int>(5);
        arrayQueue.Enqueue(1);
        arrayQueue.Enqueue(2);
        arrayQueue.Enqueue(3);
        arrayQueue.Enqueue(4);
        arrayQueue.Enqueue(5);

        arrayQueue.Display();

        Console.WriteLine("-----------------Deque------------------");

        int item = 0;
        bool result = arrayQueue.Dequeue(ref item);
        if (result)
        {
            Console.WriteLine("Deleted item is {0}", item);
            arrayQueue.Display();
        }


        Console.ReadKey();

    }
}


public class ArrayQueue<T>
{
    T[] items;
    int front;
    int rear;
    int count;  // Number of elements in the queue to see if the queue is empty or full
    int size;   // Max Size of the queue
    public ArrayQueue(int size)
    {
        this.size = size;
        items = new T[size];
        front = 0;
        rear = -1;
        count = 0;
    }


    public bool IsEmpty()
    {
        return count == 0;
    }

    public bool IsFull()
    {
        return count == size;
    }


    public void Enqueue(T item)
    {
        if (IsFull())
        {
            Console.WriteLine("Queue is full");
            return;
        }

        rear = (rear + 1) % size; // circular queue , increase the index of the rear by 1 ex if the rear is -1 then real= (-1+1)%5 = 0
        items[rear] = item;
        count++;
    }

    public bool Dequeue(ref T item)
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue is empty");
            return false;
        }

        item = items[front];
        items[front] = default(T)!;
        front = (front + 1) % size;
        count--;
        return true;
    }


    public int Count()
    {
        return count;
    }


    public T GetFront()
    {
        return items[front];
    }


    public T GetRear()
    {
        return items[rear];
    }


    public void Display() // print the queue from the front to the rear but not include the rear so we will print the rear only
    {
        if (IsEmpty())
        {
            Console.WriteLine("Queue is empty");
            return;
        }

        for (int i = front; i != rear; i = (i + 1) % size)
        {
            Console.WriteLine(items[i]);
        }

        Console.WriteLine(items[rear]);

    }

}
