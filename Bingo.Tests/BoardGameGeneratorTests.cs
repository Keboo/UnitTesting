using Bingo.Tests.Simulators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Bingo.Tests
{

    [TestClass]
    public class MemoryBoardGameGeneratorTests : BoardGameGeneratorTests
    {
        protected override IBoardGameGenerator GetBoardGameGenerator(IBoardItemsSource itemsSource)
        {
            return new MemoryBoardGameGenerator(itemsSource);
        }
    }


    [TestClass]
    public class BingoBoardGameGeneratorTests : BoardGameGeneratorTests
    {
        protected override IBoardGameGenerator GetBoardGameGenerator(IBoardItemsSource itemsSource)
        {
            return new BingoBoardGenerator(itemsSource);
        }
    }

    public abstract class BoardGameGeneratorTests
    {
        protected abstract IBoardGameGenerator GetBoardGameGenerator(IBoardItemsSource itemsSource);

        [TestMethod]
        public void BoardIs5x5()
        {
            IBoardItemsSource itemsSource = new MemoryItemsSource();
            IBoardGameGenerator generator = GetBoardGameGenerator(itemsSource);

            string[,] board = generator.GenerateBoard();
            
            Assert.AreEqual(25, board.Length);
            Assert.AreEqual(5, board.GetLength(0));
            Assert.AreEqual(5, board.GetLength(1));
        }

        [TestMethod]
        public void BoardContainsExpectedItems()
        {
            IEnumerable<string> items = Enumerable.Range(1, 25).Select(x => x.ToString()).ToList();
            IBoardItemsSource itemsSource = new MemoryItemsSource(items);
            IBoardGameGenerator generator = GetBoardGameGenerator(itemsSource);

            string[,] board = generator.GenerateBoard();

            List<string> allItems = board.Cast<string>().ToList();
            foreach (string item in items)
            {
                Assert.IsTrue(allItems.Contains(item));
            }
        }
    }
}