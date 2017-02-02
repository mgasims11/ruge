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
        public delegate void DeckEventHandler(object sender, DeckEventArgs e);
        public event DeckEventHandler DeckEvent;

        private void RaiseDeckEvent(DeckEventTypes eventType, Guid deckId, Guid cardId)
        {
            if (DeckEvent != null)
            {
                DeckEvent(this, new DeckEventArgs(eventType, deckId, cardId));
            }
        }

        private void RaiseDeckEvent(DeckEventTypes eventType, Guid tableId)
        {
            if (DeckEvent != null)
            {
                DeckEvent(this, new DeckEventArgs(eventType, tableId));
            }
        }

        public Deck GetDeck(Guid deckId)
        {
            return Table.Decks.FirstOrDefault(d => d.DeckId == deckId);
        }

        public Deck ClearDeck(Guid deckId)
        {
            var deck = GetDeck(deckId);

            RaiseDeckEvent(DeckEventTypes.DeckClearing, deckId);

            deck.Cards.Clear();

            RaiseDeckEvent(DeckEventTypes.DeckClearing, deckId);

            return deck;
        }

        public Deck FillDeck(Guid deckId)
        {
            var deck = GetDeck(deckId);

            RaiseDeckEvent(DeckEventTypes.DeckFilling, deck.DeckId);

            for (var suit = 1; suit <= 4 && deck.Cards.Count < deck.Options.MaxCards; suit++)
            {
                for (var rank = 1; rank <= 13 && deck.Cards.Count < deck.Options.MaxCards; rank++)
                {
                    deck.Cards.Add(new Card((Ranks)rank, (Suits)suit, Orientations.FaceDown, deck, (int)rank));
                }
            }

            RaiseDeckEvent(DeckEventTypes.DeckFilled, deck.DeckId);

            return deck;
        }

        public Deck ShuffleDeck(Guid deckId)
        {
            var deck = GetDeck(deckId);

            RaiseDeckEvent(DeckEventTypes.DeckShuffling, deck.DeckId);

            for (var i = 0; i <= deck.Cards.Count - 1; i++)
            {
                SwapCardsInDeck(deckId, i, GetRandomCardIndexFromDeck(deckId));
            }

            RaiseDeckEvent(DeckEventTypes.DeckShuffled, deck.DeckId);

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

