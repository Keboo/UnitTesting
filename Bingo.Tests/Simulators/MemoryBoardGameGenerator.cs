using System;
using System.Collections.Generic;
using System.Linq;

namespace Bingo.Tests.Simulators
{
    public class MemoryBoardGameGenerator : IBoardGameGenerator
    {
        private readonly IBoardItemsSource _itemsSource;

        public MemoryBoardGameGenerator(IBoardItemsSource itemsSource)
        {
            _itemsSource = itemsSource ?? throw new ArgumentNullException(nameof(itemsSource));
        }

        public string[,] GenerateBoard()
        {
            var items = _itemsSource?.GetBoardItems().Take(25).ToList() ?? new List<string>(Enumerable.Repeat(0, 25).Select(_ => Guid.NewGuid().ToString("N")));

            return new [,]
            {
                {items[0], items[5], items[10], items[15], items[20] },
                {items[1], items[6], items[11], items[16], items[21] },
                {items[2], items[7], items[12], items[17], items[22] },
                {items[3], items[8], items[13], items[18], items[23] },
                {items[4], items[9], items[14], items[19], items[24] }
            };
        }
    }
}