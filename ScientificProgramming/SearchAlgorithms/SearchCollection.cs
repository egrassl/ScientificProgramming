using ScientificProgramming.Collections;

namespace ScientificProgramming.SearchAlgorithms
{
    /// <summary>
    /// Represents a collection that reacts according to the given search type
    /// </summary>
    /// <typeparam name="T">Type of collection</typeparam>
    public class SearchCollection<T>
    {
        /// <summary>
        /// Represents internals search logic of this collection
        /// </summary>
        public SearchType SearchType { get; private set; }

        /// <summary>
        /// Internal Qeue for breadth search type
        /// </summary>
        private Queue<T> Queue { get; set; }

        /// <summary>
        /// Internal Stack for depth search type
        /// </summary>
        private Stack<T> Stack { get; set; }

        /// <summary>
        /// Returns true if collection is empty
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (SearchType == SearchType.BFS)
                    return Queue.Quantity == 0;
                else
                    return Stack.Quantity == 0;
            }
        }


        /// <summary>
        /// Initializes the collection for a given type of search algorithm
        /// </summary>
        /// <param name="searchType"></param>
        public SearchCollection(SearchType searchType) : base()
        {
            SearchType = searchType;
            Queue = new Queue<T>();
            Stack = new Stack<T>();
        }

        /// <summary>
        /// Adds item according to search type logic
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (SearchType == SearchType.BFS)
            {
                Queue.Enqueue(item);
            }
            else
            {
                Stack.Push(item);
            }
        }

        /// <summary>
        /// Returns the next item to be searched given the specified search type logic
        /// </summary>
        /// <returns></returns>
        public T NextItem()
        {
            if (SearchType == SearchType.BFS)
            {
                return Queue.Dequeue();
            }
            else
            {
                return Stack.Pop();
            }
        }

        /// <summary>
        /// Returns true if this item exists in the collection.
        /// </summary>
        /// <param name="item">Item to be verified.</param>
        /// <returns>True if item exists and false if not</returns>
        public bool Exists(T item)
        {
            if (SearchType == SearchType.BFS)
            {
                return Queue.Exists(item);
            }
            else
            {
                return Stack.Exists(item);
            }
        }
    }
}
