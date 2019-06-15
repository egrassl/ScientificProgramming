using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificProgramming.Collections.Abstract
{
    public interface ISCollection<T>
    {
        /// <summary>
        /// Returns the given item index in the Collection
        /// </summary>
        /// <param name="item">Item to find in Collection</param>
        /// <returns>Item index in the Array</returns>
        int Find(T item);

        /// <summary>
        /// Checks if an item exists in the Collection
        /// </summary>
        /// <param name="item">Item to be checked</param>
        /// <returns>Returns true if the item exists in the Array and false otherwise</returns>
        bool Exists(T item);

        /// <summary>
        /// Adds an item to the Collection
        /// </summary>
        /// <param name="item">Item to be added in the Collection</param>
        void Add(T item);

        /// <summary>
        /// Insert an item in a given index of the Collection
        /// </summary>
        /// <param name="item">Item to be inserted</param>
        /// <param name="index">Position in which the new item will be inserted</param>
        void Insert(T item, int index);

        /// <summary>
        /// Remove an item in the given position and returns it
        /// </summary>
        /// <param name="index">Position of the item to be removed</param>
        /// <returns>Item removed</returns>
        T Remove(int index);

        /// <summary>
        /// Removes the fist ocurrence of the item specified and returns it
        /// </summary>
        /// <param name="item">Item to be removed</param>
        /// <returns></returns>
        T Remove(T item);

        /// <summary>
        /// Gets All Itens
        /// </summary>
        /// <returns></returns>
        T[] GetItems();

    }
}
