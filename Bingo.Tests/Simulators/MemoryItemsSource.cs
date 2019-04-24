using System;
using System.Collections.Generic;

namespace Bingo.Tests.Simulators
{
    public class MemoryItemsSource : IBoardItemsSource
    {
        private readonly IEnumerable<string> _itemsSource;

        public MemoryItemsSource()
        {
            
        }

        public MemoryItemsSource(IEnumerable<string> itemsSource)
        {
            _itemsSource = itemsSource ?? throw new ArgumentNullException(nameof(itemsSource));
        }

        public IEnumerable<string> GetBoardItems()
        {
            if (_itemsSource != null)
            {
                foreach (var item in _itemsSource)
                {
                    yield return item;
                }
            }
            while (true)
            {
                yield return Guid.NewGuid().ToString("N");
            }
        }
    }
}