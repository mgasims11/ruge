
namespace CardEngine.Logic.FluentFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CardEngine.Model;

    public class DeckBuilder
    {
        private Deck _deck = null;

        public static DeckBuilder Create()
        {
            return new DeckBuilder();
        }

        public DeckBuilder()
        {
            _deck = new Deck(); ;
        }

        public DeckBuilder DeckName(string deckName)
        {
            _deck.DeckName = deckName;
            return this;
        }

        public DeckBuilder Options(DeckOptions deckOptions)
        {
            _deck.Options = deckOptions;
            return this;
        }
    }
}
