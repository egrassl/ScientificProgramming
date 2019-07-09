using System;
using System.Collections.Generic;
using System.Text;
using ScientificProgramming.SearchAlgorithms.Abstract;
using ScientificProgramming.Collections;

namespace ScientificProgramming.SearchAlgorithms
{
    public enum SearchAlgorithm
    {
        BFS,
        DFS,
        HillClimb,
        AStar
    }

    public class PiecesProblem
    {
        public PiecesState InitialState { get; private set; }

        private PiecesState CurrentState { get; set; }

        public SearchAlgorithm SearchAlgorithm { get; private set; }

        public SCollection<PiecesState> StatesToSearch { get; private set; }

        public SCollection<PiecesState> StatesSearched { get; private set; }

        public PiecesState NextState()
        {
            if (SearchAlgorithm == SearchAlgorithm.BFS)
            {

            }
            else if (SearchAlgorithm == SearchAlgorithm.DFS)
            {

            }
            else if (SearchAlgorithm == SearchAlgorithm.HillClimb)
            {

            }
            else if (SearchAlgorithm == SearchAlgorithm.AStar)
            {

            }
            else
            {
                throw new Exception("The search algorithm must be specified!!");
            }
        }

        public void Execute()
        {
            Console.WriteLine();
        }
    }
}
