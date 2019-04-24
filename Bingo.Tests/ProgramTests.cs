using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace Bingo.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void DisplaysBoard()
        {
            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));
            Program.Main(null);

            string output = sb.ToString().Trim();
            Assert.IsFalse(string.IsNullOrEmpty(output));
        }
    }
}
