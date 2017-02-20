namespace CardEngine.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CardEngine.Model;
    
    public interface ITableManagerRenderer
    {
        TableManager TableManager { get; set; }

        // Table Events
        void TableClearing(Table table);
        void TableCleared(Table table);

        void DeckAddedToTable(Table table, Deck deck);
        void DeckBeingRemovedFromTable(Table table, Deck deck);
        void DeckRemovedFromTable(Table table, Deck deck);

        // Deck Events
        void DeckClearing(Deck deck);
        void DeckCleared(Deck deck);
        void DeckShuffling(Deck deck);
        void DeckShuffled(Deck deck);
        void DeckFilling(Deck deck);
        void DeckFilled(Deck deck);

        void CardAddedToDeck(Deck deckId, Card card, int position);
        void CardBeingRemovedFromDeck(Deck deck, Guid cardId);
        void CardRemovedFromDeck(Deck deck, Card card);
        void CardsSwappingInDeck(Deck soureceDeck, Card sourcecard, Deck destinationDeck, Card destinationCard);
        void CardsSwappedInDeck(Deck soureceDeck, Card sourcecard, Deck destinationDeck, Card destinationCard);
        void CardMoving(Deck sourceDeck, Card sourcecard, Deck destinationDeck);
        void CardMoved(Deck sourceDeck, Card sourcecard, Deck destinationDeck);

        // Card Events
        void CardChangingOrientation(Card card, Orientations orientation);
        void CardChangedOrientation(Card card, Orientations orientation);
    }
}
