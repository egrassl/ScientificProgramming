using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScientificProgramming.Collections;

namespace Test
{
    [TestClass]
    public class StackTests
    {
        private Stack<int> GenerateTestStack()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            return stack;
        }

        [TestMethod]
        public void StackOrder()
        {
            // Arrange
            var stack = GenerateTestStack();
            var expectedResult = new int[] { 1, 2, 3, 4, 5 };

            // Assert
            CollectionAssert.AreEqual(expectedResult, stack.GetItems());
        }

        [TestMethod]
        public void StackPop()
        {
            //Arrange
            var stack = GenerateTestStack();
            var expectedResult = new int[] { 5, 4, 3, 2, 1 };
            var result = new int[5];

            // Act
            for (var i = 0; i < result.Length; i++)
                result[i] = stack.Pop();

            // Assert
            CollectionAssert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void QueueSize()
        {
            // Arrange 
            var stack = GenerateTestStack();
            var quantity = stack.Quantity;

            // Act
            for (var i = 0; i < quantity; i++)
                stack.Pop();

            //Assert
            Assert.AreEqual(stack.Quantity, 0);
            Assert.AreEqual(stack.IndexOfLast, -1);
        }
    }
}
