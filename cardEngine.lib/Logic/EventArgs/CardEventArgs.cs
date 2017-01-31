namespace CardEngine.Logic.EventArgs
{
    using System;
    using CardEngine.Model;
    using CardEngine.Logic.Enums;

    public class CardEventArgs : EventArgs
    {
        public Guid DeckId {get;set;}
        public Guid CardId {get;set;}

        public CardEventArgs(Guid deckId, Guid cardId)
        {
            DeckId = deckId;
            CardId = cardId;
        }
    }
}