using System;
using ProCardLib.DataModel;

namespace ProCardLib.Logic
{   
    public class TableEventArgs : EventArgs
    {
        public Guid TableId {get;set;}
        public TableEventArgs(Guid tableId)
        {
            this.TableId = tableId;    
        }
    }
    public class DeckEventArgs : EventArgs
    {
        public Guid DeckId {get;set;}
        public DeckEventArgs(Guid deckId)
        {            
            this.DeckId = deckId;
        }
    }
    public class CardEventArgs : EventArgs
    {
        public Guid DeckId {get;set;}
        public Guid CardId {get;set;}
        public CardEventArgs(Guid deckId, Guid cardId)
        {
            this.DeckId = deckId;
            this.CardId = cardId;
        }
    }

    public class CardMovementEventArgs : EventArgs
    {
        public Deck Deck {get;set;}
        public Card Card {get;set;}
        public CardMovementEventArgs(Deck deck, Card card)
        {
            this.Deck = deck;
            this.Card = card;
        }
    }

}