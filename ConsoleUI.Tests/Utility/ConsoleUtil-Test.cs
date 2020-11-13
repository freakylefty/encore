using Microsoft.VisualStudio.TestTools.UnitTesting;

using ConsoleUI.Model;

namespace ConsoleUI.Tests.Utility
{
    [TestClass]
    public class ConsoleUtilTest
    {
        [TestMethod]
        public void TestFitString()
        {
            // No change required
            Assert.AreEqual("12345", ConsoleUtil.FitString("12345", 5), "Should leave string unchanged if required length");

            // Too long
            Assert.AreEqual("12345", ConsoleUtil.FitString("123456", 5), "Should trim string if too long");

            // Align Left
            Assert.AreEqual("1234 ", ConsoleUtil.FitString("1234", 5, Align.Left), "Should pad to left");

            // Align right
            Assert.AreEqual(" 1234", ConsoleUtil.FitString("1234", 5, Align.Right), "Should pad to right");

            // Align centre
            Assert.AreEqual("1234 ", ConsoleUtil.FitString("1234", 5, Align.Centre), "Should weigh to right if split uneven");
            Assert.AreEqual(" 1234 ", ConsoleUtil.FitString("1234", 6, Align.Centre), "Should balance if split even");

            // Custom pad character
            Assert.AreEqual("--1---", ConsoleUtil.FitString("1", 6, '-', Align.Centre), "Should use custom character when provided");
        }
    }
}
