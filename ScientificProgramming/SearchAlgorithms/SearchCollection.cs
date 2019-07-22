using ScientificProgramming.Collections;
using System;
using ScientificProgramming.SearchAlgorithms.Abstract;

namespace ScientificProgramming.SearchAlgorithms
{
    /// <summary>
    /// Represents a collection that reacts according to the given search type
    /// </summary>
    public class SearchCollection
    {
        /// <summary>
        /// Represents internals search logic of this collection
        /// </summary>
        public SearchType SearchType { get; private set; }

        /// <summary>
        /// Internal Qeue for breadth search type
        /// </summary>
        private Queue<ISearchState> Queue { get; set; }

        /// <summary>
        /// Internal Stack for depth search type
        /// </summary>
        private Stack<ISearchState> Stack { get; set; }

        /// <summary>
        /// Internal List for A* and HillClimbing searches
        /// </summary>
        private SList<ISearchState> List { get; set; }

        /// <summary>
        /// Returns true if collection is empty
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (SearchType == SearchType.BFS)
                    return Queue.Quantity == 0;
                else if (SearchType == SearchType.DFS)
                    return Stack.Quantity == 0;
                else
                    return List.Quantity == 0;
            }
        }


        /// <summary>
        /// Initializes the collection for a given type of search algorithm
        /// </summary>
        /// <param name="searchType"></param>
        public SearchCollection(SearchType searchType) : base()
        {
            SearchType = searchType;
            Queue = new Queue<ISearchState>();
            Stack = new Stack<ISearchState>();
            List = new SList<ISearchState>();
        }

        /// <summary>
        /// Adds item according to search type logic
        /// </summary>
        /// <param name="item"></param>
        public void Add(ISearchState item)
        {
            if (SearchType == SearchType.BFS)
            {
                Queue.Enqueue(item);
            }
            else if (SearchType == SearchType.DFS)
            {
                Stack.Push(item);
            }
            else if (SearchType == SearchType.AStar)
            {
                List.Add(item);
            }
            else
            {
                if (List.Quantity == 0)
                {
                    List.Add(item);
                }
                else if(item.Evaluation < List[0].Evaluation)
                {
                    List.Remove(0);
                    List.Add(item);
                }
            }
        }

        /// <summary>
        /// Returns the next item to be searched given the specified search type logic
        /// </summary>
        /// <returns></returns>
        public ISearchState NextItem()
        {
            if (SearchType == SearchType.BFS)
            {
                return Queue.Dequeue();
            }
            else if (SearchType == SearchType.DFS)
            {
                return Stack.Pop();
            }
            else
            {
                var minEvaluation = int.MaxValue;
                int nextStateIndex = -1;

                for (int i = 0; i < List.Quantity; i++)
                {
                    if (List[i].Evaluation < minEvaluation)
                    {
                        minEvaluation = List[i].Evaluation;
                        nextStateIndex = i;
                    }
                }
                return List.Remove(nextStateIndex);
            }
        }

        /// <summary>
        /// Returns true if this item exists in the collection.
        /// </summary>
        /// <param name="item">Item to be verified.</param>
        /// <returns>True if item exists and false if not</returns>
        public bool Exists(ISearchState item)
        {
            if (SearchType == SearchType.BFS)
            {
                return Queue.Exists(item);
            }
            else if (SearchType == SearchType.DFS)
            {
                return Stack.Exists(item);
            }
            else
            {
                return List.Exists(item);
            }
        }
    }
}
