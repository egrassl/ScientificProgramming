using System;
using System.Text;
using ScientificProgramming.Collections;
using ScientificProgramming.SearchAlgorithms.Abstract;

namespace ScientificProgramming.SearchAlgorithms
{
    public enum SearchType
    {
        BFS,
        DFS,
        HillClimb,
        AStar
    }

    public class SearchCollection<T>
    {
        public SearchType SearchType { get; private set; }

        private Queue<T> Queue { get; set; }

        private Stack<T> Stack { get; set; }

        public SearchCollection(SearchType searchType) : base()
        {
            SearchType = searchType;

            if (searchType == SearchType.BFS)
                Queue = new Queue<T>();
            else
                Queue = new Queue<T>();
        }

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
    }

    public class SearchAlgorithm
    {
        public ISearchState DesiredState { get; private set; }

        public ISearchState InitialState { get; private set; }

        public ISearchState CurrentState { get; private set; }

        public SearchCollection<ISearchState> SearchCollection { get; private set; }

        public SearchAlgorithm(ISearchState initialState, SearchType searchType)
        {
            SearchCollection = new SearchCollection<ISearchState>(searchType);
            InitialState = CurrentState = initialState;
        }

        public bool Iterate()
        {
            if (Equals(CurrentState, DesiredState))
                return true;

            var nextStates = CurrentState.NextStates();


        }
    }
}
