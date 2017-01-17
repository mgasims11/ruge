using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCardLib.DataModel
{
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
            this.Rank = rank;
            this.Suit = suit;
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

        // public string ToString(Formats format)
        // {
        //     string cardString = String.Empty;
        //     switch (format)
        //     {
        //         case Formats.Long:
        //             cardString =  Card.GetLongFormat(this);
        //             break;
        //         case Formats.ConciseLetter: 
        //             cardString =  GetFormatConcise(this, SuitFormats.Letter);
        //             break;
        //         case Formats.ConciseSymbol: 
        //             cardString =  GetFormatConcise(this, SuitFormats.UnicodeSymbol);
        //             break;   
        //            default:
        //             cardString = String.Empty;
        //             break;           
        //     }                          
        //     return cardString;
        // }

        //  public static string GetFormatConcise(Card card, SuitFormats format)
        //  {
        //      string cardString = String.Empty;

        //      if (!card.Rank.ToString().Contains("Joker"))
        //      {                
        //          if (!card.Rank.ToString().Contains("Joker"))
        //              cardString = String.Format("[{0}-{1}]", Card.GetRankLetter(card.Rank), Card.GetSuitChar(card, format));
        //          else
        //              cardString =  "[J]";
        //      }
        //      return cardString;
        //  }
        // public static string GetLongFormat(Card card)
        // {
        //      return String.Format("[{0} of {1}]", card.Rank, card.Suit);
        // }
        //  public static string GetRankLetter(Ranks rank)
        //  {
        //      string[] cardChars = {"A","2","3","4","5","6","7","8","9","10","J","Q","K","J","J","J"};
        //      return cardChars[(int)rank];
        //  }

        // public static String GetSuitChar(Card card, SuitFormats format)
        // {
        //     string suitString = String.Empty;
        //     switch (format)
        //     {
        //         case SuitFormats.Letter:
        //             suitString = Card.GetSuitLetter(card.Suit);
        //         break;
        //         case SuitFormats.UnicodeSymbol:
        //             suitString = Card.GetSuitSymbol(card.Suit);
        //         break;
        //     }
        //     return suitString;
        // }

        //  public static string GetSuitLetter(Suits suit)
        //  {
        //      return suit.ToString().Substring(0,1);
        //  }

        //  public static string GetSuitSymbol(Suits suit)
        //  {
        //      switch (suit)
        //      {
        //          case Suits.None:
        //              return "";
        //          case Suits.Clubs:
        //              return "\u2663";
        //          case Suits.Spades:
        //              return "\u2660";
        //          case Suits.Hearts:
        //              return "\u2665";
        //          case Suits.Diamonds:
        //              return "\u2666";
        //      }
        //      return suit.ToString().Substring(0,1);
        //  }
    }
}
