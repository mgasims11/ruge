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

        public Deck GetDeckForCard(Guid cardId)
        {
            return Table.Decks.FirstOrDefault(d => d.Cards.Exists(c => c.CardId == cardId));
        }

        public int GetDeckIndex(Guid deckId, Guid cardId)
        {
            var deck = GetDeck(deckId);
            var card = deck.Cards.FirstOrDefault(c => c.CardId == cardId);
            return deck.Cards.IndexOf(card);
        }


        public Deck ClearDeck(Deck deck)
        {           
            if (_renderer != null) { _renderer.DeckClearing(deck); }
            deck.Cards.Clear();
            if (_renderer != null) { _renderer.DeckCleared(deck); }
            return deck;
        }

        public Deck FillDeck(Deck deck)
        {
            if (_renderer != null) { _renderer.DeckFilling(deck); }

            for (var suit = 1; suit <= 4 && deck.Cards.Count < deck.Options.MaxCards; suit++)
            {
                for (var rank = 1; rank <= 13 && deck.Cards.Count < deck.Options.MaxCards; rank++)
                {
                    var newCard = new Card((Ranks)rank, (Suits)suit, Orientations.FaceDown, deck, (int)rank);
                    deck.Cards.Add(newCard);
                    _renderer.CardAddedToDeck(deck, newCard,0);
                }
            }

            if (_renderer != null) { _renderer.DeckFilled(deck); }

            return deck;
        }

        public Deck ShuffleDeck(Deck deck)
        {
            if (_renderer != null) { _renderer.DeckShuffling(deck); }

            for (var i = 0; i <= deck.Cards.Count - 1; i++)
            {
                SwapCards(deck, i, GetRandomCardIndexFromDeck(deck));
            }

            if (_renderer != null) { _renderer.DeckShuffled(deck); }

            return deck;
        }

        public void SwapCards(Deck sourceDeck, int sourceCardIndex, Deck destinationDeck, int destinationCardIndex)
        {
            if (_renderer != null) { _renderer.CardsSwappingInDeck(sourceDeck, sourceDeck.Cards[sourceCardIndex], destinationDeck, destinationDeck.Cards[destinationCardIndex]); }

            var tempCard = destinationDeck.Cards[destinationCardIndex];
            destinationDeck.Cards[destinationCardIndex] = sourceDeck.Cards[sourceCardIndex];
            sourceDeck.Cards[sourceCardIndex] = tempCard;

            if (_renderer != null) { _renderer.CardsSwappedInDeck(sourceDeck, sourceDeck.Cards[sourceCardIndex], destinationDeck, destinationDeck.Cards[destinationCardIndex]); }
        }

        public void SwapCards(Deck sourceDeck, Card sourceCard, Deck destinationDeck, Card destinationCard)
        {
            var sourceCardIndex = GetCardIndex(sourceDeck, sourceCard);
            var destinationCardIndex = GetCardIndex(destinationDeck, destinationCard);
            SwapCards(sourceDeck, sourceCardIndex, destinationDeck, destinationCardIndex);
        }

        public void SwapCards(Deck sourceDeck, int sourceCardIndex, Deck destinationDeck, Card destinationCard)
        {
            var destinationCardIndex = GetCardIndex(destinationDeck, destinationCard);
            SwapCards(sourceDeck, sourceCardIndex, destinationDeck, destinationCardIndex);
        }

        public void SwapCards(Deck sourceDeck, Card sourceCard, Deck destinationDeck, int destinationCardIndex)
        {
            var sourceCardIndex = GetCardIndex(sourceDeck, sourceCard);
            SwapCards(sourceDeck, sourceCardIndex, destinationDeck, destinationCardIndex);
        }

        public void SwapCards(Deck deck, int sourceCardIndex, int destinationCardIndex)
        {
            SwapCards(deck, sourceCardIndex, deck, destinationCardIndex);
        }

        public void SwapCards(Deck deck, Card sourceCard, int destinationCardIndex)
        {
            SwapCards(deck, sourceCard, deck, destinationCardIndex);
        }

        public void SwapCards(Deck deck, int sourceCardIndex, Card destinationCard)
        {
            SwapCards(deck, sourceCardIndex, deck, destinationCard);
        }

        public void SwapCards(Deck deck, Card sourceCard, Card destinationCard)
        {
            SwapCards(deck, sourceCard, deck, destinationCard);
        }

        public void RemoveCard(Deck deck, int cardIndex)
        {           
            if (_renderer != null) { _renderer.CardBeingRemovedFromDeck(deck, deck.Cards[cardIndex].CardId); }
            deck.Cards.RemoveAt(cardIndex);
            if (_renderer != null) { _renderer.CardRemovedFromDeck(deck, deck.Cards[cardIndex]); }
        }

        public void RemoveCard(Deck deck, Card card)
        {
            var cardIndex = GetCardIndex(deck, card);
            RemoveCard(deck, cardIndex);
        }

        public void MoveCard(Deck sourceDeck, int sourceCardIndex, Deck destinationDeck, int destinationCardIndex)
        {
            
            Card sourceCard = sourceDeck.Cards[sourceCardIndex];

            _renderer.CardMoving(sourceDeck, sourceCard, destinationDeck);
            destinationDeck.Cards.Insert(destinationCardIndex, sourceCard);
            sourceDeck.Cards.Remove(sourceCard);
            _renderer.CardMoved(sourceDeck, sourceCard, destinationDeck);
        }

        public void MoveCard(Deck sourceDeck, Card sourceCard, Deck destinationDeck, int destinationCardIndex)
        {
            int sourceCardIndex = GetCardIndex(sourceDeck, sourceCard);
            MoveCard(sourceDeck, sourceCardIndex, destinationDeck, destinationCardIndex);
        }

        public void DealCardsFromTopToTop(Deck sourceDeck, Deck destinationDeck, int numberOfCards)
        {
            for (var i = 0; i<=numberOfCards - 1; i++)
            {
                MoveCardToTopOfDeck(sourceDeck, destinationDeck, 0);
            }
        }

        public void MoveCardToTopOfDeck(Deck sourceDeck, Deck destinationDeck, int sourceCardIndex)
        {
            MoveCard(sourceDeck, sourceCardIndex, destinationDeck, 0);
        }

        public void MoveCardToTopOfDeck(Deck sourceDeck, Deck destinationDeck, Card sourceCard)
        {
            MoveCard(sourceDeck, sourceCard, destinationDeck, 0);
        }

        public void MoveCardToBottomOfDeck(Deck destinationDeck, Deck sourceDeck, int sourceCardIndex)
        {            
            var sourceCard = sourceDeck.Cards[sourceCardIndex];

            _renderer.CardMoving(sourceDeck, sourceCard, destinationDeck);
            destinationDeck.Cards.Add(sourceCard);
            sourceDeck.Cards.Remove(sourceCard);
            _renderer.CardMoved(sourceDeck, sourceCard, destinationDeck);
        }

        public void MoveCardToBottomOfDeck(Deck destinationDeck, Deck sourceDeck, Card sourceCard)
        {
            var sourceCardIndex = GetCardIndex(sourceDeck, sourceCard);

            _renderer.CardMoving(sourceDeck, sourceCard, destinationDeck);
            MoveCardToBottomOfDeck(destinationDeck, sourceDeck, sourceCardIndex);
            _renderer.CardMoved(sourceDeck, sourceCard, destinationDeck);
        }

        public int GetRandomCardIndexFromDeck(Deck deck)
        {
            var seed = Guid.NewGuid().GetHashCode();
            var random = new Random(seed);
            var r = random.Next(deck.Cards.Count);
            return r;
        }
    }
}

