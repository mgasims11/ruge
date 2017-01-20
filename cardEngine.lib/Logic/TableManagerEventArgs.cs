namespace CardEngine.Logic
{
    using System;
    using CardEngine.Model;

    public class TableManagerEventArgs : EventArgs
    {
        public Guid TableId { get; set; }
        public TableManagerEventArgs(Guid tableId)
        {
            TableId = tableId;
        }
    }
}