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
    using CardEngine.Logic;
    using CardEngine.Model;

    public class RugeTableManager : TableManager
    {
        public Canvas Canvas;

        public static new RugeTableManager Create()
        {
            return new RugeTableManager();
        }

        public RugeTableManager Height(int height)
        {
            Canvas.Dimensions.Y = height;
            return this;
        }

        public RugeTableManager Width(int width)
        {
            Canvas.Dimensions.X = width;
            return this;
        }

        public RugeTableManager()
        {
            Canvas = new Canvas();
        }

       public RugeTableManager RugeDecks(params RugeDeck[] decks)
        {
            AddDecksToTable(decks);
            return this;
        }
    }
}
