namespace CardEngine.Logic.EventArgs
{
    using System;
    using CardEngine.Model;
    using CardEngine.Logic.Enums;

    public class CardEventArgs : EventArgs
    {
        public Guid CardId {get;set;}

        public CardEventArgs(CardEventTypes eventType, Guid cardId)
        {
            CardId = cardId;
        }
    }
}