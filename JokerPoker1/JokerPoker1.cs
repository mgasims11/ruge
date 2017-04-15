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
        public XYPair _BetButtonSize = new XYPair(0.5, 0.5);
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
                  TextControlBuilder.Create()
                      .SetLocation(new XYPair(5.3, 1.9))
                      .SetSize(new XYPair(1.3, 0))
                      .SetName("betValue")
                      .SetText("Hello World!")
                      .SetMaxLength(3)
                      .SetFontSize(20)
                      );

            _canvasManager.Update(
                    ClickableControlBuilder.Create()
                        .SetLocation(new XYPair(6.0, 2.5))                     
                        .SetImageUri(@"C:\data\ruge\ruge.cardEngine\images\BetUp.png")
                        .SetBehavior(Behaviors.Size)
                        .SetSize(_BetButtonSize)
                        .SetName("betUpButton")
                        );

            _canvasManager.Update(
                    ClickableControlBuilder.Create()
                        .SetLocation(new XYPair(5.3, 2.5))
                        .SetImageUri(@"C:\data\ruge\ruge.cardEngine\images\BetDown.png")
                        .SetBehavior(Behaviors.Size)
                        .SetSize(_BetButtonSize)
                        .SetName("betDownButton")
                        );

            TurnPlayerCards(Orientations.FaceDown);
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
            _playerDeck.Cards.Clear();
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

                switch (clickableControl.Name)
                {
                    case "dealbutton":
                        PutGameIntoSelectMode();
                        break;
                    case "betUpButton":
                        BetUpButtonClicked();
                        break;
                    case "betDownButton":
                        BetDownButtonClicked();
                        break;
                }
            }
        }

        double _betNum = 0.50;
        private void AddBetButtonClicked(double increment)
        {
            var betValue = _canvasManager.GetElementByName("betValue") as TextControl;
                                   
            if (betValue != null)
            {
                _betNum += increment;

                betValue.Text = string.Format("{0:C}", _betNum);
                _canvasManager.Update(betValue);
                _canvasManager.SendEngineActionSet();
            }
        }

        private void BetUpButtonClicked()
        {
            if (_betNum < 10.00)
            AddBetButtonClicked(0.50);
        }

        private void BetDownButtonClicked()
        {
            if (_betNum > 0.50)
                AddBetButtonClicked(-0.50);
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
                    DealUnheldCards();
                    TestForWin();
                    PutGameIntoBetMode();
                }
            }
        }

        private void TestForWin()
        {
            var he = new HandEvaluator();
            var result = he.Evaluate(
                (int)_playerDeck.Cards[0].Rank, (int)_playerDeck.Cards[0].Suit,
                (int)_playerDeck.Cards[1].Rank, (int)_playerDeck.Cards[1].Suit,
                (int)_playerDeck.Cards[2].Rank, (int)_playerDeck.Cards[2].Suit,
                (int)_playerDeck.Cards[3].Rank, (int)_playerDeck.Cards[3].Suit,
                (int)_playerDeck.Cards[4].Rank, (int)_playerDeck.Cards[4].Suit
                );
        }

        private void DealUnheldCards()
        {
            var overlays = _canvasManager.GetElementsByNameMatch("overlay_");
            var i = 0;
            var cardControls = _canvasManager.GetElementsByNameMatch("card_");
            foreach (var overlay in overlays)
            {
                if (!overlay.IsVisible)
                {
                    _tableManager.RemoveCard(_playerDeck, i);
                    _tableManager.MoveCard(_dealerDeck, 0, _playerDeck, i);
                    ((CardControl)cardControls[i]).Card = _playerDeck.Cards[i];
                    ((CardControl)cardControls[i]).SetAllUris(GetCardImage(((CardControl)cardControls[i]).Card));
                }
                i++;
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

        private void EnableDealButton(bool enabled)
        {
            var dealButton = _canvasManager.GetElementByName("dealbutton");
            ((ClickableControl)dealButton).IsEnabled = enabled;
            _canvasManager.Update(dealButton);
        }

        private void EnableBetButtons(bool enabled)
        {
            var betUpButton = _canvasManager.GetElementByName("betDownButton");
            var betDownButton = _canvasManager.GetElementByName("betUpButton");
            ((ClickableControl)betUpButton).IsEnabled = enabled;
            ((ClickableControl)betDownButton).IsEnabled = enabled;
            _canvasManager.Update(betUpButton);
            _canvasManager.Update(betDownButton);
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

            cardControls.ForEach(c => {_canvasManager.Update(c);});
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
            EnableBetButtons(true);
            UpdatePlayerCards();
            _canvasManager.SendEngineActionSet();
        }

        private void PutGameIntoSelectMode()
        {
            CurrentGameMode = GameMode.SelectMode;
            EnableHoldButtons();
            EnableBetButtons(false);
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


