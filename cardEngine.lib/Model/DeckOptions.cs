namespace CardEngine.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
