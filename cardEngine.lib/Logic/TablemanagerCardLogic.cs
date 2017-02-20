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

        public Card GetCard(Guid deckId, int index)
        {
            var deck = GetDeck(deckId);
            return deck.Cards[index];
        }
        
        public int GetCardIndex(Deck deck, Card card)
        {
            return deck.Cards.IndexOf(card);
        }

        public void ChangeOrientation(Deck deck, Card card, Orientations orientation)
        {                       
            
            _renderer.CardChangingOrientation(card, orientation);
            card.Orientation = orientation;
            _renderer.CardChangedOrientation(card, orientation);

        }
    }
}
