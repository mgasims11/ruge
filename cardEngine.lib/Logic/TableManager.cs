namespace CardEngine.Logic
{
    using System;
    using CardEngine.Model;

    public class TableManager
    {
        public EventHandler<TableManagerEventArgs> TableClearingEvent;
        public EventHandler<TableManagerEventArgs> TableClearedEvent;
        public EventHandler<DeckManagerEventArgs> DeckAddingToTableEvent;
        public EventHandler<DeckManagerEventArgs> DeckAddedToTableEvent;
        public EventHandler<DeckManagerEventArgs> DeckBeingRemovedFromTableEvent;
        public EventHandler<DeckManagerEventArgs> DeckRemovedFromTableEvent;


        public Table Table {get;set;}

        public TableManager()
        {
            this.Table = new Table();
        }

        public void ClearTable()
        {
            if (TableClearingEvent != null)
            {
                TableClearingEvent(this, new TableManagerEventArgs(Table.TableId));
            }
            Table.Decks.Clear();
            if (TableClearedEvent != null)
                TableClearedEvent(this,new TableManagerEventArgs(Table.TableId));
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

            Table.Decks.Add(deck);

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