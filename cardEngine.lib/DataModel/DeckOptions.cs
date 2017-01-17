using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCardLib.DataModel
{
    public class DeckOptions
    {
        public enum DeckDisplayFormats {
            Long,
            ConciseWithLetters,
            ConciseWithUnicodeSymbols
        }
        public int MaxCards { get; set; }
        public DeckOptions(int maxCards) 
        {
            MaxCards = maxCards;
        }        
        public Card.Formats CardDisplayFormat {get; set; }
    }
}
