namespace CardEngine.Logic
{
    using System;
    using CardEngine.Model;
    using CardEngine.Logic;
    using CardEngine.Logic.EventArgs;
    using CardEngine.Logic.Enums;
       
    public partial class TableManager
    {
        public delegate void TableEventHandler(object sender, TableEventArgs e);
        public event TableEventHandler TableEvent;

        public Table Table {get;set;}

        public TableManager()
        {
            Table = new Table();
        }

        private void RaiseTableEvent(TableEventTypes eventType, Guid tableId, Guid deckId)
        {
            if (TableEvent != null)
            {
                TableEvent(this, new TableEventArgs(eventType,tableId, deckId));
            }
        }

        private void RaiseTableEvent(TableEventTypes eventType, Guid tableId)
        {
            if (TableEvent != null)
            {
                TableEvent(this, new TableEventArgs(eventType, tableId));
            }
        }

        public void ClearTable()
        {

            RaiseTableEvent(TableEventTypes.TableClearing, Table.TableId);
           
            Table.Decks.Clear();

            RaiseTableEvent(TableEventTypes.TableCleared, Table.TableId);
        }

        public void AddDeckToTable(Deck deck)
        {
            RaiseTableEvent(TableEventTypes.DeckAddingToTable, Table.TableId, deck.DeckId);

            Table.Decks.Add(deck);

            RaiseTableEvent(TableEventTypes.TableClearing, Table.TableId, deck.DeckId);

            RaiseTableEvent(TableEventTypes.DeckAddedToTable, Table.TableId, deck.DeckId);
        }

        public void RemoveDeckFromTable(Deck deck)
        {          
            RaiseTableEvent(TableEventTypes.DeckBeingRemoved, deck.DeckId);
           
            Table.Decks.Remove(deck);

            RaiseTableEvent(TableEventTypes.DeckRemovedFromTable, deck.DeckId);
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