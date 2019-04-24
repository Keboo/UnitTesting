using Bingo.Tests.Simulators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bingo.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void DisplaysBoard()
        {
            var generator = new MemoryBoardGameGenerator(new MemoryItemsSource());

            string[,] drawnBoard = null;
            Program.RunGame(generator, board => { drawnBoard = board; });
            
            Assert.IsNotNull(drawnBoard);
        }
    }
}
