namespace CardEngine.Logic
{
    using System;

    public class CardManager
    {
        public EventHandler<CardManagerEventArgs> OnCardAddingToDeck;
        public EventHandler<CardManagerEventArgs> OnCardAddedToDeck;
        public EventHandler<CardManagerEventArgs> OnCardRemovingFromDeck;
        public EventHandler<CardManagerEventArgs> OnCardRemovedFromDeck;
    }
}
