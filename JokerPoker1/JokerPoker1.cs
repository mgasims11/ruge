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
    
    public class JokerPoker : IGame
    {     
        public RugeTableManager RugeTableManager;

        public JokerPoker()
        {
            RugeTableManager = RugeTableManager
                .Create()
                .ImageUri(@"C:\data\ruge\JokerPoker1\images\TableTop.png")
                .Height(50)
                .Width(50)
                .Decks(
                    RugeDeckManager.Create()
                        .Options(new DeckOptions(52))
                        .DeckName("Dealer Deck").Deck,
                    RugeDeckManager.Create()
                        .Options(new DeckOptions(52))
                        .DeckName("Player Deck").Deck
                    );

            //RugeTableManager.DeckAddedToTableEvent += RugeTableManager_DeckAddedToTableEvent;
        }



        private void UserActionEvent(object sender, UserActionEventArgs e)
        {
        }

        public void Start()
        {
            var cv = new CanvasManager();
            cv.CreateCanvas(100,60);
            //cv.AddControl           

            //string[] hand = new string[5];

            //int height = 15, width = 15, spacing = 2, xBlock = 10, y = 30;
            //var x = xBlock;
            //for (var i = 0; i <= 4; i++)
            //{
            //    hand[i] = CanvasManager.AddControl(ClickableControlMaker.Create().X(x).Y(y).Width(width).Height(height).AllUris(@"C:\data\ruge\cardEngine.lib\images\02S.jpg"));
            //    x += width + spacing;
            //}

            //CanvasManager.SendEngineActionSet();
        }
    }
}
