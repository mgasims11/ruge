namespace JokerPoker1
{
    using System;
    using ruge.lib.logic;
    using ruge.lib.model;
    using ruge.lib.model.controls;
    using ruge.lib.model.controls.interfaces;
    using ruge.lib.model.user;
    using ruge.cardEngine;
    using CardEngine.Logic;
    using CardEngine.Model;
    using ruge.cardEngine.Builders;
    using CardEngine.Logic.Builders;
    using System.Collections.Generic;
    using System.Linq;

    // TO DO:   
    // Implement rotation
    // Add textbox, textblock
    // Add sound
    // Add programmed delay

    public class JokerPoker : IGame
    {
        // Idle - Waiting to start game (end of last game?)
        // Hold buttons - disabled
        // Bet Up button / Bet Down button - Enabled
        // Deal Button - Enabled
        // create storyboard animation in XAML! apply to delayed controls
        public enum GameMode
        {
            BetMode,
            SelectMode
        }

        public CanvasManager _canvasManager = new CanvasManager();
        //public List<CardControl> _cardControls = new List<CardControl>();

        public GameMode CurrentGameMode { get; set; }

        public TableManager _tableManager;

        public Deck _dealerDeck = null;
        public Deck _playerDeck = null;

        public XYPair _CardSize = new XYPair(1.0, 1.375);
        public XYPair _HoldButtonSize = new XYPair(1.0, 0.5);
        public XYPair _HoldOverlaySize = new XYPair(1.0, 0);

        public JokerPoker()
        {
            _canvasManager.CreateCanvas(7, 4);
            _tableManager = new TableManager(TableBuilder.Create().SetTableName("Joker Poker"), null);
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

            _tableManager.AddDecksToTable(_dealerDeck, _playerDeck);
            _canvasManager.UserActionEvent += CanvasManager_UserActionEvent;

            DealCards();

            for (int i = 0; i <= 4; i++)
            {

                var cardControl = CardControlBuilder.Create()
                        .SetDeck(_playerDeck)
                        .SetCard(_playerDeck.Cards[i])
                        .SetIndex(i)
                        .SetLocation(new XYPair(i * (_CardSize.X + .03), 2))
                        .SetSize(_CardSize)
                        .SetOpacity(100)
                        .SetZIndex(51)
                        .SetIsVisible(true)
                        .SetBehavior(Behaviors.Static)
                        .SetName(String.Format("card_{0}", i))
                        .SetDelay(i * 500)
                        .SetAllUris(GetCardImage(_playerDeck.Cards[i]));

            _canvasManager.Update(cardControl);
            
            _canvasManager.Update(
                   ClickableControlBuilder.Create()
                       .SetLocation(new XYPair(i * (_CardSize.X + .03), 2.375))
                       .SetSize(_HoldOverlaySize)
                       .SetOpacity(100)
                       .SetZIndex(100)
                       .SetImageUri(@"C:\data\ruge\ruge.cardEngine\images\Hold.png")
                       .SetName(String.Format("overlay_{0}", i))
                       .SetBehavior(Behaviors.Static)
                       .SetIsVisible(false)
                       );
                
                _canvasManager.Update(
                    ClickableControlBuilder.Create()
                        .SetLocation(new XYPair(cardControl.Location.X, cardControl.Location.Y + cardControl.Size.Y + 0.03))
                        .SetImageUri(@"C:\data\ruge\ruge.cardEngine\images\HoldButton.png")
                        .SetSize(_HoldButtonSize)
                        .SetBehavior(Behaviors.Size)
                        .SetName(String.Format("holdbutton_{0}", i))
                        );
            };

            _canvasManager.Update(
                    ClickableControlBuilder.Create()
                        .SetLocation(new XYPair(5.3, 2 + _CardSize.Y + 0.03))
                        .SetImageUri(@"C:\data\ruge\ruge.cardEngine\images\DealButton.png")
                        .SetSize(_HoldButtonSize)
                        .SetBehavior(Behaviors.Size)
                        .SetName("dealbutton")
                        );

            _canvasManager.Update(
                    ClickableControlBuilder.Create()
                        .SetLocation(new XYPair(5.3, 2.5))
                        .SetImageUri(@"C:\data\ruge\ruge.cardEngine\images\BetButton.png")
                        .SetSize(_HoldButtonSize)
                        .SetName("betbutton")
                        );
            
            PutGameIntoBetMode();
        }

        private void CanvasManager_UserActionEvent(object sender, UserActionEventArgs e)
        {

            switch (CurrentGameMode)
            {
                case GameMode.BetMode:
                    BetModeEvent(e.Control, e.UserAction);
                    break;
                case GameMode.SelectMode:
                    SelectModeEvent(e.Control, e.UserAction);
                    break;
            }
        }

        private void DealCards()
        {
            if (_dealerDeck.Cards.Count < 5)
            {
                _tableManager.ClearDeck(_playerDeck);
                _tableManager.FillDeck(_dealerDeck);
                _tableManager.ShuffleDeck(_dealerDeck);
            }

            _tableManager.DealCardsFromTopToTop(_dealerDeck, _playerDeck, 5);

            var i = 0;
            foreach (CardControl cardControl in _canvasManager.GetElementsByNameMatch("card_"))
            {
                cardControl.Card = _playerDeck.Cards[i++];
            }

        }

        private void BetModeEvent(IElement element, UserAction userAction)
        {
            if (element is ClickableControl)
            {
                var clickableControl = element as ClickableControl;

                if (clickableControl.Name == "dealbutton")
                {
                    PutGameIntoSelectMode();
                }
            }
        }

        private void SelectModeEvent(IElement element, UserAction userAction)
        {
            if (element is ClickableControl)
            {
                var clickableControl = element as ClickableControl;
                if (clickableControl.Name.Contains("holdbutton_"))
                {
                    var overlayName = String.Format("overlay_{0}", clickableControl.Name.Split('_')[1]);
                    var overlay = _canvasManager.GetElementByName(overlayName);
                    overlay.IsVisible = !overlay.IsVisible;
                    _canvasManager.Update(overlay);
                    _canvasManager.SendEngineActionSet();
                }

                if (clickableControl.Name == "dealbutton")
                {


                    PutGameIntoBetMode();
                }
            }
        }
        private void DisableHoldButtons()
        {
            var e = _canvasManager.GetElementsByNameMatch("holdbutton_");
            e.ForEach(c => { ((ClickableControl)c).IsEnabled = false; });
        }
        private void EnableHoldButtons()
        {
            var e = _canvasManager.GetElementsByNameMatch("holdbutton_");
            e.ForEach(c => { ((ClickableControl)c).IsEnabled = true; _canvasManager.Update(c); });

        }

        private void EnableDealButton()
        {
            var dealButton = _canvasManager.GetElementByName("dealbutton");
            ((ClickableControl)dealButton).IsEnabled = true;
            _canvasManager.Update(dealButton);
        }
        private void DisableDealButton()
        {
            var dealButton = _canvasManager.GetElementByName("dealButton");
            ((ClickableControl)dealButton).IsEnabled = false;
            _canvasManager.Update(dealButton);
        }
        private void EnableBetButton()
        {
            var betButton = _canvasManager.GetElementByName("betbutton");
            ((ClickableControl)betButton).IsEnabled = true;
            _canvasManager.Update(betButton);
        }
        private void DisableBetButton()
        {
            var betButton = _canvasManager.GetElementByName("betbutton");
            ((ClickableControl)betButton).IsEnabled = false;
            _canvasManager.Update(betButton);
        }

        private void TurnPlayerCards(Orientations orientation)
        {

            var cardControls = _canvasManager.GetElementsByNameMatch("card_");

            cardControls.ForEach(c => {
                TurnCard((CardControl)c,orientation);
                });
        }

        private void UpdatePlayerCards()
        {
            var cardControls = _canvasManager.GetElementsByNameMatch("card_");

            cardControls.ForEach(c => {
            _canvasManager.Update(c);
            });
        }


        private void TurnCard(CardControl cardControl, Orientations orientation)
        {
            cardControl.Card.Orientation = orientation;
            cardControl.SetAllUris(GetCardImage(cardControl.Card));
        }

        private void TurnHeldCardsFaceDown()
        {
            var e = _canvasManager.GetElementsByNameMatch("overlay_");
            _playerDeck.Cards.ForEach(c => c.Orientation = Orientations.FaceDown);
        }

        private void PutGameIntoBetMode()
        {
            CurrentGameMode = GameMode.BetMode;
            DisableHoldButtons();
            EnableBetButton();
            EnableDealButton();
            TurnPlayerCards(Orientations.FaceDown);
            UpdatePlayerCards();
            _canvasManager.SendEngineActionSet();
        }

        private void PutGameIntoSelectMode()
        {
            CurrentGameMode = GameMode.SelectMode;
            EnableHoldButtons();
            EnableDealButton();
            DisableBetButton();
            DealCards();
            TurnPlayerCards(Orientations.FaceUp);
            UpdatePlayerCards();
            _canvasManager.SendEngineActionSet();
        }

        private string GetCardImage(Card card)
        {
            string url = String.Empty;

            switch (card.Orientation)
            {
                case Orientations.FaceUp:
                    url = String.Format(@"C:\data\ruge\ruge.cardEngine\images\{0}.jpg", ((int)card.Rank).ToString("00") + card.Suit.ToString().Substring(0, 1));
                    break;
                case Orientations.FaceDown:
                    url =  @"C:\data\ruge\ruge.cardEngine\images\BackBlue.jpg";
                    break;
            }
            return url;     
        }
    }
}


