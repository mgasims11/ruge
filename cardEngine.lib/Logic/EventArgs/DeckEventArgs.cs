namespace CardEngine.Logic.EventArgs
{
    using System;
    using CardEngine.Logic.Enums;

    public class DeckEventArgs : EventArgs
    {
        public DeckEventTypes DeckEventType { get; private set; }        
        public Guid DeckId { get; set; }
        public Guid CardId { get; set; }

        public DeckEventArgs(DeckEventTypes deckEventType, Guid deckId, Guid cardId)
        {            
            DeckId = deckId;
            CardId = cardId;
        }
        public DeckEventArgs(DeckEventTypes decjEventType, Guid deckId)
        {
            DeckId = deckId;            
            CardId = Guid.Empty;
        }
    }
}