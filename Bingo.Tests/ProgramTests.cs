using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bingo.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void DisplaysBoard()
        {
            string[,] testBoard = new string[5,5];

            Mock<IBoardGameGenerator> boardGameGeneratorMock = new Mock<IBoardGameGenerator>();
            boardGameGeneratorMock.Setup(x => x.GenerateBoard()).Returns(testBoard);

            string[,] drawnBoard = null;
            Program.RunGame(boardGameGeneratorMock.Object, board => { drawnBoard = board; });

            boardGameGeneratorMock.VerifyAll();
            Assert.AreEqual(testBoard, drawnBoard);
        }
    }
}
