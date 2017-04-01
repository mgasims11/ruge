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

        public bool IsStraight(Card[] hand)
        {
            var handList = hand.ToList();
            var existsLowAce = handList.Exists(c => c.Value == 1);
            var existsHighAce = handList.Exists(c => c.Value == 14);

            if (existsLowAce && !existsHighAce)
                handList.Add(new Logic.HandEvaluator.Card() { Value = 14 });

            if (!existsLowAce && existsHighAce)
                handList.Add(new Logic.HandEvaluator.Card() { Value = 1 });

            var sortedHand = handList.OrderBy(h => h.Value).ToList();

            var i = 0;
            var matches = 1;
            while (i < sortedHand.Count)
            {
                if (i > 0)
                {
                    if (((sortedHand[i].Value == (sortedHand[i - 1].Value) + 1)))
                    {
                        matches++;
                    } 
                    else
                    {
                        matches = 1;
                    }
                }
                
                i++;
            }

            return matches == 5;
            
        }

        
    }
}
