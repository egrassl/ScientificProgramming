using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificProgramming.Collections
{
    public class DQueue<T> : DynamicCollection<T>
    {
        /// <summary>
        /// Inserts the item in the Queue's first position
        /// </summary>
        /// <param name="item">Item to be inserted in the queue</param>
        public void Enqueue(T item)
        {
            Insert(item, 0);
        }

        /// <summary>
        /// Removes the next item in the queue
        /// </summary>
        /// <returns>Next item in the queue</returns>
        public T Dequeue()
        {
            return Remove(IndexOfLast);
        }
    }
}
