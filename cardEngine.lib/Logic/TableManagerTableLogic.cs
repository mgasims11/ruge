namespace CardEngine.Logic
{
    using System;
    using CardEngine.Model;
    using CardEngine.Logic;
       
    public partial class TableManager
    {
        public Table Table {get;set;}
        public ITableManagerRenderer _renderer = null;

        public TableManager(ITableManagerRenderer renderer)
        {
            _renderer = renderer;
            Table = new Table();
        }

        public TableManager()
        {
            Table = new Table();
        }

        public void ClearTable()
        {
            if (_renderer != null) { _renderer.TableClearing(Table.TableId); }          
            Table.Decks.Clear();
            if (_renderer != null) { _renderer.TableCleared(Table.TableId); }
        }

        public void AddDeckToTable(Deck deck)
        {          
            Table.Decks.Add(deck);
            if (_renderer != null) { _renderer.DeckAddedToTable(Table.TableId, deck); }
        }

        public void RemoveDeckFromTable(Deck deck)
        {
            if (_renderer != null) { _renderer.DeckBeingRemovedFromTable(Table.TableId, deck.DeckId); }           
            Table.Decks.Remove(deck);
            if (_renderer != null) { _renderer.DeckRemovedFromTable(Table.TableId, deck.DeckId); }        
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