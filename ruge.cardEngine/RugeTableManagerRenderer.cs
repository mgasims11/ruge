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
    using ruge.cardEngine.logic;

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

        public List<CardControl> _cardControls = null;

        public RugeTableManagerRenderer(double height, double width)
        {
            _height = height;
            _width = width;
            CanvasManager = new CanvasManager();
            _cardControls = new List<CardControl>();
        }

        public string CreateCardControl(Guid deckId, double x, double y, double width, double height, int index)
        {
            var cardControl = CardControlMaker.Create()
                .DeckId(deckId)
                .Index(index)
                .Height(height)
                .Width(width)
                .X(x)
                .Y(y)
                .ControlState(ControlState.Enabled)
                .IsVisible(true);

            _cardControls.Add(cardControl);

            return cardControl.ControlId;
        }

        public void RemoveCardControl(Guid deckId, XYPair coordinates, int index)
        {
            _cardControls.RemoveAt(index);
        }

        private void RenderCard(Guid deckId, Card card)
        {
            var deck = _tablemanager.GetDeck(deckId);
            var cardControl = _cardControls.FirstOrDefault(cc => cc.DeckId == deck.DeckId && cc.Index == deck.Cards.IndexOf(card));
            if (cardControl == null) return;

            cardControl.ControlState = ControlState.Enabled;
            cardControl.ImageUri = String.Format(@"C:\data\ruge\ruge.cardEngine\images\{0}.jpg",((int)card.Rank).ToString("00") + card.Suit.ToString().Substring(0,1));            

            CanvasManager.AddEngineAction(cardControl, EngineActionType.Create);
        }

        public void CardAddedToDeck(Guid deckId, Card card, int index)
        {
        }

        public void CardBeingRemovedFromDeck(Guid deckId, Guid cardId)
        {
        }

        public void CardChangedOrientation(Guid cardId)
        {

        }

        public void CardChangingOrientation(Guid cardId)
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
