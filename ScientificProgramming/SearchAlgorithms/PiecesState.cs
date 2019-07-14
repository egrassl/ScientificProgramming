using System;
using System.Text;
using ScientificProgramming.Collections;
using ScientificProgramming.SearchAlgorithms.Abstract;

namespace ScientificProgramming.SearchAlgorithms
{
    /// <summary>
    /// A class that implements the ISearchState interface to represent a State in a 3x3 sliding puzzle problem.
    /// </summary>
    public class PiecesState : ISearchState
    {
        /// <summary>
        /// The state itens that are represented as a List of List of integer (an integer Matrix)
        /// </summary>
        public SList<SList<int>> State { get; private set; }

        /// <summary>
        /// Throws an exception because the default pieces problem does not need an evaluation method
        /// </summary>
        public float Evaluation { get { throw new NotImplementedException(); } }

        /// <summary>
        /// True if the empty space can be moved up.
        /// </summary>
        private bool CanUp
        {
            get
            {
                return !State[0].Exists(-1);
            }
        }

        /// <summary>
        /// True if the empty space can be moved down.
        /// </summary>
        private bool CanDown
        {
            get
            {
                return !State[2].Exists(-1);
            }
        }

        /// <summary>
        /// True if the empty space can be moved left.
        /// </summary>
        private bool CanLeft
        {
            get
            {
                return State[0][0] != -1 && State[1][0] != -1 && State[2][0] != -1;
            }
        }

        /// <summary>
        /// True if the empty space can be moved right.
        /// </summary>
        private bool CanRight
        {
            get
            {
                return State[0][2] != -1 && State[1][2] != -1 && State[2][2] != -1;
            }
        }

        /// <summary>
        /// Represents the empty space position (row and column) in this state.
        /// </summary>
        private Tuple<int, int> EmptyPosition
        {
            get
            {
                int i;
                int j;
                // Iterates through all rows
                for (i = 0; i < 3; i++)
                {
                    // If the value that represents an empty space (-1) can be found in that row, then return its position
                    j = State[i].Find(-1);
                    if (j != -1)
                        return new Tuple<int, int>(i, j);
                }

                // Returns a tuple (-1, -1) indicating that the empty space could not be found.
                return new Tuple<int, int>(-1, -1);
            }
        }

        /// <summary>
        /// Returns the state as a printable string
        /// </summary>
        public string ToString
        {
            get
            {
                return Print();
            }
        }

        /// <summary>
        /// Method used to copy the state as a value.
        /// </summary>
        /// <returns></returns>
        private SList<SList<int>> CopyState()
        {
            var unwrapped = new int[3][];

            // Tranform the states itens in a default array of integers.
            for (int i = 0; i < 3; i++)
            {
                unwrapped[i] = State[i].GetItems();
            }

            // Returns a new object created from that array of integers.
            return CreateStateFromArray(unwrapped);
        }

        /// <summary>
        /// Creates a new matrix state representation given an 2 dimensional integer array.
        /// </summary>
        /// <param name="state">State represented as a 2 dimensional integer array.</param>
        /// <returns>State's matrix representation using collections.</returns>
        private SList<SList<int>> CreateStateFromArray(int[][] state)
        {
            var newState = new SList<int>[3];

            // Creates a List of integer for each row
            for (int i = 0; i < 3; i++)
            {
                newState[i] = new SList<int>(state[i]);
            }

            // Creates a List of every rows List and returns it
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

        /// <summary>
        /// Returns a List with the next states obtained from this state.
        /// </summary>
        /// <returns>Next possible states.</returns>
        public SList<ISearchState> NextStates()
        {
            var nextStates = new SList<ISearchState>();

            // Gets the empty space row and column position
            var emptyPosition = EmptyPosition;
            var emptyValueRow = emptyPosition.Item1;
            var emptyValueColumn = emptyPosition.Item2;

            // Switch the empty space with the upper piece if allowed
            if (CanUp)
            {
                var newState = CopyState();

                var upperPiece = State[emptyValueRow - 1][emptyValueColumn];

                newState[emptyValueRow][emptyValueColumn] = upperPiece;

                newState[emptyValueRow - 1][emptyValueColumn] = -1;

                nextStates.Add(new PiecesState(newState));
            }

            // Switch the empty space with the lower piece if allowed
            if (CanDown)
            {
                var newState = CopyState();

                var lowerPiece = State[emptyValueRow + 1][emptyValueColumn];

                newState[emptyValueRow][emptyValueColumn] = lowerPiece;

                newState[emptyValueRow + 1][emptyValueColumn] = -1;

                nextStates.Add(new PiecesState(newState));
            }

            // Switch the empty space with the left piece if allowed
            if (CanLeft)
            {
                var newState = CopyState();

                var leftPiece = State[emptyValueRow][emptyValueColumn - 1];

                newState[emptyValueRow][emptyValueColumn] = leftPiece;

                newState[emptyValueRow][emptyValueColumn - 1] = -1;

                nextStates.Add(new PiecesState(newState));
            }

            // Switch the empty space with the right piece if allowed
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

        /// <summary>
        /// Overrides the default C# object comparer to implement a comparison algorithm between piece states.
        /// </summary>
        /// <param name="s2">State to be compared with.</param>
        /// <returns>True if states are equal and false otherwise.</returns>
        public override bool Equals(object s2)
        {
            var state2 = s2 as PiecesState;

            // Compares every individual item and returns false if at least one is different between states.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (State[i][j] != state2.State[i][j])
                        return false;
                }
            }

            // Returns true if no difference was found
            return true;
        }

        /// <summary>
        /// Transforns the state in a string representation.
        /// </summary>
        /// <returns>String representation of the state.</returns>
        public string Print()
        {
            return string.Format("{0}, {1}, {2}\n{3}, {4}, {5}\n{6}, {7}, {8}\n",
                State[0][0], State[0][1], State[0][2], State[1][0], State[1][1], State[1][2],
                State[2][0], State[2][1], State[2][2]);
        }
    }
}
