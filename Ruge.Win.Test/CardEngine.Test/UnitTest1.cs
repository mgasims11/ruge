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
            var pr = new CardEngine.Logic.HandEvaluator();

            var result = pr.IsFlush(new HandEvaluator.Card[] {
                new HandEvaluator.Card() { Value = 1, Suit = 1 },
                new HandEvaluator.Card() { Value = 1, Suit = 1 },
                new HandEvaluator.Card() { Value = 1, Suit = 1 },
                new HandEvaluator.Card() { Value = 1, Suit = 1 },
                new HandEvaluator.Card() { Value = 1, Suit = 1 }
                }
            );
        }
    }
}
