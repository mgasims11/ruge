namespace CardEngine.Logic
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using CardEngine.Model;
    using CardEngine.Logic;
    using CardEngine.Logic.EventArgs;
    using CardEngine.Logic.Enums;

    public partial class TableManager
    {
        public delegate void DeckAddingToTableEventHandler(object sender, DeckEventArgs e);
        public delegate void DeckAddedToTableEventHandler(object sender, DeckEventArgs e);
        public delegate void DeckBeingRemovedFromTableEventHandler(object sender, DeckEventArgs e);
        public delegate void DeckRemovedFromTableEventHandler(object sender, DeckEventArgs e);
        public delegate void DeckClearingEventHandler(object sender, DeckEventArgs e);
        public delegate void DeckClearedEventHandler(object sender, DeckEventArgs e);
        public delegate void DeckShufflingEventHandler(object sender, DeckEventArgs e);
        public delegate void DeckShuffledEventHandler(object sender, DeckEventArgs e);
        public delegate void DeckFillingEventHandler(object sender, DeckEventArgs e);
        public delegate void DeckFilledEventHandler(object sender, DeckEventArgs e);
        public delegate void CardAddingToDeckEventHandler(object sender, DeckEventArgs e);
        public delegate void CardAddedToDeckEventHandler(object sender, DeckEventArgs e);
        public delegate void CardRemovingFromDeckEventHandler(object sender, DeckEventArgs e);
        public delegate void CardRemovedFromDeckEventHandler(object sender, DeckEventArgs e);

        public event DeckAddingToTableEventHandler DeckAddingToTableEvent;
        public event DeckAddedToTableEventHandler DeckAddedToTableEvent;
        public event DeckBeingRemovedFromTableEventHandler DeckBeingRemovedFromTableEvent;
        public event DeckRemovedFromTableEventHandler DeckRemovedFromTableEvent;
        public event DeckClearingEventHandler DeckClearingEvent;
        public event DeckClearedEventHandler DeckClearedEvent;
        public event DeckShufflingEventHandler DeckShufflingEvent;
        public event DeckShuffledEventHandler DeckShuffledEvent;
        public event DeckFillingEventHandler DeckFillingEvent;
        public event DeckFilledEventHandler DeckFilledEvent;
        public event CardAddingToDeckEventHandler CardAddingToDeckEvent;
        public event CardAddedToDeckEventHandler CardAddedToDeckEvent;
        public event CardRemovingFromDeckEventHandler CardRemovingFromDeckEvent;
        public event CardRemovedFromDeckEventHandler CardRemovedFromDeckEvent;

        protected Deck GetDeck(Guid deckId)
        {
            return Table.Decks.FirstOrDefault(d => d.DeckId == deckId);
        }

        public Deck ClearDeck(Guid deckId)
        {
            var deck = GetDeck(deckId);

            if (DeckClearingEvent != null)
            {
                DeckClearingEvent(this, new DeckEventArgs(DeckEventTypes.DeckClearing, deckId));
            }

            deck.Cards.Clear();

            if (DeckClearedEvent != null)
            {
                DeckClearedEvent(this, new DeckEventArgs(DeckEventTypes.DeckClearing, deckId));
            }

            return deck;
        }

        public Deck FillDeck(Guid deckId)
        {
            var deck = GetDeck(deckId);

            if (DeckFillingEvent != null)
            {
                DeckFillingEvent(this, new DeckEventArgs(DeckEventTypes.DeckFilling, deck.DeckId));
            }

            for (var suit = 1; suit <= 4 && deck.Cards.Count < deck.Options.MaxCards; suit++)
            {
                for (var rank = 1; rank <= 13 && deck.Cards.Count < deck.Options.MaxCards; rank++)
                {
                    deck.Cards.Add(new Card((Ranks)rank, (Suits)suit, Orientations.FaceDown, deck, (int)rank));
                }
            }

            if (DeckFilledEvent != null)
            {
                DeckFilledEvent(this, new DeckEventArgs(DeckEventTypes.DeckFilled, deck.DeckId));
            }

            return deck;
        }

        public Deck ShuffleDeck(Guid deckId)
        {
            var deck = GetDeck(deckId);

            if (DeckShufflingEvent != null)
            {
                DeckShufflingEvent(this, new DeckEventArgs(DeckEventTypes.DeckShuffling, deck.DeckId));
            }

            for (var i = 0; i <= deck.Cards.Count - 1; i++)
            {
                SwapCards(i, GetRandomCardIndex());
            }

            if (DeckShufflingEvent != null)
            {
                DeckShuffledEvent(this, new DeckEventArgs(DeckEventTypes.DeckShuffled, deck.DeckId));
            }

            return deck;
        }

        public Deck SwapCardsInDeck(Guid deckId, int source, int destination)
        {
            var deck = GetDeck(deckId);

            var tempCard = deck.Cards[destination];
            deck.Cards[destination] = deck.Cards[source];
            deck.Cards[source] = tempCard;

            return deck;
        }

        private Deck RemoveCardFromDeck(Guid deckId, int index)
        {
            var deck = GetDeck(deckId);

            deck.Cards.RemoveAt(index);

            return deck;
        }

        public void DealCardToTopOfDeck(Guid deckId, Guid sourceDeckId, int sourceIndex)
        {
            var deck = GetDeck(deckId);
            var sourceDeck = GetDeck(sourceDeckId);

            if (sourceDeck.Cards.Count > 0)
                deck.Cards.Insert(0, sourceDeck.Cards[sourceIndex]);
            else
                deck.Cards.Add(sourceDeck.Cards[sourceIndex]);
        
            RemoveCardFromDeck(sourceDeckId, sourceIndex);
        }

        public void DealCardToBottomOfDeck(Guid deckId, Guid sourceDeckId, int sourceIndex)
        {
            var deck = GetDeck(deckId);
            var sourceDeck = GetDeck(sourceDeckId);

            deck.Cards.Add(sourceDeck.Cards[sourceIndex]);
            RemoveCardFromDeck(sourceDeckId, sourceIndex);
        }

        public void DealCardToPositionInDeck(Guid deckId, Guid sourceDeckId, int sourceIndex,int destinationIndex)
        {
            var deck = GetDeck(deckId);
            var sourceDeck = GetDeck(sourceDeckId);

            deck.Cards.Insert(destinationIndex, sourceDeck.Cards[sourceIndex]);
            RemoveCardFromDeck(sourceDeckId, sourceIndex);
        }

        private int GetRandomCardIndexFromDeck(Guid deckId)
        {
            var deck = GetDeck(deckId);

            var seed = Guid.NewGuid().GetHashCode();
            var random = new Random(seed);
            var r = random.Next(deck.Cards.Count);
            return r;
        }
    }
}

