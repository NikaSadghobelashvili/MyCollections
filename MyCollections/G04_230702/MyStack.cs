namespace G04_230702;

public sealed class MyStack<T> : BaseCollection<T>
{
    public MyStack() : base() { }

    public MyStack(int capacity) : base(capacity) { }

    public void Push(T item) => base.AddItem(item);

    public T Pop()
    {
        T item = this[Count - 1];
        base.RemoveAt(Count - 1);
        return item;
    }

    public T Peek()
    {
        return this[Count - 1];
    }
}