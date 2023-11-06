using System.Collections;
using System.Collections.Generic;

namespace G04_230702
{
    public class MyEnumerator<T> : IEnumerator<T>
    {
        private T[] _items;
        private int _index;
        private int _size;

        public MyEnumerator(T[] items)
        {
            _size = items.Length;
            _items = items;
            _index = -1;
        }

        public MyEnumerator(T[] items, int size)
        {
            _size = size;
            _items = items;
            _index = -1;
        }

        public bool MoveNext()
        {
            return _size > ++_index;
        }

        public T Current => _items[_index];

        public void Reset()
        {
            _index = -1;
        }

        public void Dispose()
        {
            Reset();
        }

        object IEnumerator.Current => Current;
    }
}