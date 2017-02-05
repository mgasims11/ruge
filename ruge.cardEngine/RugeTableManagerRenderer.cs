namespace ruge.cardEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ruge.cardEngine;
    using ruge.lib.logic;
    using ruge.lib.model;
    using ruge.lib.model.controls;
    using ruge.lib.model.engine;
    using ruge.lib.model.user;
    using CardEngine;
    using CardEngine.Logic;
    using CardEngine.Model;

    public class RugeTableManagerRenderer : ITableManagerRenderer
    {
        public CanvasManager CanvasManager = null;

        public RugeTableManagerRenderer()
        {
            CanvasManager = new CanvasManager();
        }

        public void CardAddedToDeck(Guid deckId, Card card, int position)
        {

        }

        public void CardBeingRemovedFromDeck(Guid deckId, Guid cardId)
        {

        }

        public void CardChangedOrientation(Guid cardId)
        {

        }

        public void CardChangingOrientation(Guid cardId)
        {

        }

        public void CardMoved(Guid sourceDeckId, Guid sourcecardId, Guid destinationDeckId)
        {

        }

        public void CardMoving(Guid sourceDeckId, Guid sourcecardId, Guid destinationDeckId)
        {

        }

        public void CardRemovedFromDeck(Guid deckId, Guid cardId)
        {

        }

        public void CardsSwappedInDeck(Guid soureceDeckId, Guid sourcecardId, Guid destinationDeckId, Guid destinationCardId)
        {

        }

        public void CardsSwappingInDeck(Guid soureceDeckId, Guid sourcecardId, Guid destinationDeckId, Guid destinationCardId)
        {

        }

        public void DeckAddedToTable(Guid tableId, Deck deck)
        {

        }

        public void DeckBeingRemovedFromTable(Guid tableId, Guid deckId)
        {

        }

        public void DeckCleared(Guid deckId)
        {

        }

        public void DeckClearing(Guid deckId)
        {

        }

        public void DeckFilled(Guid deckId)
        {

        }

        public void DeckFilling(Guid deckId)
        {

        }

        public void DeckRemovedFromTable(Guid tableId, Guid deckId)
        {

        }

        public void DeckShuffled(Guid deckId)
        {

        }

        public void DeckShuffling(Guid deckId)
        {

        }

        public void TableCleared(Guid tableId)
        {

        }

        public void TableClearing(Guid tableId)
        {

        }
    }
}
