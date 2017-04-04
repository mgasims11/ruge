using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardEngine.Logic;

namespace CardEngine.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var he = new CardEngine.Logic.HandEvaluator();

            Assert.AreEqual(he.Evaluate(1, 2, 8, 3, 3, 2, 4, 5, 5, 1), PokerRanking.HighCard);
            Assert.AreEqual(he.Evaluate(2, 2, 4, 2, 6, 2, 8, 2, 10, 2), PokerRanking.Flush);
            Assert.AreEqual(he.Evaluate(7, 2, 4, 0, 6, 2, 7, 2, 10, 2), PokerRanking.Pair);
            Assert.AreEqual(he.Evaluate(7, 1, 4, 2, 6, 2, 7, 2, 4, 2), PokerRanking.TwoPair);
            Assert.AreEqual(he.Evaluate(7, 2, 4, 2, 7, 2, 7, 2, 4, 2), PokerRanking.FullHouse);
            Assert.AreEqual(he.Evaluate(7, 2, 4, 2, 7, 2, 7, 2, 5, 1), PokerRanking.ThreeOfAKind);
            Assert.AreEqual(he.Evaluate(7, 2, 7, 2, 7, 2, 7, 2, 5, 1), PokerRanking.FourOfAKind);
            Assert.AreEqual(he.Evaluate(7, 2, 8, 9, 9, 2, 10, 2, 11, 1), PokerRanking.Straight);
            Assert.AreEqual(he.Evaluate(10, 2, 11, 2, 12, 2, 13, 2, 14, 2), PokerRanking.RoyalFlush);
        }
    }
}
