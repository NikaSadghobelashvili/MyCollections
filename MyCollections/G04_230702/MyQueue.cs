namespace G04_230702;

public sealed class MyQueue<T> : BaseCollection<T>
{
    public MyQueue() : base() { }

    public MyQueue(int capacity) : base(capacity) { }

    public void Enqueue(T item) => base.AddItem(item);

    public T Dequeue()
    {
        T item = this[0];
        base.RemoveAt(0);
        return item;
    }

    public T Peek()
    {
        return this[0];
    }
}