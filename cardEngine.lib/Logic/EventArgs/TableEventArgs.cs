namespace CardEngine.Logic.EventArgs
{
    using System;
    using CardEngine.Model;
    using CardEngine.Logic.Enums;
    
    public class TableEventArgs : EventArgs
    {

        public TableEventTypes TableEventType { get; private set; }
        public Guid TableId { get; set; }

        public TableEventArgs(Guid tableId)
        {
            TableId = tableId;
        }

        public TableEventArgs(TableEventTypes tableEventType, Guid tableId)
        {
            TableEventType = tableEventType;
            TableId = tableId;
        }
    }
}