using System.Collections.Generic;

namespace Bingo
{
    public interface IBoardItemsSource
    {
        IEnumerable<string> GetBoardItems();
    }
}