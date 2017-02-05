namespace CardEngine.Logic
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using CardEngine.Model;
    using CardEngine.Logic;

    public partial class TableManager
    {
        public Deck GetDeck(Guid deckId)
        {
            return Table.Decks.FirstOrDefault(d => d.DeckId == deckId);
        }

        public int GetDeckIndex(Guid deckId, Guid cardId)
        {
            var deck = GetDeck(deckId);
            var card = deck.Cards.FirstOrDefault(c => c.CardId == cardId);
            return deck.Cards.IndexOf(card);
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
                    var newCard = new Card((Ranks)rank, (Suits)suit, Orientations.FaceDown, deck, (int)rank);
                    deck.Cards.Add(newCard);
                    _renderer.CardAddedToDeck(deckId, newCard,0);
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
                SwapCards(deckId, i, GetRandomCardIndexFromDeck(deckId));
            }

            if (_renderer != null) { _renderer.DeckShuffled(deck.DeckId); }

            return deck;
        }

        public void SwapCards(Guid sourceDeckId, int sourceCardIndex, Guid destinationDeckId, int destinationCardIndex)
        {
            var sourceDeck = GetDeck(sourceDeckId);
            var destinationDeck = GetDeck(sourceDeckId);

            if (_renderer != null) { _renderer.CardsSwappingInDeck(sourceDeck.DeckId, sourceDeck.Cards[sourceCardIndex].CardId, destinationDeckId, destinationDeck.Cards[destinationCardIndex].CardId); }

            var tempCard = destinationDeck.Cards[destinationCardIndex];
            destinationDeck.Cards[destinationCardIndex] = sourceDeck.Cards[sourceCardIndex];
            sourceDeck.Cards[sourceCardIndex] = tempCard;

            if (_renderer != null) { _renderer.CardsSwappedInDeck(sourceDeck.DeckId, sourceDeck.Cards[sourceCardIndex].CardId, destinationDeckId, destinationDeck.Cards[destinationCardIndex].CardId); }
        }

        public void SwapCards(Guid sourceDeckId, Guid sourceCardId, Guid destinationDeckId, Guid destinationCardId)
        {
            var sourceCardIndex = GetCardIndex(sourceDeckId, sourceCardId);
            var destinationCardIndex = GetCardIndex(destinationDeckId, destinationCardId);
            SwapCards(sourceDeckId, sourceCardIndex, destinationDeckId, destinationCardIndex);
        }

        public void SwapCards(Guid sourceDeckId, int sourceCardIndex, Guid destinationDeckId, Guid destinationCardId)
        {
            var destinationCardIndex = GetCardIndex(destinationDeckId, destinationCardId);
            SwapCards(sourceDeckId, sourceCardIndex, destinationDeckId, destinationCardIndex);
        }

        public void SwapCards(Guid sourceDeckId, Guid sourceCardId, Guid destinationDeckId, int destinationCardIndex)
        {
            var sourceCardIndex = GetCardIndex(sourceDeckId, sourceCardId);
            SwapCards(sourceDeckId, sourceCardIndex, destinationDeckId, destinationCardIndex);
        }

        public void SwapCards(Guid deckId, int sourceCardIndex, int destinationCardIndex)
        {
            SwapCards(deckId, sourceCardIndex, deckId, destinationCardIndex);
        }

        public void SwapCards(Guid deckId, Guid sourceCardId, int destinationCardIndex)
        {
            SwapCards(deckId, sourceCardId, deckId, destinationCardIndex);
        }

        public void SwapCards(Guid deckId, int sourceCardIndex, Guid destinationCardId)
        {
            SwapCards(deckId, sourceCardIndex, deckId, destinationCardId);
        }

        public void SwapCards(Guid deckId, Guid sourceCardId, Guid destinationCardId)
        {
            SwapCards(deckId, sourceCardId, deckId, destinationCardId);
        }

        public void RemoveCard(Guid deckId, int cardIndex)
        {
            var deck = GetDeck(deckId);
            if (_renderer != null) { _renderer.CardBeingRemovedFromDeck(deck.DeckId, deck.Cards[cardIndex].CardId); }
            deck.Cards.RemoveAt(cardIndex);
            if (_renderer != null) { _renderer.CardRemovedFromDeck(deck.DeckId, deck.Cards[cardIndex].CardId); }            
        }

        public void RemoveCard(Guid deckId, Guid cardId)
        {
            var cardIndex = GetCardIndex(deckId, cardId);
            RemoveCard(deckId, cardIndex);
        }

        public void MoveCard(Guid sourceDeckId, int sourceCardIndex, Guid destinationDeckId, int destinationCardIndex)
        {
            var sourceDeck = GetDeck(sourceDeckId);
            var destinationDeck = GetDeck(destinationDeckId);
            Card sourceCard = sourceDeck.Cards[sourceCardIndex];

            _renderer.CardMoving(sourceDeckId, sourceCard.CardId, destinationDeckId);
            destinationDeck.Cards.Insert(destinationCardIndex, sourceCard);
            sourceDeck.Cards.Remove(sourceCard);
            _renderer.CardMoved(sourceDeckId, sourceCard.CardId, destinationDeckId);
        }

        public void MoveCard(Guid sourceDeckId, Guid sourceCardId, Guid destinationDeckId, int destinationCardIndex)
        {
            int sourceCardIndex = GetCardIndex(sourceDeckId, sourceCardId);
            MoveCard(sourceDeckId, sourceCardIndex, destinationDeckId, destinationCardIndex);
        }

        public void MoveCardToTopOfDeck(Guid sourceDeckId, Guid destinationDeckId, int sourceCardIndex)
        {
            var sourceDeck = GetDeck(sourceDeckId);
            var destinationDeck = GetDeck(destinationDeckId);
            MoveCard(sourceDeckId, sourceCardIndex, destinationDeck.DeckId, 0);
        }

        public void MoveCardToTopOfDeck(Guid sourceDeckId, Guid destinationDeckId, Guid sourceCardId)
        {
            var sourceDeck = GetDeck(sourceDeckId);
            var destinationDeck = GetDeck(destinationDeckId);
            MoveCard(sourceDeckId, sourceCardId, destinationDeck.DeckId, 0);
        }

        public void MoveCardToBottomOfDeck(Guid destinationDeckId, Guid sourceDeckId, int sourceCardIndex)
        {            
            var sourceDeck = GetDeck(sourceDeckId);
            var destinationDeck = GetDeck(destinationDeckId);
            var sourceCard = sourceDeck.Cards[sourceCardIndex];

            _renderer.CardMoving(sourceDeckId, sourceCard.CardId, destinationDeckId);
            destinationDeck.Cards.Add(sourceCard);
            sourceDeck.Cards.Remove(sourceCard);
            _renderer.CardMoved(sourceDeckId, sourceCard.CardId, destinationDeckId);
        }

        public void MoveCardToBottomOfDeck(Guid destinationDeckId, Guid sourceDeckId, Guid sourceCardId)
        {
            var sourceCardIndex = GetCardIndex(sourceDeckId, sourceCardId);

            _renderer.CardMoving(sourceDeckId, sourceCardId, destinationDeckId);
            MoveCardToBottomOfDeck(destinationDeckId, sourceDeckId, sourceCardIndex);
            _renderer.CardMoved(sourceDeckId, sourceCardId, destinationDeckId);
        }

        public int GetRandomCardIndexFromDeck(Guid deckId)
        {
            var deck = GetDeck(deckId);

            var seed = Guid.NewGuid().GetHashCode();
            var random = new Random(seed);
            var r = random.Next(deck.Cards.Count);
            return r;
        }
    }
}

