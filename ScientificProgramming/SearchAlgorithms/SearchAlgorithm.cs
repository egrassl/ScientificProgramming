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

    public class SearchAlgorithm
    {
        public ISearchState DesiredState { get; private set; }

        public ISearchState InitialState { get; private set; }

        public ISearchState CurrentState { get; private set; }

        public SearchCollection<ISearchState> SearchCollection { get; private set; }

        public SList<ISearchState> SearchedStates { get; private set; }

        public SearchAlgorithm(ISearchState initialState, ISearchState desiredState, SearchType searchType)
        {
            InitialState = CurrentState = initialState;
            DesiredState = desiredState;
            SearchCollection = new SearchCollection<ISearchState>(searchType);
            SearchedStates = new SList<ISearchState>();
        }

        public bool Resolve()
        {
            SearchCollection.Add(CurrentState);

            while (!Equals(CurrentState, DesiredState) && !SearchCollection.IsEmpty)
            {
                CurrentState = SearchCollection.NextItem();
                var nextStates = CurrentState.NextStates();
                SearchedStates.Add(CurrentState);

                for (int i = 0; i < nextStates.Quantity; i++)
                {
                    var nextState = nextStates[i];
                    if (!SearchedStates.Exists(nextState) && !SearchCollection.Exists(nextState))
                        SearchCollection.Add(nextState);
                }
            }

            return Equals(CurrentState, DesiredState);
        }
    }
}
