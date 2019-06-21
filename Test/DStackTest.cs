using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScientificProgramming.Collections;

namespace Test
{
    [TestClass]
    public class DStackTest
    {
        private DStack<int> GenerateTestStack()
        {
            var stack = new DStack<int>();

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

            // Act
            var itens = stack.GetItems();

            // Assert
            CollectionAssert.AreEqual(itens, expectedResult);
        }

        [TestMethod]
        public void StackOperations()
        {
            // Arrange 
            var stack = GenerateTestStack();
            var removedItens = new int[5];
            var expectedResult = new int[] { 5, 4, 3, 2, 1 };

            // Act
            removedItens[0] = stack.Pop();
            removedItens[1] = stack.Pop();
            removedItens[2] = stack.Pop();
            removedItens[3] = stack.Pop();
            removedItens[4] = stack.Pop();

            // Assert
            CollectionAssert.AreEqual(expectedResult, removedItens);
        }

        [TestMethod]
        public void StackSize()
        {
            // Arrange 
            var stack = GenerateTestStack();

            // Act
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();

            //Assert
            Assert.AreEqual(stack.Quantity, 0);
            Assert.AreEqual(stack.IndexOfLast, -1);
        }

        [TestMethod]
        public void PopOne()
        {
            // Arrange
            var stack = GenerateTestStack();

            // Act
            var removed = stack.Pop();

            // Assert
            Assert.AreEqual(removed, 5);
            Assert.AreEqual(stack.LastValue, 4);
            Assert.AreEqual(stack.Quantity, 4);
        }
    }
}
