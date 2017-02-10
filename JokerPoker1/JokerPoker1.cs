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
    
    public class JokerPoker : IGame
    {     
        public RugeTableManagerRenderer _rugeTableManagerRenderer;
        public TableManager _tableManager;

        public Deck _dealerDeck = null;
        public Deck _playerDeck = null;


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

            _tableManager.AddDecksToTable(_dealerDeck, _playerDeck);
            _tableManager.FillDeck(_dealerDeck.DeckId);
            _tableManager.ShuffleDeck(_dealerDeck.DeckId);
            _tableManager.MoveCardToTopOfDeck(_dealerDeck.DeckId, _playerDeck.DeckId, 0);
            _tableManager.MoveCardToTopOfDeck(_dealerDeck.DeckId, _playerDeck.DeckId, 0);
            _tableManager.MoveCardToTopOfDeck(_dealerDeck.DeckId, _playerDeck.DeckId, 0);
            _tableManager.MoveCardToTopOfDeck(_dealerDeck.DeckId, _playerDeck.DeckId, 0);
            _tableManager.MoveCardToTopOfDeck(_dealerDeck.DeckId, _playerDeck.DeckId, 0);

            //var playerDeckFrame = new DeckFrame()
            //{
            //    DeckId = _playerDeck.DeckId,
            //    CardLocations = new List<XYPair>()
            //    {
            //        new XYPair(10,10),
            //        new XYPair(15,10),
            //        new XYPair(30,10),
            //        new XYPair(35,10),
            //        new XYPair(40,10)
            //    }
            //};

            _rugeTableManagerRenderer.AddDeckFrame(playerDeckFrame);

            _rugeTableManagerRenderer.CanvasManager.SendEngineActionSet();
        }
    }
}

