using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScientificProgramming.SearchAlgorithms;

namespace Test
{
    [TestClass]
    public class PiecesProblems
    {
        public PiecesState GetState1()
        {
            var state = new int[3][];

            state[0] = new int[] { 7, 3, 1 };
            state[1] = new int[] { 2, 5, 8 };
            state[2] = new int[] { 6, -1, 4 };

            return new PiecesState(state);
        }

        public PiecesState GetState2()
        {
            var state = new int[3][];

            state[0] = new int[] { 1, 2, 3 };
            state[1] = new int[] { 4, -1, 6 };
            state[2] = new int[] { 5, 7, 8 };

            return new PiecesState(state);
        }

        public PiecesState GetDesiredState()
        {
            var state = new int[3][];

            state[0] = new int[] { 1, 2, 3 };
            state[1] = new int[] { 4, 5, 6 };
            state[2] = new int[] { 7, 8, -1 };

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
            state1[0] = new int[] { 7, 3, 1 };
            state1[1] = new int[] { 2, 5, 8 };
            state1[2] = new int[] { -1, 6, 4 };

            state2[0] = new int[] { 7, 3, 1 };
            state2[1] = new int[] { 2, -1, 8 };
            state2[2] = new int[] { 6, 5, 4 };

            state3[0] = new int[] { 7, 3, 1 };
            state3[1] = new int[] { 2, 5, 8 };
            state3[2] = new int[] { 6, 4, -1 };

            // Act
            var nextStates = state.NextStates().GetItems();

            // Assert
            CollectionAssert.Contains(nextStates, new PiecesState(state1));
            CollectionAssert.Contains(nextStates, new PiecesState(state2));
            CollectionAssert.Contains(nextStates, new PiecesState(state3));
        }

        [TestMethod]
        public void EqualsStates()
        {
            // Arrange
            var state1 = GetDesiredState();
            var state2 = GetDesiredState();

            // Act
            var success = Equals(state1, state2);

            // Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void DifferentStates()
        {
            // Arrange
            var state1 = GetState1();
            var state2 = GetDesiredState();

            // Act
            var success = Equals(state1, state2);

            // Assert
            Assert.IsFalse(success);
        }


        [TestMethod]
        public void ResultTestBFS()
        {
            // Arrange
            var state = GetState1();
            var result = GetDesiredState();
            var problemSolver = new SearchAlgorithm(state, result, SearchType.BFS);

            // Act
            var success = problemSolver.Resolve();

            // Assert
            Assert.IsTrue(success);
        }


        [TestMethod]
        public void ResultTestDFS()
        {
            var state = GetState1();
            var result = GetDesiredState();

            var problemSolver = new SearchAlgorithm(state, result, SearchType.DFS);

            var success = problemSolver.Resolve();

            Assert.IsTrue(success);
        }
    }
}
