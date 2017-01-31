namespace CardEngine.Logic.EventArgs
{
    using System;
    using CardEngine.Logic.Enums;

    public class DeckEventArgs : EventArgs
    {
        public DeckEventTypes DeckEventType { get; private set; }
        public Guid DeckId { get; private set; }

        public DeckEventArgs(Guid deckId)
        {
            DeckId = deckId;
        }

        public DeckEventArgs(DeckEventTypes deckEventType, Guid deckId)
        {
            DeckEventType = deckEventType;
            DeckId = deckId;
        }
    }
}