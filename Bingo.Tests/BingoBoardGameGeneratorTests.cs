using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bingo.Tests
{
    [TestClass]
    public class BingoBoardGameGeneratorTests
    {
        [TestMethod]
        public void BoardIs5x5()
        {
            var generator = new BingoBoardGenerator();
            string[,] board = generator.GenerateBoard();

            Assert.AreEqual(25, board.Length);
            Assert.AreEqual(5, board.GetLength(0));
            Assert.AreEqual(5, board.GetLength(1));
        }

        [TestMethod]
        public void BoardContainsExpectedItems()
        {
            var generator = new BingoBoardGenerator();
            string[,] board = generator.GenerateBoard();

            Assert.AreEqual("Hi, who just joined", board[0, 0]);
            Assert.AreEqual("Can you e-mail that to everyone?", board[0, 1]);
            Assert.AreEqual("_, are you there?", board[0, 2]);
            Assert.AreEqual("Uh, _, you are still sharing...", board[0, 3]);
            Assert.AreEqual("I have ot jump to another call", board[0, 4]);
            Assert.AreEqual("(Sound of someone typing, possibly with a hammer)", board[1, 0]);
            Assert.AreEqual("(loud painful echo/feedback)", board[1, 1]);
            Assert.AreEqual("(child or animal noises)", board[1, 2]);
            Assert.AreEqual("Hi, can you hear me?", board[1, 3]);
            Assert.AreEqual("No, it's still loading.", board[1, 4]);
            Assert.AreEqual("Next slide please", board[2, 0]);
            Assert.AreEqual("Can everyone go on mute?", board[2, 1]);
            Assert.AreEqual("I'm sorry I was on mute", board[2, 2]);
            Assert.AreEqual("(For over-talkers) Sorry go ahead", board[2, 3]);
            Assert.AreEqual("Hello? Hello?", board[2, 4]);
            Assert.AreEqual("So (faded out). I can (unintelligible). By (cuts out) Ok?", board[3, 0]);
            Assert.AreEqual("Sorry I'm late. (Insert lame excuse)", board[3, 1]);
            Assert.AreEqual("I have a hard stop at ...", board[3, 2]);
            Assert.AreEqual("I'm sorry, you cut out there", board[3, 3]);
            Assert.AreEqual("Can we take this offline", board[3, 4]);
            Assert.AreEqual("I'll have ot get back to you", board[4, 0]);
            Assert.AreEqual("Can everyone see my screen?", board[4, 1]);
            Assert.AreEqual("Sorry I was having connection issues", board[4, 2]);
            Assert.AreEqual("I think there's a lag", board[4, 3]);
            Assert.AreEqual("Sorry I didn't catch that, can you repeat?", board[4, 4]);
        }
    }
}