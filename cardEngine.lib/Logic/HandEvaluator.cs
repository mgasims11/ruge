using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardEngine.Logic
{
    public enum PokerRanking
    {
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }
    public class HandEvaluator
    {
        
        public class Card
        {
            public int Value { get; set; }
            public int Suit { get; set; }
        }

        public PokerRanking Evaluate(params Card[] hand)
        {

            if (IsRoyalFlush(hand)) return PokerRanking.RoyalFlush;
            if (IsStraightFlush(hand)) return PokerRanking.RoyalFlush;
            if (IsFourOfAKind(hand)) return PokerRanking.RoyalFlush;
            if (IsFullHouse(hand)) return PokerRanking.RoyalFlush;
            if (IsFlush(hand)) return PokerRanking.RoyalFlush;
            if (IsStraight(hand)) return PokerRanking.RoyalFlush;
            if (IsThreeOfAKind(hand)) return PokerRanking.RoyalFlush;
            if (IsTwoPair(hand)) return PokerRanking.RoyalFlush;
            if (IsPair(hand)) return PokerRanking.RoyalFlush;

            return PokerRanking.HighCard; ;
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
            while (i < sortedHand.Count && matches < 5)
            {
                if (i > 0)
                {
                    if (((sortedHand[i].Value == (sortedHand[i - 1].Value) + 1)))
                        matches++;
                    else
                        matches = 1;
                }               
                i++;
            }
            return matches == 5;            
        }

        public bool IsRoyalFlush(Card[] hand)
        {
            var handList = hand.ToList();
            var sortedHand = handList.OrderBy(h => h.Value).ToList();
            return (IsStraight(hand) && IsFlush(hand) && sortedHand[0].Value == 10);
        }

        public bool IsStraightFlush(Card[] hand)
        {
            return (IsStraight(hand) && IsFlush(hand));
        }

        private Card[] _getMatches_Hand;
        private Dictionary<int, int> _bucket;

        public Dictionary<int, int> GetMatches(Card[] hand)
        {
            if (_getMatches_Hand == hand) return _bucket;

            _getMatches_Hand = hand;
            var handList = hand.ToList();
            var existsLowAce = handList.Exists(c => c.Value == 1);
            var existsHighAce = handList.Exists(c => c.Value == 14);

            if (existsLowAce && !existsHighAce)
                handList.Add(new Logic.HandEvaluator.Card() { Value = 14 });

            var sortedHand = handList.OrderBy(h => h.Value).ToList();

            _bucket = new Dictionary<int, int>();

            foreach (var card in sortedHand)
            {
                if (!_bucket.ContainsKey(card.Value))
                    _bucket.Add(card.Value, 1);
                else
                    _bucket[card.Value]++;
            }

            return _bucket;
        }
     

        public bool IsPair(Card[] hand)
        {
            var matches = GetMatches(hand);
            return (matches.Count == 1 && matches[0] == 2);
        }

        public bool IsTwoPair(Card[] hand)
        {
            var matches = GetMatches(hand);
            return (matches.Count == 2 && matches[0] == 2 && matches[1] == 2);
        }

        public bool IsFullHouse(Card[] hand)
        {
            var matches = GetMatches(hand);
            return (matches.Count == 2 && matches[0] == 2 && matches[1] == 3);
        }

        public bool IsFourOfAKind(Card[] hand)
        {
            var matches = GetMatches(hand);
            return (matches.Count == 1 && matches[0] == 4);
        }

        public bool IsThreeOfAKind(Card[] hand)
        {
            var matches = GetMatches(hand);
            return (matches.Count == 1 && matches[0] == 3);
        }

    }
}
