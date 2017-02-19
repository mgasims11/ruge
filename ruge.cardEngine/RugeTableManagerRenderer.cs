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

        public bool FindCardInDecks(Guid cardId, out Guid deckId, out int index)
        {
            var result = false;

            index = 0;
            deckId = Guid.Empty;
                                   
            foreach(var deck in _tablemanager.Table.Decks)
            {                
                if (deck.Cards.Exists(c => c.CardId == cardId))
                {
                    result = true;
                    deckId = deck.DeckId;
                    var card = deck.Cards.FirstOrDefault(c => c.CardId == cardId);
                    index = deck.Cards.IndexOf(card);
                }
            }
            
            return result;
        }

        public CardControl GetControlForCard(Guid cardId)
        {
            CardControl cardControl = null;
            var deckId = Guid.Empty;
            var index = 0;

            if (FindCardInDecks(cardId,out deckId, out index))
            {
                cardControl = CardControls.FirstOrDefault(c => c.DeckId == deckId && c.Index == index);
            }

            return cardControl;
        }

        public Card GetCardFromControlId(string cardControlId)
        {
            var cardControl = CardControls.FirstOrDefault(cc => cc.ControlId == cardControlId);
            if (cardControl != null)
            {
                return _tablemanager.GetDeck(cardControl.DeckId).Cards[cardControl.Index];
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

        private void RenderCard(Guid deckId, Card card)
        {
            var deck = _tablemanager.GetDeck(deckId);
            var cardControl = CardControls.FirstOrDefault(cc => cc.DeckId == deck.DeckId && cc.Index == deck.Cards.IndexOf(card));
            if (cardControl == null) return;

            cardControl.EnableState = EnableStates.Enabled;
            cardControl.ImageUri = String.Format(@"C:\data\ruge\ruge.cardEngine\images\{0}.jpg",((int)card.Rank).ToString("00") + card.Suit.ToString().Substring(0,1));            

            CanvasManager.AddEngineAction(cardControl, EngineActionType.Create);
        }

        public void CardAddedToDeck(Guid deckId, Card card, int index)
        {
        }

        public void CardBeingRemovedFromDeck(Guid deckId, Guid cardId)
        {
        }

        public void CardChangedOrientation(Guid cardId, Orientations orientation)
        {            
            OrientCard(cardId, orientation);
        }

        public void OrientCard(Guid cardId, Orientations orientation)
        {
            Guid deckId = Guid.Empty;
            int index = 0;
            Card card = null;

            if (FindCardInDecks(cardId, out deckId, out index))
            {
                card = GetDeck(deckId).Cards[index];
            }

            var cardControl = GetControlForCard(cardId);
           
            switch (orientation)
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
        }

        public void CardChangingOrientation(Guid cardId, Orientations orientation)
        {

        }

        public void CardMoved(Guid sourceDeckId, Guid sourcecardId, Guid destinationDeckId)
        {
        }

        public void CardMoving(Guid sourceDeckId, Guid sourcecardId, Guid destinationDeckId)
        {
        }

        public void CardRemovedFromDeck(Guid deckId, Guid cardId)
        {
            RenderCard(deckId, _tablemanager.GetCard(deckId,cardId));
        }

        public void CardsSwappedInDeck(Guid soureceDeckId, Guid sourcecardId, Guid destinationDeckId, Guid destinationCardId)
        {
        }

        public void CardsSwappingInDeck(Guid soureceDeckId, Guid sourcecardId, Guid destinationDeckId, Guid destinationCardId)
        {

        }

        public void DeckAddedToTable(Guid tableId, Deck deck)
        {
            
        }

        public void DeckBeingRemovedFromTable(Guid tableId, Guid deckId)
        {

        }

        public void DeckCleared(Guid deckId)
        {

        }

        public void DeckClearing(Guid deckId)
        {

        }

        public void DeckFilled(Guid deckId)
        {

        }

        public void DeckFilling(Guid deckId)
        {

        }

        public void DeckRemovedFromTable(Guid tableId, Guid deckId)
        {

        }

        public void DeckShuffled(Guid deckId)
        {

        }

        public void DeckShuffling(Guid deckId)
        {

        }

        public void TableCleared(Guid tableId)
        {
            CanvasManager.CreateCanvas(_height, _width);
            CanvasManager.AddEngineAction(CanvasManager.Canvas, EngineActionType.Create);
        }

        public void TableClearing(Guid tableId)
        {
        }

        public void SendEngineActionSet()
        {
            foreach (var deck in TableManager.Table.Decks)
            {
                foreach (var card in deck.Cards)
                {
                    RenderCard(deck.DeckId, card);
                }
            }
       
            CanvasManager.SendEngineActionSet();
        }

    }
}
