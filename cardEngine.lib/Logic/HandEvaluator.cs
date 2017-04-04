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


        public PokerRanking Evaluate(
            int rank1, int suit1,
            int rank2, int suit2,
            int rank3, int suit3,
            int rank4, int suit4,
            int rank5, int suit5
            )
        {
            return Evaluate(
            new HandEvaluator.Card() { Value = rank1, Suit = suit1 },
            new HandEvaluator.Card() { Value = rank2, Suit = suit2 },
            new HandEvaluator.Card() { Value = rank3, Suit = suit3 },
            new HandEvaluator.Card() { Value = rank4, Suit = suit4 },
            new HandEvaluator.Card() { Value = rank5, Suit = suit5 }
            );
        }

        public PokerRanking Evaluate(params Card[] hand)
        {
            if (IsRoyalFlush(hand)) return PokerRanking.RoyalFlush;
            if (IsStraightFlush(hand)) return PokerRanking.StraightFlush;
            if (IsFourOfAKind(hand)) return PokerRanking.FourOfAKind;
            if (IsFullHouse(hand)) return PokerRanking.FullHouse;
            if (IsFlush(hand)) return PokerRanking.Flush;
            if (IsStraight(hand)) return PokerRanking.Straight;
            if (IsThreeOfAKind(hand)) return PokerRanking.ThreeOfAKind;
            if (IsTwoPair(hand)) return PokerRanking.TwoPair;
            if (IsPair(hand)) return PokerRanking.Pair;

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
            var x = matches.Where(m => m.Value == 2);
            return (x.Count() == 1);
        }

        public bool IsTwoPair(Card[] hand)
        {
            var matches = GetMatches(hand);
            var x = matches.Where(m => m.Value == 2);
            return (x.Count() == 2);
        }

        public bool IsFullHouse(Card[] hand)
        {
            var matches = GetMatches(hand);
            var x = matches.Where(m => m.Value == 2);
            var y = matches.Where(m => m.Value == 3);
            return (x.Count() == 1 && y.Count() == 1);
        }

        public bool IsFourOfAKind(Card[] hand)
        {
            var matches = GetMatches(hand);
            var x = matches.Where(m => m.Value == 4);
            return (x.Count() == 1);
        }

        public bool IsThreeOfAKind(Card[] hand)
        {
            var matches = GetMatches(hand);
            var x = matches.Where(m => m.Value == 3);
            return (x.Count() == 1);
        }

    }
}
