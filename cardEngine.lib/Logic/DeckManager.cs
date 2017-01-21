﻿namespace CardEngine.Logic
{
    using System;
    using System.Collections.Generic;
    using CardEngine.Model;
    using CardEngine.Logic;

    public class DeckManager
    {
        public delegate void DeckClearingEventHandler(object sender, DeckManagerEventArgs e);
        public delegate void DeckClearedEventHandler(object sender, DeckManagerEventArgs e);
        public delegate void DeckShufflingEventHandler(object sender, DeckManagerEventArgs e);
        public delegate void DeckShuffledEventHandler(object sender, DeckManagerEventArgs e);
        public delegate void DeckFillingEventHandler(object sender, DeckManagerEventArgs e);
        public delegate void DeckFilledEventHandler(object sender, DeckManagerEventArgs e);
        public delegate void CardAddingToDeckEventHandler(object sender, DeckManagerEventArgs e);
        public delegate void CardAddedToDeckEventHandler(object sender, DeckManagerEventArgs e);
        public delegate void CardRemovingFromDeckEventHandler(object sender, DeckManagerEventArgs e);
        public delegate void CardRemovedFromDeckEventHandler(object sender, DeckManagerEventArgs e);

        public event DeckClearingEventHandler DeckClearingEvent;
        public event DeckClearedEventHandler DeckClearedEvent;
        public event DeckClearedEventHandler DeckShufflingEvent;
        public event DeckShuffledEventHandler DeckShuffledEvent;
        public event DeckFillingEventHandler DeckFillingEvent;
        public event DeckFilledEventHandler DeckFilledEvent;
        public event CardAddingToDeckEventHandler CardAddingToDeckEvent;
        public event CardAddedToDeckEventHandler CardAddedToDeckEvent;
        public event CardRemovingFromDeckEventHandler CardRemovingFromDeckEvent;
        public event CardRemovedFromDeckEventHandler CardRemovedFromDeckEvent;

        public Deck Deck;

        public DeckManager()
        {
            Deck = new Deck();
        }

        public static DeckManager Create()
        {
            return new DeckManager();
        }

        public DeckManager DeckName(string deckName)
        {
            Deck.DeckName = deckName;
            return this;
        }

        public DeckManager Options(DeckOptions deckOptions)
        {
            Deck.Options = deckOptions;
            return this;
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
