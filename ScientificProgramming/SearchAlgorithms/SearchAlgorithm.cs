using ScientificProgramming.Collections;
using ScientificProgramming.SearchAlgorithms.Abstract;

namespace ScientificProgramming.SearchAlgorithms
{
    /// <summary>
    /// Search type to be used in search algorithm.
    /// </summary>
    public enum SearchType
    {
        BFS,
        DFS,
        HillClimb,
        AStar
    }

    public class SearchAlgorithm
    {
        /// <summary>
        /// State where the search should considered successful if found.
        /// </summary>
        public ISearchState DesiredState { get; private set; }

        /// <summary>
        /// Initial State of the search.
        /// </summary>
        public ISearchState InitialState { get; private set; }

        /// <summary>
        /// Current search state.
        /// </summary>
        public ISearchState CurrentState { get; private set; }

        /// <summary>
        /// Collection with states that will be searched.
        /// </summary>
        public SearchCollection<ISearchState> SearchCollection { get; private set; }

        /// <summary>
        /// States that have been searched.
        /// </summary>
        public SList<ISearchState> SearchedStates { get; private set; }

        public SearchAlgorithm(ISearchState initialState, ISearchState desiredState, SearchType searchType)
        {
            // Intializes search structures given search type
            SearchCollection = new SearchCollection<ISearchState>(searchType);
            SearchedStates = new SList<ISearchState>();

            // Initialize search states definitions
            InitialState = initialState;
            DesiredState = desiredState;

            // The initial state is the first one to be searched
            SearchCollection.Add(InitialState);
        }

        /// <summary>
        /// Runs the search to find the desired state and returns if the search was successful or not.
        /// </summary>
        /// <returns>Returns true if the loop exited because the desired state was reached or false otherwise.</returns>
        public bool Resolve()
        {
            // Searches through states while the desired state has not been found and while there is new states to be searched
            while (!Equals(CurrentState, DesiredState) && !SearchCollection.IsEmpty)
            {

                // Sets state's search context
                CurrentState = SearchCollection.NextItem();
                var nextStates = CurrentState.NextStates();

                // Register visited states to avoid repeating it and entering in a loop
                SearchedStates.Add(CurrentState);

                // Register new states to be searched
                for (int i = 0; i < nextStates.Quantity; i++)
                {
                    var nextState = nextStates[i];

                    // Add a new state to search if it has not been searched yet
                    if (!SearchedStates.Exists(nextState) && !SearchCollection.Exists(nextState))
                        SearchCollection.Add(nextState);
                }
            }

            // Returns true if the loop exited because the desired state was reached or false otherwise
            return Equals(CurrentState, DesiredState);
        }
    }
}
