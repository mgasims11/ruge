namespace ruge.cardEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ruge.cardEngine;
    using ruge.lib.logic;
    using ruge.lib.model;
    using ruge.lib.model.controls;
    using ruge.lib.model.engine;
    using ruge.lib.model.user;
    using CardEngine;
    using CardEngine.Logic;
    using CardEngine.Model;
    using ruge.cardEngine.Builders;

    public class RugeTableManagerRenderer : ITableManagerRenderer
    {
        public CanvasManager CanvasManager = null;
        private TableManager _tablemanager;

        private double _height = 0;
        private double _width = 0;

        public TableManager TableManager
        {
            get { return _tablemanager; }
            set { _tablemanager = value; }
        }

        public List<CardControl> CardControls = null;

        public RugeTableManagerRenderer(double height, double width)
        {
            _height = height;
            _width = width;
            CanvasManager = new CanvasManager();
            CardControls = new List<CardControl>();
        }

        public Deck GetDeck(Guid deckId)
        {
            return _tablemanager.Table.Decks.FirstOrDefault(d => d.DeckId == deckId);
        }

        public bool FindCardInDecks(Card card, out Deck deckOut, out int index)
        {
            index = 0;
            deckOut = null;

            foreach (var deck in _tablemanager.Table.Decks)
            {
                if (deck.Cards.Contains(card))
                {
                    deckOut = deck;
                    index = deck.Cards.IndexOf(card);
                    return true;
                }
            }

            return false;
        }

        public CardControl GetControlForCard(Card card)
        {
            CardControl cardControl = null;
            Deck deck;
            var index = 0;

            if (FindCardInDecks(card, out deck, out index))
            {
                cardControl = CardControls.FirstOrDefault(c => c.Deck.DeckId == deck.DeckId && c.Index == index);
            }

            return cardControl;
        }

        public Card GetCardFromControlId(string cardControlId)
        {
            var cardControl = CardControls.FirstOrDefault(cc => cc.ControlId == cardControlId);
            if (cardControl != null)
            {
                return cardControl.Deck.Cards[cardControl.Index];
            }
            else return null;
        }

        public void AddCardControl(CardControl cardControl)
        {
            CardControls.Add(cardControl);
        }

        public void RemoveCardControl(Guid deckId, XYPair coordinates, int index)
        {
            CardControls.RemoveAt(index);
        }

        private void RenderCard(Deck deck, Card card)
        {
            var cardControl = CardControls.FirstOrDefault(cc => cc.Deck.DeckId == deck.DeckId && cc.Index == deck.Cards.IndexOf(card));
            if (cardControl == null) return;

            cardControl.EnableState = EnableStates.Enabled;

            switch (card.Orientation)
            {
                case Orientations.FaceUp:
                    cardControl.ImageUri = String.Format(@"C:\data\ruge\ruge.cardEngine\images\{0}.jpg", ((int)card.Rank).ToString("00") + card.Suit.ToString().Substring(0, 1));
                    CanvasManager.AddEngineAction(cardControl, EngineActionType.Update);
                    break;
                case Orientations.FaceDown:
                    cardControl.ImageUri = (@"C:\data\ruge\ruge.cardEngine\images\BackBlue.jpg");
                    CanvasManager.AddEngineAction(cardControl, EngineActionType.Update);
                    break;
            }
            CanvasManager.AddEngineAction(cardControl, EngineActionType.Create);
        }

        public void CardAddedToDeck(Deck deck, Card card, int index)
        {
        }

        public void CardBeingRemovedFromDeck(Deck deck, Card card)
        {
        }

        public void CardChangedOrientation(Card card, Orientations orientation)
        {            
            OrientCard(card, orientation);
        }

        public void OrientCard(Card card, Orientations orientation)
        {
            //var cardControl = GetControlForCard(card);
           
            //switch (orientation)
            //{
            //    case Orientations.FaceUp:
            //        cardControl.ImageUri = String.Format(@"C:\data\ruge\ruge.cardEngine\images\{0}.jpg", ((int)card.Rank).ToString("00") + card.Suit.ToString().Substring(0, 1));
            //        CanvasManager.AddEngineAction(cardControl, EngineActionType.Update);
            //        break;
            //    case Orientations.FaceDown:
            //        cardControl.ImageUri = (@"C:\data\ruge\ruge.cardEngine\images\BackBlue.jpg");
            //        CanvasManager.AddEngineAction(cardControl, EngineActionType.Update);
            //        break;
            //}
        }

        public void CardChangingOrientation(Card card, Orientations orientation)
        {

        }

        public void CardMoved(Deck sourceDeck, Card sourcecard, Deck destinationDeck)
        {
        }

        public void CardMoving(Deck sourceDeck, Card sourcecard, Deck destinationDeck)
        {
        }

        public void CardRemovedFromDeck(Deck deck, Card card)
        {
            RenderCard(deck, card);
        }

        public void CardsSwappedInDeck(Deck soureceDeckId, Card sourcecardId, Deck destinationDeckId, Card destinationCardId)
        {
        }

        public void CardsSwappingInDeck(Deck soureceDeckId, Card sourcecardId, Deck destinationDeckId, Card destinationCardId)
        {

        }

        public void DeckAddedToTable(Table table, Deck deck)
        {
            
        }

        public void DeckBeingRemovedFromTable(Table table, Deck deck)
        {

        }

        public void DeckCleared(Deck deck)
        {

        }

        public void DeckClearing(Deck deck)
        {

        }

        public void DeckFilled(Deck deck)
        {

        }

        public void DeckFilling(Deck deck)
        {

        }

        public void DeckRemovedFromTable(Table tableId, Deck deck)
        {

        }

        public void DeckShuffled(Deck deck)
        {

        }

        public void DeckShuffling(Deck deck)
        {

        }

        public void TableCleared(Table table)
        {
            CanvasManager.CreateCanvas(_height, _width);
            CanvasManager.AddEngineAction(CanvasManager.Canvas, EngineActionType.Create);
        }

        public void TableClearing(Table table)
        {
        }

        public void SendEngineActionSet()
        {
            foreach (var deck in TableManager.Table.Decks)
            {
                foreach (var card in deck.Cards)
                {
                    RenderCard(deck, card);
                }
            }
       
            CanvasManager.SendEngineActionSet();
        }

        public void CardBeingRemovedFromDeck(Deck deck, Guid cardId)
        {
            throw new NotImplementedException();
        }
    }
}
