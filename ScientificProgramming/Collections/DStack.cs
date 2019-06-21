using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificProgramming.Collections
{
    public class DStack<T> : DynamicCollection<T>
    {
        /// <summary>
        /// Insert an item to the Stack's top
        /// </summary>
        /// <param name="item">Item to be inserted</param>
        public void Push(T item)
        {
            Add(item);
        }

        /// <summary>
        /// Removes the top item in the Stack
        /// </summary>
        /// <returns>Item removed</returns>
        public T Pop()
        {
            return Remove(IndexOfLast);
        }
    }
}
