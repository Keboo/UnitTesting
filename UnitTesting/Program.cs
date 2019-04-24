using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Rendering;
using System.CommandLine.Rendering.Views;
using System.Linq;

namespace Bingo
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new BingoBoardGenerator();
            string[,] board = generator.GenerateBoard();
            DrawBoard(board);
            Console.ReadLine();
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

            IConsole console = new SystemConsole().GetTerminal();
            ConsoleRenderer renderer = new ConsoleRenderer(console);

            ScreenView screenView = new ScreenView(renderer) { Child = gridView };
            screenView.Render();
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

    public class BingoBoardGenerator
    {
        public string[,] GenerateBoard()
        {
            const int size = 5;
            var rv = new string[size, size];

            List<string> boardItems = GetBoardItems().Take(25).ToList();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    rv[i, j] = boardItems[i * size + j];
                }
            }

            return rv;
        }

        private static IEnumerable<string> GetBoardItems()
        {
            yield return "Hi, who just joined";
            yield return "Can you e-mail that to everyone?";
            yield return "_, are you there?";
            yield return "Uh, _, you are still sharing...";
            yield return "I have ot jump to another call";
            yield return "(Sound of someone typing, possibly with a hammer)";
            yield return "(loud painful echo/feedback)";
            yield return "(child or animal noises)";
            yield return "Hi, can you hear me?";
            yield return "No, it's still loading.";
            yield return "Next slide please";
            yield return "Can everyone go on mute?";
            yield return "I'm sorry I was on mute";
            yield return "(For over-talkers) Sorry go ahead";
            yield return "Hello? Hello?";
            yield return "So (faded out). I can (unintelligible). By (cuts out) Ok?";
            yield return "Sorry I'm late. (Insert lame excuse)";
            yield return "I have a hard stop at ...";
            yield return "I'm sorry, you cut out there";
            yield return "Can we take this offline";
            yield return "I'll have ot get back to you";
            yield return "Can everyone see my screen?";
            yield return "Sorry I was having connection issues";
            yield return "I think there's a lag";
            yield return "Sorry I didn't catch that, can you repeat?";
        }
    }
}
