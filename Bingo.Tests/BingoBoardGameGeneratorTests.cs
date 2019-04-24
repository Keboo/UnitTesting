using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bingo.Tests
{
    [TestClass]
    public class BingoBoardGameGeneratorTests
    {
        [TestMethod]
        public void BoardIs5x5()
        {
            var generator = new BingoBoardGenerator(new TestableItemsSource());
            string[,] board = generator.GenerateBoard();

            Assert.AreEqual(25, board.Length);
            Assert.AreEqual(5, board.GetLength(0));
            Assert.AreEqual(5, board.GetLength(1));
        }

        [TestMethod]
        public void BoardContainsExpectedItems()
        {
            var generator = new BingoBoardGenerator(new TestableItemsSource("foo"));
            string[,] board = generator.GenerateBoard();

            foreach (var item in board)
            {
                Assert.AreEqual("foo", item);
            }
        }

        private class TestableItemsSource : IBoardItemsSource
        {
            private readonly string[] _items;

            public TestableItemsSource(string item = null)
            {
                _items = Enumerable.Repeat(item, 25).ToArray();
            }

            public IEnumerable<string> GetBoardItems() => _items;
        }
    }
}