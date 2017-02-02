namespace CardEngine.Logic
{
    using System;
    using CardEngine.Model;
    using CardEngine.Logic.EventArgs;
    using System.Linq;
    using CardEngine.Logic.Enums;

    public partial class TableManager
    {
        public delegate void CardEventHandler(object sender, CardEventArgs e);
        public event CardEventHandler CardEvent;

        private void RaiseCardEvent(CardEventTypes eventType, Guid cardId)
        {
            if (CardEvent != null)
            {
                CardEvent(this, new CardEventArgs(eventType, cardId));
            }
        }

        public Card GetCard(Guid deckId, Guid cardId)
        {
            var deck = GetDeck(deckId);
            return deck.Cards.FirstOrDefault(c => c.CardId == cardId);
        }

        public void ChangeOrientation(Guid deckId, Guid cardId, Orientations orientation)
        {
            RaiseCardEvent(CardEventTypes.CardChangingOrientation, cardId);
            
            var card = GetCard(deckId, cardId);
            card.Orientation = orientation;

            RaiseCardEvent(CardEventTypes.CardChangedOrientation, cardId);
        }
    }
}
