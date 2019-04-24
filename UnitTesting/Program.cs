using System;
using System.CommandLine;
using System.CommandLine.Rendering;
using System.CommandLine.Rendering.Views;

namespace Bingo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var generator = new BingoBoardGenerator();
            string[,] board = generator.GenerateBoard();
            DrawBoard(board);
        }

        #region Rendering

        private static void DrawBoard(string[,] board)
        {
            var gridView = new GridView();
            
            gridView.SetColumns(
                ColumnDefinition.Star(1),
                ColumnDefinition.Star(1),
                ColumnDefinition.Star(1),
                ColumnDefinition.Star(1),
                ColumnDefinition.Star(1)
            );
            gridView.SetRows(
                RowDefinition.Star(1),
                RowDefinition.Star(1),
                RowDefinition.Star(1),
                RowDefinition.Star(1),
                RowDefinition.Star(1)
            );
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    gridView.SetChild(new MarginContentView(board[i, j]), i, j);
                }
            }

            IConsole console = new SystemConsole();
            ConsoleRenderer renderer = new ConsoleRenderer(console.GetTerminal() ?? console);

            ScreenView screenView = new ScreenView(renderer) { Child = gridView };
            Region region = renderer.GetRegion() ?? new Region(0, 0, 120, 30);
            screenView.Render(region);
        }

        private class MarginContentView : ContentView
        {
            public MarginContentView(string content) : base(content)
            { }

            public override Size Measure(ConsoleRenderer renderer, Size maxSize)
            {
                var size = base.Measure(renderer, maxSize);
                int width = Math.Min(size.Width + 2, maxSize.Width);
                return new Size(width, size.Width);
            }

            public override void Render(ConsoleRenderer renderer, Region region)
            {
                region = new Region(region.Left + 1, region.Top, region.Width - 2, region.Height);
                base.Render(renderer, region);
            }
        }

        #endregion Rendering
    }
}
