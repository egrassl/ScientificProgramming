using System;
using System.Collections.Generic;
using System.Text;
using ScientificProgramming.Collections;
using ScientificProgramming.SearchAlgorithms;

namespace ScientificProgramming.Collections
{
    public class SList<T> : SCollection<T>
    {
        public SList(T[] itens) : base(itens)
        {
        }

        public SList(): base()
        {
        }

        public void Add(T item)
        {
            base.Add(item);
        }

        public T Remove(int index)
        {
            return base.Remove(index);
        }

        public void Insert(T item, int index)
        {
            base.Insert(item, index);
        }
    }
}
