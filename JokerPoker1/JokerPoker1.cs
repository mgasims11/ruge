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

    // TO DO:
    // REFACTOR: Replace ALL discrete X and Y values for postion and size with XYPairs    
    // Remember to test true images for mouseover events hover, down, and idle
    // Implement disabled, visible

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
            _rugeTableManagerRenderer = new RugeTableManagerRenderer(7,4);
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

            _rugeTableManagerRenderer.CreateCardControl(_playerDeck.DeckId, 1, 2, 1, 1.375, 0);
            _rugeTableManagerRenderer.CreateCardControl(_playerDeck.DeckId, 2, 2, 1, 1.375, 1);
            _rugeTableManagerRenderer.CreateCardControl(_playerDeck.DeckId, 3, 2, 1, 1.375, 2);
            _rugeTableManagerRenderer.CreateCardControl(_playerDeck.DeckId, 4, 2, 1, 1.375, 3);
            _rugeTableManagerRenderer.CreateCardControl(_playerDeck.DeckId, 5, 2, 1, 1.375, 4);

            _tableManager.AddDecksToTable(_dealerDeck, _playerDeck);
            _tableManager.FillDeck(_dealerDeck.DeckId);
            _tableManager.ShuffleDeck(_dealerDeck.DeckId);
            _tableManager.MoveCardToTopOfDeck(_dealerDeck.DeckId, _playerDeck.DeckId, 0);
            _tableManager.MoveCardToTopOfDeck(_dealerDeck.DeckId, _playerDeck.DeckId, 0);
            _tableManager.MoveCardToTopOfDeck(_dealerDeck.DeckId, _playerDeck.DeckId, 0);
            _tableManager.MoveCardToTopOfDeck(_dealerDeck.DeckId, _playerDeck.DeckId, 0);
            _tableManager.MoveCardToTopOfDeck(_dealerDeck.DeckId, _playerDeck.DeckId, 0);

            _rugeTableManagerRenderer.CanvasManager.UserActionEvent += CanvasManager_UserActionEvent;

            _rugeTableManagerRenderer.SendEngineActionSet();
        }

        private void CanvasManager_UserActionEvent(object sender, UserActionEventArgs e)
        {
            var cardid = _rugeTableManagerRenderer.GetCardFromControlId(e.UserAction.ControlId);
        }
    }
}

