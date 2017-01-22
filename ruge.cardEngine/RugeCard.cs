namespace ruge.cardEngine
{
    using ruge.cardEngine;
    using ruge.lib.logic;
    using ruge.lib.model;
    using ruge.lib.model.controls;
    using ruge.lib.model.engine;
    using ruge.lib.model.user;
    using CardEngine.Logic;
    using CardEngine.Model;

    public class RugeCard : Card
    {
        public ClickableControl ClickableControl = new ClickableControl();

        public RugeCard(CardLocation location, Ranks rank, Suits suit, Orientations orientation, Deck deck, int value): base(rank, suit, orientation, deck, value)
        {
        }
    }
}
