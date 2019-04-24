using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bingo.Tests
{
    [TestClass]
    public class FixedItemSourceTests
    {
        [TestMethod]
        public void GetBoardItems_ReturnsItems()
        {
            var items = new FixedItemsSource().GetBoardItems().ToList();

            Assert.AreEqual(25, items.Count);

            Assert.AreEqual("Hi, who just joined", items[0]);
            Assert.AreEqual("Can you e-mail that to everyone?", items[1]);
            Assert.AreEqual("_, are you there?", items[2]);
            Assert.AreEqual("Uh, _, you are still sharing...", items[3]);
            Assert.AreEqual("I have ot jump to another call", items[4]);
            Assert.AreEqual("(Sound of someone typing, possibly with a hammer)", items[5]);
            Assert.AreEqual("(loud painful echo/feedback)", items[6]);
            Assert.AreEqual("(child or animal noises)", items[7]);
            Assert.AreEqual("Hi, can you hear me?", items[8]);
            Assert.AreEqual("No, it's still loading.", items[9]);
            Assert.AreEqual("Next slide please", items[10]);
            Assert.AreEqual("Can everyone go on mute?", items[11]);
            Assert.AreEqual("I'm sorry I was on mute", items[12]);
            Assert.AreEqual("(For over-talkers) Sorry go ahead", items[13]);
            Assert.AreEqual("Hello? Hello?", items[14]);
            Assert.AreEqual("So (faded out). I can (unintelligible). By (cuts out) Ok?", items[15]);
            Assert.AreEqual("Sorry I'm late. (Insert lame excuse)", items[16]);
            Assert.AreEqual("I have a hard stop at ...", items[17]);
            Assert.AreEqual("I'm sorry, you cut out there", items[18]);
            Assert.AreEqual("Can we take this offline", items[19]);
            Assert.AreEqual("I'll have ot get back to you", items[20]);
            Assert.AreEqual("Can everyone see my screen?", items[21]);
            Assert.AreEqual("Sorry I was having connection issues", items[22]);
            Assert.AreEqual("I think there's a lag", items[23]);
            Assert.AreEqual("Sorry I didn't catch that, can you repeat?", items[24]);
        }
    }
}