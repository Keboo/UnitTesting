using System;
using System.Collections.Generic;
using System.Linq;

namespace Bingo
{
    public class BingoBoardGenerator : IBoardGameGenerator
    {
        private readonly IBoardItemsSource _itemsSource;

        public BingoBoardGenerator(IBoardItemsSource itemsSource)
        {
            _itemsSource = itemsSource ?? throw new ArgumentNullException(nameof(itemsSource));
        }

        public string[,] GenerateBoard()
        {
            const int size = 5;
            var rv = new string[size, size];


            List<string> boardItems = _itemsSource.GetBoardItems().Take(25).ToList();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    rv[i, j] = boardItems[i * size + j];
                }
            }

            return rv;
        }
    }
}