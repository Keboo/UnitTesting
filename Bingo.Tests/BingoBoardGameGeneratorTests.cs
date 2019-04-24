using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;

namespace Bingo.Tests
{
    [TestClass]
    public class BingoBoardGameGeneratorTests
    {
        private static readonly string[] _items = Enumerable.Repeat("foo", 25).ToArray();

        [TestMethod]
        public void BoardIs5x5()
        {
            var mocker = new AutoMocker();
            Mock<IBoardItemsSource> itemsSourceMock = mocker.GetMock<IBoardItemsSource>();
            itemsSourceMock.Setup(x => x.GetBoardItems())
                .Returns(_items);

            var generator = mocker.CreateInstance<BingoBoardGenerator>();
            string[,] board = generator.GenerateBoard();


            mocker.VerifyAll();
            Assert.AreEqual(25, board.Length);
            Assert.AreEqual(5, board.GetLength(0));
            Assert.AreEqual(5, board.GetLength(1));
        }

        [TestMethod]
        public void BoardContainsExpectedItems()
        {
            var mocker = new AutoMocker();
            Mock<IBoardItemsSource> itemsSourceMock = mocker.GetMock<IBoardItemsSource>();
            itemsSourceMock.Setup(x => x.GetBoardItems())
                .Returns(_items);

            var generator = mocker.CreateInstance<BingoBoardGenerator>();

            string[,] board = generator.GenerateBoard();

            mocker.VerifyAll();
            foreach (var item in board)
            {
                Assert.AreEqual("foo", item);
            }
        }
    }
}