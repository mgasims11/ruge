namespace CardEngine.Logic
{
    using System;
    using CardEngine.Model;
    using CardEngine.Logic;
    using CardEngine.Logic.EventArgs;
    using CardEngine.Logic.Enums;
       
    public partial class TableManager
    {
        public delegate void TableClearingEventHandler(object sender, TableEventArgs e);
        public delegate void TableClearedEventHandler(object sender, TableEventArgs e);

        public event TableClearingEventHandler TableClearingEvent;
        public event TableClearedEventHandler TableClearedEvent;
        
        public Table Table {get;set;}

        public TableManager()
        {
            Table = new Table();
        }

        public void ClearTable()
        {
            if (TableClearingEvent != null)
            {
                TableClearingEvent(this, new TableEventArgs(TableEventTypes.TableClearing, Table.TableId));
            }

            Table.Decks.Clear();

            if (TableClearedEvent != null)
            {
                TableClearedEvent(this, new TableEventArgs(TableEventTypes.TableCleared, Table.TableId));
            }
        }

        public void AddDeckToTable(Deck deck)
        {
            if (DeckAddingToTableEvent != null)
            {
                DeckAddingToTableEvent(this, new DeckEventArgs(DeckEventTypes.DeckAddingToTable, deck.DeckId));
            }

            Table.Decks.Add(deck);

            if (DeckAddedToTableEvent != null)
            {
                DeckAddedToTableEvent(this, new DeckEventArgs(DeckEventTypes.DeckAddedToTable, deck.DeckId));
            }
        }

        public void RemoveDeckFromTable(Deck deck)
        {
            if (DeckBeingRemovedFromTableEvent != null)
            {
                DeckBeingRemovedFromTableEvent(this, new DeckEventArgs(DeckEventTypes.DeckBeingRemoved, deck.DeckId));
            }

            Table.Decks.Remove(deck);

            if (DeckRemovedFromTableEvent != null)
            {
                DeckRemovedFromTableEvent(this, new DeckEventArgs(DeckEventTypes.DeckRemovedFromTable, deck.DeckId));
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