using System;
using System.Text;
using ScientificProgramming.SearchAlgorithms.Abstract;
using ScientificProgramming.Collections;

namespace ScientificProgramming.SearchAlgorithms
{


    public class PiecesProblem
    {
        public PiecesState InitialState { get; private set; }

        public PiecesState FinalState { get; private set; }

        private PiecesState CurrentState { get; set; }

        public SearchType SearchType { get; private set; }

        public SCollection<PiecesState> StatesToSearch { get; private set; }

        public SCollection<PiecesState> StatesSearched { get; private set; }

        public PiecesProblem(int [][] initialState, SearchType SearchType = SearchType.BFS)
        {
            var finalState = new int[3][];

            finalState[0] = new int[] { 1, 2, 3 };
            finalState[1] = new int[] { 4, 5, 6 };
            finalState[2] = new int[] { 7, 8, -1 };

            FinalState = new PiecesState(finalState);
            InitialState = CurrentState = new PiecesState(initialState);
        }

        public PiecesState NextState()
        {
            PiecesState nextState;
            var nextStates = CurrentState.NextStates();

            AddStates(nextStates);


        }

        private void AddStates(SCollection<PiecesState> statesToAdd)
        {
            if (SearchType == SearchType.BFS)
            {
                var queue = StatesToSearch as Queue<PiecesState>;
                for (int i = 0; i < statesToAdd.Quantity; i++)
                    queue.Enqueue(statesToAdd[i]);
                
            }
            else if (SearchType == SearchType.DFS)
            {
                var stack = StatesToSearch as Stack<PiecesState>;
                for (int i = 0; i < statesToAdd.Quantity; i++)
                    stack.Push(statesToAdd[i]);
            }
        }

        public void Execute()
        {
            Console.WriteLine();
        }
    }
}
