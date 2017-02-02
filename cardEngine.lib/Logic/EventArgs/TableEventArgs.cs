namespace CardEngine.Logic.EventArgs
{
    using System;
    using CardEngine.Model;
    using CardEngine.Logic.Enums;
    
    public class TableEventArgs : EventArgs
    {
        public TableEventTypes TableEventType { get; private set; }
        public Guid TableId { get; set; }
        public Guid DeckId { get; set; }

        public TableEventArgs(TableEventTypes tableEventType, Guid tableId, Guid deckId)
        {
            TableId = tableId;
            DeckId = deckId;
        }
        public TableEventArgs(TableEventTypes tableEventType, Guid tableId)
        {
            TableId = tableId;
            DeckId = Guid.Empty;
        }
    }
}