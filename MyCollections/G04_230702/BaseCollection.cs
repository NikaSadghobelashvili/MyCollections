using System.Collections;

namespace G04_230702;

public abstract class BaseCollection<T> : ICollection<T>
{
    protected T?[] _items;
    private static int _defaultCapacity = 4;

    protected BaseCollection() : this(_defaultCapacity) { }

    protected BaseCollection(int capacity)
    {
        _items = new T?[capacity];
    }

    public void Clear()
    {
        _items = new T[Capacity];
        Count = 0;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (this[i].Equals(item))
            {
                return true;
            }
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array.Length - arrayIndex < _items.Length || arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }

        for (int i = 0; i < array.Length - arrayIndex && i < Count; i++)
        {
            (array as IList)[arrayIndex + i] = this[i];
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyEnumerator<T>(_items, Count);
    }

    public int Count { get; protected set; }
    public bool IsReadOnly { get; }

    public int Capacity
    {
        get
        {
            return _items.Length;
        }
        set
        {
            if (value < 0 || value < Count)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            Resize(ref _items, value);
        }
    }

    protected T this[int index]
    {
        get
        {
            if (index < 0 || index >= _items.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _items.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            _items[index] = value;
        }
    }

    protected void AddItem(T item)
    {
        if (Count == _items.Length)
        {
            IncreaseCapacity();
        }
        Count++;
        this[Count - 1] = item;
    }

    protected void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        for (int i = index; i < Count - 1; i++)
        {
            (this[i], this[i + 1]) = (this[i + 1], this[i]);
        }
        this[Count - 1] = default;
        Count--;
    }

    private static void Resize(ref T?[] array, int size)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));
        if (array.Length == size) return;

        T?[] temp = new T[size];
        for (int i = 0; i < array.Length && i < temp.Length; i++)
        {
            temp[i] = array[i];
        }
        array = temp;
    }

    private void IncreaseCapacity()
    {
        if (Capacity > 0) Capacity *= 2;
        else if(Capacity == 0) Capacity = _defaultCapacity;
    }

    void ICollection<T>.Add(T item) => throw new NotImplementedException();

    bool ICollection<T>.Remove(T item) => throw new NotImplementedException();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}