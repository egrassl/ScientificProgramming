using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScientificProgramming.SearchAlgorithms;

namespace Test
{
    [TestClass]
    public class PiecesStateTest
    {
        public PiecesState GetState1()
        {
            var state = new int[3][];

            state[0] = new int[] { 6, 3, 8 };
            state[1] = new int[] { -1, 5, 7 };
            state[2] = new int[] { 1, 4, 2 };

            return new PiecesState(state);
        }

        [TestMethod]
        public void NextStatesTest()
        {
            // Arrange
            var state = GetState1();

            var state1 = new int[3][];
            var state2 = new int[3][];
            var state3 = new int[3][];

            // Expected Results
            state1[0] = new int[] { -1, 3, 8 };
            state1[1] = new int[] { 6, 5, 7 };
            state1[2] = new int[] { 1, 4, 2 };

            state2[0] = new int[] { 6, 3, 8 };
            state2[1] = new int[] { 5, -1, 7 };
            state2[2] = new int[] { 1, 4, 2 };

            state3[0] = new int[] { 6, 3, 8 };
            state3[1] = new int[] { 1, 5, 7 };
            state3[2] = new int[] { -1, 4, 2 };

            // Act
            var nextStates = state.NextStates().GetItems();

            // Assert
            CollectionAssert.Contains(nextStates, new PiecesState(state1));
            CollectionAssert.Contains(nextStates, new PiecesState(state2));
            CollectionAssert.Contains(nextStates, new PiecesState(state3));
        }
    }
}
