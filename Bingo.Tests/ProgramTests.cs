using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace Bingo.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void DisplaysBoard()
        {
            string[,] testBoard = new string[5,5];
            IBoardGameGenerator boardGameGenerator = new TestableBoardGameGenerator { Board = testBoard };

            string[,] drawnBoard = null;
            Program.RunGame(boardGameGenerator, board => { drawnBoard = board; });

            Assert.AreEqual(testBoard, drawnBoard);
        }

        private class TestableBoardGameGenerator : IBoardGameGenerator
        {
            public string[,] Board { get; set; }

            public string[,] GenerateBoard() => Board;
        }
    }
}
