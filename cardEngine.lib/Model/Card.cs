namespace CardEngine.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Card : CardBase
    {
        string[] _cardChars = {"A","2","3","4","5","6","7","8","9","10","J","Q","K","J","J","J"};
        public enum Formats
        {
            Long,
            ConciseLetter,
            ConciseSymbol
        }
        public enum SuitFormats
        {
            Letter,
            UnicodeSymbol
        } 
        private Ranks _rank;
        public Ranks Rank
        {
            get { return _rank;}
            set { _rank = value; base.DisplayValue = GetDisplayValue(this);} 
        }
        private Suits _suit;
        public Suits Suit        
        {
            get { return _suit;}
            set { _suit = value; base.DisplayValue = GetDisplayValue(this);} 
        }

        public Card(Ranks rank, Suits suit, Orientations orientation, Deck deck, int value)
        {      
            Rank = rank;
            Suit = suit;
        }

        private string GetDisplayValue(Card card)
        {
            string cardString = String.Empty;

             if (!card.Rank.ToString().Contains("Joker"))
             {                
                 if (!card.Rank.ToString().Contains("Joker"))
                     cardString = String.Format("[{0}-{1}]", _cardChars[(int)card.Rank], card.Suit.ToString().Substring(0,1));
                 else
                     cardString =  "[J]";
             }
             return cardString;
        }

    }
}
