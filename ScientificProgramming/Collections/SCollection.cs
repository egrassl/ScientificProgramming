using System;
using System.Text;
using ScientificProgramming.Collections.Abstract;

namespace ScientificProgramming.Collections
{

    /// <summary>
    /// Generic Collection Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SCollection<T> : ISCollection<T>
    {
        private T[] items;

        private int size;
        
        public int Quantity
        {
            get;
            private set;
        }

        public int IndexOfLast
        {
            get { return Quantity - 1; }
        }

        public SCollection()
        {
            items = new T[0];
            size = 0;
        }

        public SCollection(T[] inputItems)
        {
            items = inputItems;
            size = inputItems.Length;
            Quantity = size;
        }

        private void CheckIndexValidity(int index)
        {
            if (index >= size)
                throw new ArgumentOutOfRangeException();
        }

        private void ExpandArray()
        {
            var newSize = size * 2;
            var newArray = new T[newSize];
            for (var i = 0; i < newSize; i++)
                newArray[i] = i < size ? items[i] : default(T);
            items = newArray;
            size = newSize;
        }

        public void Add(T item)
        {
            if (Quantity == size)
                ExpandArray();

            items[IndexOfLast + 1] = item;
            Quantity++;
        }

        public void Insert(T item, int index)
        {
            CheckIndexValidity(index);
            if (Quantity == size)
                ExpandArray();

            Quantity++;
            for (var i = IndexOfLast; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
        }

        public bool Exists(T item)
        {
            for (var i = 0; i < Quantity; i++)
            {
                if (Equals(items[i], item))
                    return true;
            }
            return false;
        }

        public int Find(T item)
        {
            for (var i = 0; i < Quantity; i++)
            {
                if (Equals(items[i], item))
                    return i;
            }
            return -1;
        }

        public T Remove(int index)
        {
            CheckIndexValidity(index);

            var removedItem = items[index];
            for (int i = index; i < Quantity; i++)
            {
                items[i] = items[i + 1];
            }
            Quantity--;
            return removedItem;
        }

        public T Remove(T item)
        {
            var index = Find(item);
            return Remove(index);
        }

        public T[] GetItems()
        {
            var returnArray = new T[Quantity];
            for (var i = 0; i < Quantity; i++)
                returnArray[i] = items[i];

            return returnArray;
        }
    }
}
