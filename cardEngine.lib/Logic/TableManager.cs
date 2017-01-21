namespace CardEngine.Logic
{
    using System;
    using CardEngine.Model;
    using CardEngine.Logic;

    public class TableManager
    {
        public delegate void TableClearingEventHandler(object sender, TableManagerEventArgs e);
        public delegate void TableClearedEventHandler(object sender, TableManagerEventArgs e);
        public delegate void DeckAddingToTableEventHandler(object sender, DeckManagerEventArgs e);
        public delegate void DeckAddedToTableEventHandler(object sender, DeckManagerEventArgs e);
        public delegate void DeckBeingRemovedFromTableEventHandler(object sender, DeckManagerEventArgs e);
        public delegate void DeckRemovedFromTableEventHandler(object sender, DeckManagerEventArgs e);

        public event TableClearingEventHandler TableClearingEvent;
        public event TableClearedEventHandler TableClearedEvent;
        public event DeckAddingToTableEventHandler DeckAddingToTableEvent;
        public event DeckAddedToTableEventHandler DeckAddedToTableEvent;
        public event DeckBeingRemovedFromTableEventHandler DeckBeingRemovedFromTableEvent;
        public event DeckRemovedFromTableEventHandler DeckRemovedFromTableEvent;

        public Table Table {get;set;}

        public TableManager()
        {
            Table = new Table();
        }

        public static TableManager Create()
        {
            return new TableManager();
        }

        public TableManager TableName(string tableName)
        {
            Table.TableName = tableName;
            return this;
        }

        public TableManager Decks(params Deck[] decks)
        {
            AddDecksToTable(decks);
            return this;
        }

        public void ClearTable()
        {
            if (TableClearingEvent != null)
            {
                TableClearingEvent(this, new TableManagerEventArgs(Table.TableId));
            }

            Table.Decks.Clear();

            if (TableClearedEvent != null)
            {
                TableClearedEvent(this, new TableManagerEventArgs(Table.TableId));
            }
        }

        public void AddDeckToTable(Deck deck)
        {
            if (DeckAddingToTableEvent != null)
            {
                DeckAddingToTableEvent(this, new DeckManagerEventArgs(deck.DeckId));
            }

            Table.Decks.Add(deck);

            if (DeckAddedToTableEvent != null)
            {
                DeckAddedToTableEvent(this, new DeckManagerEventArgs(deck.DeckId));
            }
        }

        public void RemoveDeckFromTable(Deck deck)
        {
            if (DeckBeingRemovedFromTableEvent != null)
            {
                DeckBeingRemovedFromTableEvent(this, new DeckManagerEventArgs(deck.DeckId));
            }

            Table.Decks.Remove(deck);

            if (DeckRemovedFromTableEvent != null)
            {
                DeckRemovedFromTableEvent(this, new DeckManagerEventArgs(deck.DeckId));
            }
        }
 
        public void AddDecksToTable(params Deck[] decks)
        {            
            ClearTable();
            foreach(var deck in decks )
            {                
                AddDeckToTable(deck);            
            }
        }

    }
}