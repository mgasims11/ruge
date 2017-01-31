
namespace CardEngine.Logic.FluentFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CardEngine.Model;

    public class DeckMaker
    {
        private Deck _deck = null;

        public static DeckMaker Create()
        {
            return new DeckMaker();
        }

        public DeckMaker()
        {
            _deck = new Deck(); ;
        }

        public DeckMaker DeckName(string deckName)
        {
            _deck.DeckName = deckName;
            return this;
        }

        public DeckMaker Options(DeckOptions deckOptions)
        {
            _deck.Options = deckOptions;
            return this;
        }
    }
}
