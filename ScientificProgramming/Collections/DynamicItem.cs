using System;

namespace ScientificProgramming.Collections
{
    public class DynamicItem<T>
    {
        public T Value { private set; get; }

        public DynamicItem<T> Previous { set; get; }

        public DynamicItem<T> Next { set; get; }

        public DynamicItem(T itemValue, DynamicItem<T> prev, DynamicItem<T> next)
        {
            Value = itemValue;
            Previous = prev;
            Next = next;
        }
    }
}
