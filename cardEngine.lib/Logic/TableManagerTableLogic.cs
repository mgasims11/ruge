namespace CardEngine.Logic
{
    using System;
    using CardEngine.Model;
    using CardEngine.Logic;
       
    public partial class TableManager
    {
        public Table Table {get;set;}
        public ITableManagerRenderer _renderer = null;

        public TableManager(Table table, ITableManagerRenderer renderer)
        {
            if (renderer != null)
            {
                _renderer = renderer;
                _renderer.TableManager = this;
            }
        
            Table = table;
        }

        public void ClearTable()
        {
            if (_renderer != null) { _renderer.TableClearing(Table); }          
            Table.Decks.Clear();
            if (_renderer != null) { _renderer.TableCleared(Table); }
        }

        public void AddDeckToTable(Deck deck)
        {          
            Table.Decks.Add(deck);
            if (_renderer != null) { _renderer.DeckAddedToTable(Table, deck); }
        }

        public void RemoveDeckFromTable(Deck deck)
        {
            if (_renderer != null) { _renderer.DeckBeingRemovedFromTable(Table, deck); }           
            Table.Decks.Remove(deck);
            if (_renderer != null) { _renderer.DeckRemovedFromTable(Table, deck); }        
        }
 
        public void AddDecksToTable(params Deck[] decks)
        {            
            foreach(var deck in decks )
            {                
                AddDeckToTable(deck);            
            }
        }
    }
}