namespace CardEngine.Logic
{
    using System;
    using System.Collections.Generic;
    using CardEngine.Model;

    public class DeckManager
    {
        public EventHandler<DeckManagerEventArgs> DeckClearingEvent;
        public EventHandler<DeckManagerEventArgs> DeckClearedEvent;
        public EventHandler<DeckManagerEventArgs> DeckShufflingEvent;
        public EventHandler<DeckManagerEventArgs> DeckShuffledEvent;
        public EventHandler<DeckManagerEventArgs> DeckFillingEvent;
        public EventHandler<DeckManagerEventArgs> DeckFilledEvent;

        public Deck Deck = new Deck();

        public Deck DeckName(string deckName)
        {
            Deck.DeckName = deckName;
            return Deck;
        }

        public Deck Options(DeckOptions deckOptions)
        {
            Deck.Options = deckOptions;
            return Deck;
        }

        public Deck Clear()
        {
            if (DeckClearingEvent != null)
            {
                DeckClearingEvent(this, new DeckManagerEventArgs(Deck.DeckId));
            }

            Deck.Cards.Clear();

            if (DeckClearedEvent != null)
            {
                DeckClearedEvent(this, new DeckManagerEventArgs(Deck.DeckId));
            }

            return Deck;
        }

        public Deck Fill()
        {
            if (DeckFillingEvent != null)
            {
                DeckFillingEvent(this, new DeckManagerEventArgs(Deck.DeckId));
            }

            for (var suit = 1; suit <= 4 && Deck.Cards.Count < Deck.Options.MaxCards; suit++)
            {
                for (var rank = 1; rank <= 13 && Deck.Cards.Count < Deck.Options.MaxCards; rank++)
                {
                    Deck.Cards.Add(new Card((Ranks)rank, (Suits)suit, Orientations.FaceDown, Deck, (int)rank));
                }
            }

            if (DeckFilledEvent != null)
            {
                DeckFilledEvent(this, new DeckManagerEventArgs(Deck.DeckId));
            }

            return Deck;
        }

        public Deck Shuffle()
        {
            if (DeckShufflingEvent != null)
            {
                DeckShufflingEvent(this, new DeckManagerEventArgs(Deck.DeckId));
            }

            for (var i = 0; i <= Deck.Cards.Count - 1; i++)
            {
                SwapCards(i, GetRandomCardIndex());
            }

            if (DeckShufflingEvent != null)
            {
                DeckShuffledEvent(this, new DeckManagerEventArgs(Deck.DeckId));
            }

            return Deck;
        }

        public Deck SwapCards(int source, int destination)
        {
            var tempCard = Deck.Cards[destination];
            Deck.Cards[destination] = Deck.Cards[source];
            Deck.Cards[source] = tempCard;

            return Deck;
        }

        public Deck RemoveCard(int index)
        {
            RemoveCard(Deck, index);

            return Deck;
        }

        private void RemoveCard(Deck deck,  int index)
        {
            deck.Cards.RemoveAt(index);
        }

        public void DealCardToTop(Deck sourceDeck, int sourceIndex)
        {
            if (sourceDeck.Cards.Count > 0)
                Deck.Cards.Insert(0, sourceDeck.Cards[sourceIndex]);
            else
                Deck.Cards.Add(sourceDeck.Cards[sourceIndex]);
        
            RemoveCard(sourceDeck, sourceIndex);
        }

        public void DealCardToBottom(Deck sourceDeck, int sourceIndex)
        {
            Deck.Cards.Add(sourceDeck.Cards[sourceIndex]);
            RemoveCard(sourceDeck, sourceIndex);
        }

        public void DealCardToPosition(Deck sourceDeck, int sourceIndex,int destinationIndex)
        {
            Deck.Cards.Insert(destinationIndex, sourceDeck.Cards[sourceIndex]);
            RemoveCard(sourceDeck, sourceIndex);
        }


        private int GetRandomCardIndex()
        {
            var seed = Guid.NewGuid().GetHashCode();
            var random = new Random(seed);
            var r = random.Next(Deck.Cards.Count);
            return r;
        }
    }
}
