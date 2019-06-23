using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ScientificProgramming.Collections.Abstract;

namespace ScientificProgramming.Collections
{
    public class DynamicCollection<T> : ISCollection<T>
    {
        /// <summary>
        /// First item in the Collection
        /// </summary>
        private DynamicItem<T> FirstItem { set; get; }

        /// <summary>
        /// Last item in the Collection
        /// </summary>
        private DynamicItem<T> LastItem { set; get; }

        /// <summary>
        /// Index of the last item
        /// </summary>
        public int IndexOfLast
        {
            get { return Quantity - 1; }
        }


        /// <summary>
        /// First item value in the Collection
        /// </summary>
        public T FirstValue
        {
            get
            {
                // Cannot return a value if collection is empty
                if (IsEmpty)
                    throw new NullReferenceException("Cannot retrieve a value when the collection is Empty");

                return FirstItem.Value;
            }
        }


        /// <summary>
        /// Last item value in the Collection
        /// </summary>
        public T LastValue
        {
            get
            {
                // Cannot return a value if collection is empty
                if (IsEmpty)
                    throw new NullReferenceException("Cannot retrieve a value when the collection is Empty");

                return LastItem.Value;
            }
        }

        /// <summary>
        /// Indicates if there is no items in the Collection
        /// </summary>
        public bool IsEmpty {
            get
            {
                return Quantity == 0;
            }
        }

        /// <summary>
        /// Quantity of items in the collection
        /// </summary>
        public int Quantity
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes an empty collection
        /// </summary>
        public DynamicCollection()
        {
            FirstItem = null;
            Quantity = 0;
        }

        /// <summary>
        /// Initializes a collection with an initial content
        /// </summary>
        /// <param name="inputItems">Initial content</param>
        public DynamicCollection(T[] inputItems)
        {
            Quantity = 0;

            // Adds all array Itens to the Collection
            for (var i = 0; i < inputItems.Length; i++)
                Add(inputItems[i]);
        }

        protected void Add(T value)
        {
            // Adds it to the first item variable if its the first item
            if (IsEmpty)
            {
                FirstItem = new DynamicItem<T>(value, null, null);
                LastItem = FirstItem;
            }
            // Appends new item to the collection
            else
            {
                var newItem = new DynamicItem<T>(value, LastItem, null);
                LastItem.Next = newItem;
                LastItem = newItem;
            }
            Quantity++;
        }

        protected void Insert(T value, int position)
        {
            // Change the firstItem if it is the first position
            if (position == 0)
            {
                var newItem = new DynamicItem<T>(value, null, FirstItem);

                // Updates the first item previous link if needed
                if (FirstItem != null)
                    FirstItem.Previous = newItem;

                FirstItem = newItem;
            }
            // Addts to the last item if it is the last position 
            else if (position == Quantity - 1)
            {
                var newItem = new DynamicItem<T>(value, LastItem, null);
                LastItem = newItem;
            }
            // Default behaviour for other cases
            else
            {
                var next = GetItem(position);
                var prev = next.Previous;

                // Update Links
                var newItem = new DynamicItem<T>(value, prev, next);
                prev.Next = newItem;
                next.Previous = newItem;
            }
            Quantity++;
        }

        protected T Remove(int position)
        {
            CheckIndex(position);

            var removedItem = GetItem(position);
            var prev = removedItem.Previous;
            var next = removedItem.Next;

            // Change the firstItem if it is the first position
            if (position == 0)
            {
                FirstItem = next;
                // Case it was the last item
                if (FirstItem != null)
                    FirstItem.Previous = null;
            }
            // Change the last item if it is the last position 
            else if (position == Quantity - 1)
            {
                LastItem = prev;
                LastItem.Next = null;
            }
            // Default behaviour for other cases
            else
            {
                prev.Next = next;
                next.Previous = prev;
            }

            // Clean references for the garbage Collector
            removedItem.Next = removedItem.Previous = null;
            Quantity--;

            return removedItem.Value;
        }

        /// <summary>
        /// Throws an Exception if a given index is out of the accepted range
        /// </summary>
        /// <param name="index">Index to be evaluated</param>
        private void CheckIndex(int index)
        {
            // Index is invalid if array is empty
            if (IsEmpty)
                throw new NullReferenceException("Cannot retrieve a value when the collection is Empty");

            // Index is invalid is it's out of the Collection boundaries
            if (index >= Quantity || index < 0)
                throw new IndexOutOfRangeException("The index called was not in the collection range");
        }

        public DynamicItem<T> GetItem(int index)
        {
            // Throws Exception if collection is empty or index is out of range
            CheckIndex(index);

            // Iterates through all collection until the given index
            var currentItem = FirstItem;
            for (var i = 0; i < Quantity; i++)
            {
                if (i != 0)
                    currentItem = currentItem.Next;

                // Stops in the given index
                if (i == index)
                    break;
            }

            return currentItem;
        }

        public T this[int index]
        {
            get
            {
                return GetItem(index).Value;
            }
        }

        public T[] GetItems()
        {
            // Returns empty array if Collection is empty
            if (IsEmpty)
                return new T[0];

            // Creates content array
            var returnArray = new T[Quantity];

            // Iterates through all items in the linked Collection
            var item = FirstItem;
            returnArray[0] = FirstItem.Value;

            for (var i = 1; i < Quantity; i++)
            {
                item = item.Next;
                returnArray[i] = item.Value;
            }

            return returnArray;
        }
    }
}
