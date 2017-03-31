using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardEngine.Logic
{
    public class HandEvaluator
    {
        
        public class Card
        {
            public int Value { get; set; }
            public int Suit { get; set; }
        }

        public void Evaluate(Card[] hand)
        {
            foreach(var card in hand)
            {
            }
        }

        public bool IsFlush(Card[] hand)
        {
            var isFlush = true;
            var i = 0;

            while (i < hand.Length && isFlush)
            {
                if (i > 0 && hand[i].Suit != hand[i - 1].Suit)
                    isFlush = false;
                i++;
            }

            return isFlush;
        }

        
    }
}
