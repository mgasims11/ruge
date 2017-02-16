namespace JokerPoker1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ruge.lib;
    using ruge.lib.logic;
    using ruge.lib.model;
    using ruge.lib.model.controls;
    using ruge.lib.model.engine;
    using ruge.lib.model.controls.interfaces;
    using ruge.lib.model.user;
    using ruge.cardEngine;
    using CardEngine.Logic;
    using CardEngine.Model;
    
    public class JokerPoker : IGame
    {     
        public RugeTableManagerRenderer _rugeTableManagerRenderer;
        public TableManager _tableManager;

        public Deck _dealerDeck = null;
        public Deck _playerDeck = null;

        public CanvasManager CanvasManager
        {
            get { return _rugeTableManagerRenderer.CanvasManager; }
        }

        public JokerPoker()
        {
            _rugeTableManagerRenderer = new RugeTableManagerRenderer();
            _tableManager = new TableManager(_rugeTableManagerRenderer);
            _tableManager.Table.TableName = "Joker Poker";
            _tableManager.Table.ImageUri = @"C:\data\ruge\ruge.cardEngine\images\03H.jpg";
        }

        public void Start()
        {
            _tableManager.ClearTable();

            _dealerDeck = new Deck()
            {
                Visible = false,
                DeckName = "Dealer Deck",
                Options = new DeckOptions(52)
            };

            _playerDeck = new Deck()
            {
                Visible = true,
                DeckName = "Player Deck",
                Options = new DeckOptions(5)
            };

            _rugeTableManagerRenderer.CreateCardControl(_playerDeck.DeckId, 10, 30, 10, 20, 0);
            _rugeTableManagerRenderer.CreateCardControl(_playerDeck.DeckId, 30, 30, 10, 20, 1);
            _rugeTableManagerRenderer.CreateCardControl(_playerDeck.DeckId, 50, 30, 10, 20, 2);
            _rugeTableManagerRenderer.CreateCardControl(_playerDeck.DeckId, 70, 30, 10, 20, 3);
            _rugeTableManagerRenderer.CreateCardControl(_playerDeck.DeckId, 90, 30, 10, 20, 4);

            _tableManager.AddDecksToTable(_dealerDeck, _playerDeck);
            _tableManager.FillDeck(_dealerDeck.DeckId);
            _tableManager.ShuffleDeck(_dealerDeck.DeckId);
            _tableManager.MoveCardToTopOfDeck(_dealerDeck.DeckId, _playerDeck.DeckId, 0);
            _tableManager.MoveCardToTopOfDeck(_dealerDeck.DeckId, _playerDeck.DeckId, 0);
            _tableManager.MoveCardToTopOfDeck(_dealerDeck.DeckId, _playerDeck.DeckId, 0);
            _tableManager.MoveCardToTopOfDeck(_dealerDeck.DeckId, _playerDeck.DeckId, 0);
            _tableManager.MoveCardToTopOfDeck(_dealerDeck.DeckId, _playerDeck.DeckId, 0);

            _rugeTableManagerRenderer.SendEngineActionSet();
        }
    }
}

