using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScientificProgramming.Collections;

namespace Test
{
    [TestClass]
    public class QueueTest
    {
        private Queue<int> GenerateTestQueue()
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            return queue;
        }

        [TestMethod]
        public void QueueOrder()
        {
            // Arrange
            var queue = GenerateTestQueue();
            var expectedResult = new int[] { 5, 4, 3, 2, 1 };

            // Act
            var itens = queue.GetItems();

            // Assert
            CollectionAssert.AreEqual(itens, expectedResult);
        }

        [TestMethod]
        public void QueueOperations()
        {
            // Arrange 
            var queue = GenerateTestQueue();
            var removedItens = new int[5];
            var expectedResult = new int[] { 1, 2, 3, 4, 5 };

            // Act
            removedItens[0] = queue.Dequeue();
            removedItens[1] = queue.Dequeue();
            removedItens[2] = queue.Dequeue();
            removedItens[3] = queue.Dequeue();
            removedItens[4] = queue.Dequeue();

            // Assert
            CollectionAssert.AreEqual(expectedResult, removedItens);
        }

        [TestMethod]
        public void QueueSize()
        {
            // Arrange 
            var queue = GenerateTestQueue();

            // Act
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            //Assert
            Assert.AreEqual(queue.Quantity, 0);
            Assert.AreEqual(queue.IndexOfLast, -1);
        }
    }
}
