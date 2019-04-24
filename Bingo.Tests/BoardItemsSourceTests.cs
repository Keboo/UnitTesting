using System.Linq;
using Bingo.Tests.Simulators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bingo.Tests
{
    [TestClass]
    public class MemoryItemsSourceTests : BoardItemsSourceTests
    {
        protected override IBoardItemsSource GetItemsSource()
        {
            return new MemoryItemsSource();
        }
    }

    [TestClass]
    public class FixedItemsSourceTests : BoardItemsSourceTests
    {
        protected override IBoardItemsSource GetItemsSource()
        {
            return new FixedItemsSource();
        }
    }

    public abstract class BoardItemsSourceTests
    {
        protected abstract IBoardItemsSource GetItemsSource();

        [TestMethod]
        public void GetBoardItems_ReturnsAtLeast25Items()
        {
            IBoardItemsSource itemsSource = GetItemsSource();

            Assert.IsTrue(itemsSource.GetBoardItems().Distinct().Take(25).Count() == 25);
        }
    }
}