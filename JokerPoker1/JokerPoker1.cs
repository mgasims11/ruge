﻿namespace JokerPoker1
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
    using ruge.cardEngine.Builders;
    using CardEngine.Logic.Builders;
    using ruge.cardEngine;


    //"CLEAR UP AND STREAMLINE RUGE/CARD INTEERFACE"
    //"Problem causing incorrect card to be retrieved for orientation"
    // TO DO:
    // REFACTOR: Replace ALL discrete X and Y values for postion and size with XYPairs    
    // Remember to test true images for mouseover events hover, down, and idle
    // Implement disabled, visible

    public class JokerPoker : IGame
    {     
        public RugeTableManagerRenderer Renderer;
        public TableManager _tableManager;

        public Deck _dealerDeck = null;
        public Deck _playerDeck = null;

        public XYPair _CardSize = new XYPair(1.0, 1.375);

        public JokerPoker()
        {
            Renderer = new RugeTableManagerRenderer(7,4);

            _tableManager = new TableManager(
                TableBuilder.Create()
                    .SetTableName("Joker Poker")
                    .SetImageUri(@"C:\data\ruge\ruge.cardEngine\images\03H.jpg"),
                Renderer
            );
        }

        public void Start()
        {
            _tableManager.ClearTable();

            _dealerDeck = DeckBuilder.Create()
                .DeckName("Dealer Deck")
                .Options(new DeckOptions(52));

            _playerDeck = DeckBuilder.Create()
                .DeckName("Player Deck")
                .Options(new DeckOptions(5));

            for (int i = 0; i <= 5; i++)
            {
                Renderer.AddCardControl(
                    CardControlBuilder.Create()
                        .SetDeck(_playerDeck)
                        .SetIndex(i)
                        .SetLocation(new XYPair(i * _CardSize.X, 2))
                        .SetSize(_CardSize)
                        );
            };

            _tableManager.AddDecksToTable(_dealerDeck, _playerDeck);

            _tableManager.FillDeck(_dealerDeck);
            _tableManager.ShuffleDeck(_dealerDeck);

            _tableManager.DealCardsFromTopToTop(_dealerDeck, _playerDeck, 5);

            Renderer.CanvasManager.UserActionEvent += CanvasManager_UserActionEvent;

            Renderer.SendEngineActionSet();
        }

        private void CanvasManager_UserActionEvent(object sender, UserActionEventArgs e)
        {
            var control = (Renderer.CanvasManager.GetControl(e.UserAction.ControlId)) as CardControl;
            var card = control.Deck.Cards[control.Index];

            //var card = _rugeTableManagerRenderer.GetCardFromControlId(e.UserAction.ControlId);
            int index = 0;
            Deck deck;
            if (Renderer.FindCardInDecks(card, out deck, out index))
            {
                _tableManager.ChangeOrientation(deck, card, Orientations.FaceDown);
                Renderer.SendEngineActionSet();
            }
        }
    }
}

