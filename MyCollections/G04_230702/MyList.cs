namespace G04_230702;

public sealed class MyList<T> : BaseCollection<T>, IList<T>
{
    public MyList() : base() { }

    public MyList(int capacity):base(capacity) { }

    public void Add(T item) => AddItem(item);

    public bool Remove(T item)
    {
        int index = IndexOf(item);
        if (index == -1) return false;
        RemoveAt(index);
        return true;
    }

    public void Insert(int index, T item)
    {
        if (index >= Count || index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Add(item);
        for (int i = Count - 1; i > index; i--)
        {
            (this[i - 1], this[i]) = (this[i], this[i - 1]);
        }
    }

    public new void RemoveAt(int index) => base.RemoveAt(index);

    public int IndexOf(T item) => IndexOf(item, 0);

    public int IndexOf(T item,int startIndex)
    {
        if(startIndex >= Count || startIndex < 0)
        {
            throw new IndexOutOfRangeException();
        }

        for(int i = startIndex;i< Count; i++)
        {
            if (this[i].Equals(item)) return i;
        }
        return -1;
    }

    public T this[int index]
    {
        get => base[index];
        set => base[index] = value;
    }
}