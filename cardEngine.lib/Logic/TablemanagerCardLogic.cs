namespace CardEngine.Logic
{
    using System;
    using CardEngine.Model;
    using System.Linq;

    public partial class TableManager
    {
        public Card GetCard(Guid deckId, Guid cardId)
        {
            var deck = GetDeck(deckId);
            return deck.Cards.FirstOrDefault(c => c.CardId == cardId);
        }

        public int GetCardIndex(Guid deckId, Guid cardId)
        {
            var deck = GetDeck(deckId);
            var card = deck.Cards.FirstOrDefault(c => c.CardId == cardId);
            return deck.Cards.IndexOf(card);
        }

        public void ChangeOrientation(Guid deckId, Guid cardId, Orientations orientation)
        {           
            var card = GetCard(deckId, cardId);
            card.Orientation = orientation;
        }
    }
}
