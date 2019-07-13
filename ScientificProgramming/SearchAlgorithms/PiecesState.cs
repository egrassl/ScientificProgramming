using System;
using System.Text;
using ScientificProgramming.Collections;
using ScientificProgramming.SearchAlgorithms.Abstract;

namespace ScientificProgramming.SearchAlgorithms
{
    public class PiecesState : ISearchState
    {
        public SList<SList<int>> State { get; private set; }

        public float Evaluation { get { throw new NotImplementedException(); } }

        private bool CanUp
        {
            get
            {
                return !State[0].Exists(-1);
            }
        }

        private bool CanDown
        {
            get
            {
                return !State[2].Exists(-1);
            }
        }

        private bool CanLeft
        {
            get
            {
                return State[0][0] != -1 && State[1][0] != -1 && State[2][0] != -1;
            }
        }

        private bool CanRight
        {
            get
            {
                return State[0][2] != -1 && State[1][2] != -1 && State[2][2] != -1;
            }
        }

        private Tuple<int, int> EmptyPosition
        {
            get
            {
                int i;
                int j;
                for (i = 0; i < 3; i++)
                {
                    j = State[i].Find(-1);
                    if (j != -1)
                        return new Tuple<int, int>(i, j);
                }
                return new Tuple<int, int>(-1, -1);
            }
        }

        private SList<SList<int>> CopyState()
        {
            var unwrapped = new int[3][];

            for (int i = 0; i < 3; i++)
            {
                unwrapped[i] = State[i].GetItems();
            }

            return CreateStateFromArray(unwrapped);
        }

        private SList<SList<int>> CreateStateFromArray(int[][] state)
        {
            var newState = new SList<int>[3];

            for (int i = 0; i < 3; i++)
            {
                newState[i] = new SList<int>(state[i]);
            }

            return new SList<SList<int>>(newState);
        }

        public PiecesState(int[][] state)
        {
            // Cannot represent a state if it is null
            if (state == null)
                throw new ArgumentNullException("All state dimensions should not be null");

            // Stops if it's not an 3x3 problem
            if (state.Length != 3 || state[0].Length != 3)
                throw new ArgumentException("The specified state should be an 3x3 matrix");

            State = CreateStateFromArray(state);
        }

        public PiecesState(SList<SList<int>> state)
        {
            // Cannot represent a state if it is null
            if (state == null)
                throw new ArgumentNullException("All state dimensions should not be null");

            // Stops if it's not an 3x3 problem
            if (state.Quantity != 3 || state[0].Quantity != 3)
                throw new ArgumentException("The specified state should be an 3x3 matrix");

            State = state;
        }

        public SList<ISearchState> NextStates()
        {
            var nextStates = new SList<ISearchState>();

            var emptyPosition = EmptyPosition;
            var emptyValueRow = emptyPosition.Item1;
            var emptyValueColumn = emptyPosition.Item2;

            if (CanUp)
            {
                var newState = CopyState();

                var upperPiece = State[emptyValueRow - 1][emptyValueColumn];

                newState[emptyValueRow][emptyValueColumn] = upperPiece;

                newState[emptyValueRow - 1][emptyValueColumn] = -1;

                nextStates.Add(new PiecesState(newState));
            }

            if (CanDown)
            {
                var newState = CopyState();

                var lowerPiece = State[emptyValueRow + 1][emptyValueColumn];

                newState[emptyValueRow][emptyValueColumn] = lowerPiece;

                newState[emptyValueRow + 1][emptyValueColumn] = -1;

                nextStates.Add(new PiecesState(newState));
            }

            if (CanLeft)
            {
                var newState = CopyState();

                var leftPiece = State[emptyValueRow][emptyValueColumn - 1];

                newState[emptyValueRow][emptyValueColumn] = leftPiece;

                newState[emptyValueRow][emptyValueColumn - 1] = -1;

                nextStates.Add(new PiecesState(newState));
            }

            if (CanRight)
            {
                var newState = CopyState();

                var rightPiece = State[emptyValueRow][emptyValueColumn + 1];

                newState[emptyValueRow][emptyValueColumn] = rightPiece;

                newState[emptyValueRow][emptyValueColumn + 1] = -1;

                nextStates.Add(new PiecesState(newState));
            }

            return nextStates;
        }

        public override bool Equals(object s2)
        {
            var state2 = s2 as PiecesState;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (State[i][j] != state2.State[i][j])
                        return false;
                }
            }
            return true;
        }
    }
}
