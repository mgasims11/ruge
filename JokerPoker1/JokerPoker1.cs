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
    using ruge.cardEngine.Builders;
    using CardEngine.Logic.Builders;
    using ruge.cardEngine;


    "CLEAR UP AND STREAMLINE RUGE/CARD INTEERFACE"
    "Problem causing incorrect card to be retrieved for orientation"
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

        public XYPair _CardSize = new XYPair(1.0, 1.375);

        public CanvasManager CanvasManager
        {
            get { return _rugeTableManagerRenderer.CanvasManager; }
        }

        public JokerPoker()
        {
            _rugeTableManagerRenderer = new RugeTableManagerRenderer(7,4);

            _tableManager = new TableManager(
                TableBuilder.Create()
                    .SetTableName("Joker Poker")
                    .SetImageUri(@"C:\data\ruge\ruge.cardEngine\images\03H.jpg"),
                _rugeTableManagerRenderer
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
                _rugeTableManagerRenderer.AddCardControl(
                    CardControlBuilder.Create()
                        .SetDeckId(_playerDeck.DeckId)
                        .SetIndex(i)
                        .SetLocation(new XYPair(i * _CardSize.X, 2))
                        .SetSize(_CardSize)
                        );
            };

            _tableManager.AddDecksToTable(_dealerDeck, _playerDeck);

            _tableManager.FillDeck(_dealerDeck.DeckId);
            _tableManager.ShuffleDeck(_dealerDeck.DeckId);

            _tableManager.DealCardsFromTopToTop(_dealerDeck.DeckId, _playerDeck.DeckId, 5);

            _rugeTableManagerRenderer.CanvasManager.UserActionEvent += CanvasManager_UserActionEvent;

            _rugeTableManagerRenderer.SendEngineActionSet();
        }

        private void CanvasManager_UserActionEvent(object sender, UserActionEventArgs e)
        {
           var card = _rugeTableManagerRenderer.GetCardFromControlId(e.UserAction.ControlId);
           Guid deckId = Guid.Empty;
           int index = 0;

            if (_rugeTableManagerRenderer.FindCardInDecks(card.CardId, out deckId, out index))
            {
                _tableManager.ChangeOrientation(deckId, card.CardId, Orientations.FaceDown);
                _rugeTableManagerRenderer.SendEngineActionSet();
            }
        }
    }
}

