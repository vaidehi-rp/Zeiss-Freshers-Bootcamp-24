using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArrayProblem
{
    public class DynamicArray<T>
    {
        private T[] _items;
        private uint _count;

        public DynamicArray(uint capacity)
        {
            _items = new T[(int)capacity];
            _count = 0;
        }

        public void Add(uint index, T item)
        {
            EnsureCapacity();
            InsertItem(index, item);
        }

        private void EnsureCapacity()
        {
            if (_count != _items.Length) return;

            T[] newItems = new T[_items.Length * 2];
            Array.Copy(_items, newItems, _items.Length);
            _items = newItems;
        }

        private void InsertItem(uint index, T item)
        {
            Array.Copy(_items, index, _items, index + 1, _count - index);
            _items[(int)index] = item;
            _count++;
        }


        public T this[uint index]
        {
            get
            {
                if (index >= _count)
                    throw new IndexOutOfRangeException();

                return _items[(int)index];
            }
        }

        public uint Count
        {
            get { return _count; }
        }
    }


}
