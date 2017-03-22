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


    //"CLEAR UP AND STREAMLINE RUGE/CARD INTEERFACE"
    // TO DO:   
    // Implement disabled, rotation
    // Add textbox, textblock
    ///  Add sound
    ///  Add programmed delay
     
    public class JokerPoker : IGame
    {

        // Idle - Waiting to start game (end of last game?)
        // Hold buttons - disabled
        // Bet Up button / Bet Down button - Enabled
        // Deal Button - Enabled

        public enum GameMode
        {
            BetMode,
            SelectMode
        }

        public GameMode CurrentGameMode { get; set; }

        public RugeTableManagerRenderer Renderer;
        public TableManager _tableManager;

        public Deck _dealerDeck = null;
        public Deck _playerDeck = null;

        public XYPair _CardSize = new XYPair(1.0, 1.375);
        public XYPair _HoldButtonSize = new XYPair(1.0, 0.5);
        public XYPair _HoldOverlaySize = new XYPair(1.0, 0);      

        public JokerPoker()
        {
            Renderer = new RugeTableManagerRenderer(7,4);
            _tableManager = new TableManager(TableBuilder.Create().SetTableName("Joker Poker"),Renderer);
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

            for (int i = 0; i <= 4; i++)
            {
                CardControl cardControl = CardControlBuilder.Create()
                        .SetDeck(_playerDeck)
                        .SetIndex(i)
                        .SetLocation(new XYPair(i * (_CardSize.X + .03), 2))
                        .SetSize(_CardSize)
                        .SetOpacity(100)
                        .SetZIndex(51)
                        .SetIsVisible(true)
                        .SetBehavior(Behaviors.Static)
                        .SetName(String.Format("card_{0}", i));

                Renderer.AddCardControl(cardControl);

                Renderer.CanvasManager.Update(
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


                Renderer.CanvasManager.Update(                   
                    ClickableControlBuilder.Create()                                          
                        .SetLocation(new XYPair(cardControl.Location.X,cardControl.Location.Y + cardControl.Size.Y + 0.03))
                        .SetImageUri(@"C:\data\ruge\ruge.cardEngine\images\HoldButton.png")
                        .SetSize(_HoldButtonSize)
                        .SetBehavior(Behaviors.Size)
                        .SetName(String.Format("holdbutton_{0}", i))
                        );               
            };

            Renderer.CanvasManager.Update(
                    ClickableControlBuilder.Create()
                        .SetLocation(new XYPair(5.3, 2 + _CardSize.Y + 0.03))
                        .SetImageUri(@"C:\data\ruge\ruge.cardEngine\images\DealButton.png")
                        .SetSize(_HoldButtonSize)
                        .SetBehavior(Behaviors.Size)
                        .SetName("dealbutton")
                        );

            Renderer.CanvasManager.Update(
                    ClickableControlBuilder.Create()
                        .SetLocation(new XYPair(5.3, 2.5))
                        .SetImageUri(@"C:\data\ruge\ruge.cardEngine\images\BetButton.png")
                        .SetSize(_HoldButtonSize)
                        .SetName("betbutton")
                        );

            Renderer.CanvasManager.Update(
                  ClickableControlBuilder.Create()
                      .SetLocation(new XYPair(5.3, 1.3))
                      .SetImageUri(@"C:\data\ruge\ruge.cardEngine\images\Normal.png")
                      .SetImageUriHover(@"C:\data\ruge\ruge.cardEngine\images\Hover.png")
                      .SetImageUriDown(@"C:\data\ruge\ruge.cardEngine\images\Down.png")
                      .SetImageUriDisabled(@"C:\data\ruge\ruge.cardEngine\images\Disabled.png")
                      .SetBehavior(Behaviors.Image)
                      .SetSize(_HoldButtonSize)
                      .SetName("imagebutton")
                      
                      );

            _tableManager.AddDecksToTable(_dealerDeck, _playerDeck);
            Renderer.CanvasManager.UserActionEvent += CanvasManager_UserActionEvent;

            _tableManager.FillDeck(_playerDeck);
            TurnCards(Orientations.FaceDown);

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
                _tableManager.FillDeck(_dealerDeck);
                _tableManager.ShuffleDeck(_dealerDeck);
                _tableManager.DealCardsFromTopToTop(_dealerDeck, _playerDeck, 5);
            }

            PutGameIntoBetMode();            
        }
    
        private void BetModeEvent(IElement element, UserAction userAction)
        {
            if (element is ClickableControl)
            {
                var clickableControl = element as ClickableControl;

                if (clickableControl.Name == "dealbutton")
                {
                    DealCards();
                    TurnCards(Orientations.FaceUp);
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
                    var overlay = Renderer.CanvasManager.GetElementByName(overlayName);
                    overlay.IsVisible = !overlay.IsVisible;
                    Renderer.CanvasManager.Update(overlay);
                    Renderer.SendEngineActionSet();
                }

                if (clickableControl.Name == "dealbutton")
                {


                    PutGameIntoBetMode();
                }
            }
        }
        private void DisableHoldButtons()
        {
            var e = Renderer.CanvasManager.GetElementsByNameMatch("holdbutton_");
            e.ForEach(c => { ((ClickableControl)c).IsEnabled = false; });
        }
        private void EnableHoldButtons()
        {
            var e = Renderer.CanvasManager.GetElementsByNameMatch("holdbutton_");
            e.ForEach(c => { ((ClickableControl)c).IsEnabled = true; });
        }
        private void EnableDealButton()
        {
            var dealButton = Renderer.CanvasManager.GetElementByName("dealbutton");
            ((ClickableControl)dealButton).IsEnabled = true;
        }
        private void DisableDealButton()
        {
            var dealButton = Renderer.CanvasManager.GetElementByName("dealbutton");
            ((ClickableControl)dealButton).IsEnabled = false;
        }
        private void EnableBetButton()
        {
            var dealButton = Renderer.CanvasManager.GetElementByName("betbutton");
            ((ClickableControl)dealButton).IsEnabled = true;
        }
        private void DisableBetButton()
        {
            var dealButton = Renderer.CanvasManager.GetElementByName("betbutton");
            ((ClickableControl)dealButton).IsEnabled = false;
        }

        private void TurnCards(Orientations orientation)
        {
            _playerDeck.Cards.ForEach(c => c.Orientation = orientation);
        }

        private void TurnHeldCardsFaceDown()
        {
            var e = Renderer.CanvasManager.GetElementsByNameMatch("overlay_");
            _playerDeck.Cards.ForEach(c => c.Orientation = Orientations.FaceDown);
        }

        private void PutGameIntoBetMode()
        {
            CurrentGameMode = GameMode.BetMode;
            DisableHoldButtons();
            EnableBetButton();
            EnableDealButton();
            Renderer.SendEngineActionSet();
        }

        private void PutGameIntoSelectMode()
        {
            CurrentGameMode = GameMode.SelectMode;
            EnableHoldButtons();
            EnableDealButton();
            DisableBetButton();
            Renderer.SendEngineActionSet();
        }
    }
}


