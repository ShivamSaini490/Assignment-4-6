using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Stack<T>
{
    private T[] items;
    private int top;

    public Stack(int capacity)
    {
        items = new T[capacity];
        top = -1;
    }

    public int Count
    {
        get { return top + 1; }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index > top)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            return items[index];
        }
    }

    public void Push(T item)
    {
        if (top == items.Length - 1)
        {
            Array.Resize(ref items, items.Length * 2);
        }
        top++;
        items[top] = item;
    }

    public T Pop()
    {
        if (top == -1)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        T poppedItem = items[top];
        top--;
        return poppedItem;
    }

    public T Peek()
    {
        if (top == -1)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        return items[top];
    }
}

class Program
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>(3);

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine("Element at index 0: " + stack[0]);
        Console.WriteLine("Element at index 1: " + stack[1]);
        Console.WriteLine("Element at index 2: " + stack[2]);

        int poppedItem = stack.Pop();
        Console.WriteLine("Popped element: " + poppedItem);

        int topItem = stack.Peek();
        Console.WriteLine("Top element (peek): " + topItem);

        Console.ReadLine();
    }
}
