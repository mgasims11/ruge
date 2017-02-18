
namespace CardEngine.Logic.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CardEngine.Model;

    public static class DeckBuilder
    {

        public static Deck Create()
        {
            return new Deck();
        }
     
        public static Deck DeckName(this Deck deck,  string deckName)
        {
            deck.DeckName = deckName;
            return deck;
        }

        public static Deck Options(this Deck deck, DeckOptions deckOptions)
        {
            deck.Options = deckOptions;
            return deck;
        }


    }
}
