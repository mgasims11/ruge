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

            pr.Evaluate()
            var result = pr.GetMatches(new HandEvaluator.Card[] {
                new HandEvaluator.Card() { Value = 9, Suit = 3 },
                new HandEvaluator.Card() { Value = 7, Suit = 3 },
                new HandEvaluator.Card() { Value = 7, Suit = 3 },
                new HandEvaluator.Card() { Value = 10, Suit = 3 },
                new HandEvaluator.Card() { Value = 10, Suit = 3 }
                }
            );
        }
    }
}
