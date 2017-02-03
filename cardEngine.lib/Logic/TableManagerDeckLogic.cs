namespace CardEngine.Logic
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using CardEngine.Model;
    using CardEngine.Logic;

    public partial class TableManager
    {
        public delegate void DeckEventHandler(object sender, DeckEventArgs e);
        public event DeckEventHandler DeckEvent;

        public Deck GetDeck(Guid deckId)
        {
            return Table.Decks.FirstOrDefault(d => d.DeckId == deckId);
        }

        public Deck ClearDeck(Guid deckId)
        {
            var deck = GetDeck(deckId);
            if (_renderer != null) { _renderer.DeckClearing(deck.DeckId); }
            deck.Cards.Clear();
            if (_renderer != null) { _renderer.DeckCleared(deck.DeckId); }
            return deck;
        }

        public Deck FillDeck(Guid deckId)
        {
            var deck = GetDeck(deckId);

            if (_renderer != null) { _renderer.DeckFilling(deck.DeckId); }

            for (var suit = 1; suit <= 4 && deck.Cards.Count < deck.Options.MaxCards; suit++)
            {
                for (var rank = 1; rank <= 13 && deck.Cards.Count < deck.Options.MaxCards; rank++)
                {
                    deck.Cards.Add(new Card((Ranks)rank, (Suits)suit, Orientations.FaceDown, deck, (int)rank));
                }
            }

            if (_renderer != null) { _renderer.DeckFilled(deck.DeckId); }

            return deck;
        }

        public Deck ShuffleDeck(Guid deckId)
        {
            var deck = GetDeck(deckId);

            if (_renderer != null) { _renderer.DeckShuffling(deck.DeckId); }

            for (var i = 0; i <= deck.Cards.Count - 1; i++)
            {
                SwapCardsInDeck(deckId, i, GetRandomCardIndexFromDeck(deckId));
            }

            if (_renderer != null) { _renderer.DeckShuffled(deck.DeckId); }

            return deck;
        }

        this whole card positioning thing needs to be thought out.

        public Deck SwapCardsInDeck(Guid deckId, int source, int destination)
        {

            var deck = GetDeck(deckId);

            if (_renderer != null) { _renderer.CardsSwappingInDeck(deck.DeckId, deck.Cards[source].CardId, deck.Cards[destination].CardId); }

            var tempCard = deck.Cards[destination];
            deck.Cards[destination] = deck.Cards[source];
            deck.Cards[source] = tempCard;

            if (_renderer != null) { _renderer.CardsSwappedInDeck(deck.DeckId, deck.Cards[source].CardId, deck.Cards[destination].CardId); }
            return deck;
        }

        private Deck RemoveCardFromDeck(Guid deckId, int index)
        {
            var deck = GetDeck(deckId);

            if (_renderer != null) { _renderer.CardBeingRemovedFromDeck(deck.DeckId, deck.Cards[index].CardId); }

            deck.Cards.RemoveAt(index);

            if (_renderer != null) { _renderer.CardRemovedFromDeck(deck.DeckId, deck.Cards[index].CardId); }

            return deck;
        }

        public void DealCardToTopOfDeck(Guid deckId, Guid sourceDeckId, int sourceIndex)
        {
            var deck = GetDeck(deckId);
            var sourceDeck = GetDeck(sourceDeckId);

            if (sourceDeck.Cards.Count > 0)
            {
                deck.Cards.Insert(0, sourceDeck.Cards[sourceIndex]);
            }
            else
            {
                deck.Cards.Add(sourceDeck.Cards[sourceIndex]);
            }
        
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

