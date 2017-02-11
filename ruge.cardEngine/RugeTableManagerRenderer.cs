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
        
        public TableManager TableManager
        {
            get { return _tablemanager; }
            set { _tablemanager = value; }
        }

        public List<CardControl> _cardControls = null;

        public RugeTableManagerRenderer()
        {
            CanvasManager = new CanvasManager();
            _cardControls = new List<CardControl>();
        }

        public string AddCardControl(Guid deckId, int x, int y, int width, int height, int index)
        {
            var cardControl = CardControlMaker.Create()
                .DeckId(deckId)
                .Index(index)                
                .Height(height)
                .Width(width)
                .X(x)
                .Y(y)
                .ControlState(ControlState.Enabled)
                .IsVisible(true)
                ;

            _cardControls.Add(cardControl);

            return cardControl.ControlId;
        }

        public void RemoveCardControl(Guid deckId, XYPair coordinates, int index)
        {
            _cardControls.Add(new cardEngine.CardControl()
            {
                DeckId = deckId,
                Index = index
            });
        }

        private void RenderCard(Guid deckId, Card card)
        {
            var deck = _tablemanager.GetDeck(deckId);
            var cardControl = _cardControls.FirstOrDefault(f => f.DeckId == deck.DeckId);
            
            if (cardControl == null) return;

            if (cardControl.Index == deck.Cards.IndexOf(card))
            {
                cardControl.ControlState = ControlState.Enabled;
                cardControl.ImageUri = String.Format(@"C:\data\ruge\ruge.cardEngine\images\{0}.jpg",((int)card.Rank).ToString("{0:00}") + card.Suit.ToString().Substring(0,1));
            }
        }

        public void CardAddedToDeck(Guid deckId, Card card, int position)
        {
            var deck = _tablemanager.GetDeck(deckId);
            var cardControl = _cardControls.FirstOrDefault(f => f.DeckId == deck.DeckId);
            
            CanvasManager.AddEngineAction(cardControl, EngineActionType.Create);
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
            RenderCard(sourceDeckId, _tablemanager.GetCard(sourceDeckId, sourcecardId));
            RenderCard(destinationDeckId, _tablemanager.GetCard(sourceDeckId, destinationDeckId));
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
            RenderCard(soureceDeckId, _tablemanager.GetCard(soureceDeckId, sourcecardId));
            RenderCard(destinationDeckId, _tablemanager.GetCard(destinationDeckId, destinationCardId));
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
            CanvasManager.CreateCanvas(100, 100);
        }

        public void TableClearing(Guid tableId)
        {
        }

        public void SendEngineActionSet()
        {
            CanvasManager.SendEngineActionSet();
        }
    }
}
