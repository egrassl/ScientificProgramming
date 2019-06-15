using System;
using ScientificProgramming.Collections.Abstract;

namespace ScientificProgramming.Collections
{

    /// <summary>
    /// Generic Collection Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SCollection<T> : ISCollection<T>
    {

        /// <summary>
        /// Collection Content
        /// </summary>
        private T[] items;
        
        /// <summary>
        /// Internal Array sizee
        /// </summary>
        private int size;
        

        /// <summary>
        /// Quantity of items in the collection
        /// </summary>
        public int Quantity
        {
            get;
            private set;
        }

        /// <summary>
        /// Index of Last Item. -1 if the collection is empty
        /// </summary>
        public int IndexOfLast
        {
            get { return Quantity - 1; }
        }

        /// <summary>
        /// Initializes an empty collection
        /// </summary>
        public SCollection()
        {
            items = new T[10];
            size = 10;
            Quantity = 0;
        }

        /// <summary>
        /// Initializes a collection with an initial content
        /// </summary>
        /// <param name="inputItems">Initial content</param>
        public SCollection(T[] inputItems)
        {
            items = inputItems;
            size = inputItems.Length;
            Quantity = size;
        }

        /// <summary>
        /// Checks if and index operation is in the valid range and Throws an exception if not
        /// </summary>
        /// <param name="index">Index to be checked</param>
        private void CheckIndexValidity(int index)
        {
            if (index > IndexOfLast)
                throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Expands the internal array in twice its current quantity
        /// </summary>
        private void ExpandArray()
        {
            // Creates new array
            var newSize = size * 2;
            var newArray = new T[newSize];

            // Copy new items to new array
            for (var i = 0; i < newSize; i++)
                newArray[i] = i < size ? items[i] : default(T);

            // Sets new Array
            items = newArray;
            size = newSize;
        }

        /// <summary>
        /// Adds an item to the Collection
        /// </summary>
        /// <param name="item">Item to be added in the Collection</param>
        protected void Add(T item)
        {
            // Expands internal array if there's no space left
            if (Quantity == size)
                ExpandArray();

            // Assigns new item
            items[IndexOfLast + 1] = item;
            Quantity++;
        }

        /// <summary>
        /// Insert an item in a given index of the Collection
        /// </summary>
        /// <param name="item">Item to be inserted</param>
        /// <param name="index">Position in which the new item will be inserted</param>
        protected void Insert(T item, int index)
        {
            /// Throws an execption if index is not valid
            CheckIndexValidity(index);
            if (Quantity == size)
                ExpandArray();

            // Reallocates all itens after the insert index
            Quantity++;
            for (var i = IndexOfLast; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            // Insert item
            items[index] = item;
        }

        /// <summary>
        /// Checks if an item exists in the Collection
        /// </summary>
        /// <param name="item">Item to be checked</param>
        /// <returns>Returns true if the item exists in the Array and false otherwise</returns>
        public bool Exists(T item)
        {
            for (var i = 0; i < Quantity; i++)
            {
                if (Equals(items[i], item))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the given item index in the Collection
        /// </summary>
        /// <param name="item">Item to find in Collection</param>
        /// <returns>Item index in the Array or -1 if not found</returns>
        public int Find(T item)
        {
            for (var i = 0; i < Quantity; i++)
            {
                if (Equals(items[i], item))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Remove an item in the given position and returns it
        /// </summary>
        /// <param name="index">Position of the item to be removed</param>
        /// <returns>Item removed</returns>
        protected T Remove(int index)
        {
            CheckIndexValidity(index);

            var removedItem = items[index];

            // Shift items to override the removed one
            for (int i = index; i < Quantity; i++)
            {
                items[i] = items[i + 1];
            }
            
            Quantity--;
            return removedItem;
        }

        /// <summary>
        /// Removes the fist ocurrence of the item specified and returns it
        /// </summary>
        /// <param name="item">Item to be removed</param>
        /// <returns></returns>
        protected T Remove(T item)
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
