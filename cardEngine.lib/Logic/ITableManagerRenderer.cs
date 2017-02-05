namespace CardEngine.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CardEngine.Model;
    
    public interface ITableManagerRenderer
    {
        // Table Events
        void TableClearing(Guid tableId);
        void TableCleared(Guid tableId);

        void DeckAddedToTable(Guid tableId, Deck deck);
        void DeckBeingRemovedFromTable(Guid tableId, Guid deckId);
        void DeckRemovedFromTable(Guid tableId, Guid deckId);

        // Deck Events
        void DeckClearing(Guid deckId);
        void DeckCleared(Guid deckId);
        void DeckShuffling(Guid deckId);
        void DeckShuffled(Guid deckId);
        void DeckFilling(Guid deckId);
        void DeckFilled(Guid deckId);

        void CardAddedToDeck(Guid deckId, Card card, int position);
        void CardBeingRemovedFromDeck(Guid deckId, Guid cardId);
        void CardRemovedFromDeck(Guid deckId, Guid cardId);
        void CardsSwappingInDeck(Guid soureceDeckId, Guid sourcecardId, Guid destinationDeckId, Guid destinationCardId);
        void CardsSwappedInDeck(Guid soureceDeckId, Guid sourcecardId, Guid destinationDeckId, Guid destinationCardId);
        void CardMoving(Guid sourceDeckId, Guid sourcecardId, Guid destinationDeckId);
        void CardMoved(Guid sourceDeckId, Guid sourcecardId, Guid destinationDeckId);

        // Card Events
        void CardChangingOrientation(Guid cardId);
        void CardChangedOrientation(Guid cardId);
    }
}
