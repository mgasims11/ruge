namespace CardEngine.Logic
{
    using System;
    using CardEngine.Model;
    using CardEngine.Logic.EventArgs;
    using System.Linq;

    public partial class TableManager
    {
        public delegate void CardOrientationChangingEventHandler(object sender, CardEventArgs e);
        public delegate void CardOrientationChangedEventHandler(object sender, CardEventArgs e);
        public event CardOrientationChangingEventHandler CardOrientationChangingEvent;
        public event CardOrientationChangedEventHandler CardOrientationChangedEvent;

        public Card GetCard(Guid deckId, Guid cardId)
        {
            var deck = GetDeck(deckId);
            return deck.Cards.FirstOrDefault(c => c.CardId == cardId);
        }

        public void ChangeOrientation(Guid deckId, Guid cardId, Orientations orientation)
        {
            if (CardOrientationChangingEvent != null) CardOrientationChangingEvent(this, new CardEventArgs(deckId, cardId));

            var card = GetCard(deckId, cardId);
            card.Orientation = orientation;

            if (CardOrientationChangedEvent != null) CardOrientationChangedEvent(this, new CardEventArgs(deckId, cardId));
        }
    }
}
