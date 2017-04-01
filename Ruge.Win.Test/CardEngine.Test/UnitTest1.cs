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

            var result = pr.IsStraight(new HandEvaluator.Card[] {
                new HandEvaluator.Card() { Value = 5, Suit = 2 },
                new HandEvaluator.Card() { Value = 9, Suit = 3 },
                new HandEvaluator.Card() { Value = 6, Suit = 1 },
                new HandEvaluator.Card() { Value = 8, Suit = 2 },
                new HandEvaluator.Card() { Value = 7, Suit = 1 }
                }
            );
        }
    }
}
