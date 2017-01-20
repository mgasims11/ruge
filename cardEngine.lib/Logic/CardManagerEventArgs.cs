namespace CardEngine.Logic
{
    using System;
    using CardEngine.Model;

    public class CardManagerEventArgs : EventArgs
    {
        public Guid DeckId {get;set;}
        public Guid CardId {get;set;}

        public CardManagerEventArgs(Guid deckId, Guid cardId)
        {
            DeckId = deckId;
            CardId = cardId;
        }
    }
}