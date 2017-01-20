namespace CardEngine.Logic
{
    using System;

    public class DeckManagerEventArgs : EventArgs
    {
        public Guid DeckId { get; set; }
        public DeckManagerEventArgs(Guid deckId)
        {
            DeckId = deckId;
        }
    }
}