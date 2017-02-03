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

    public class RugeTableManager : TableManager
    {
        public Canvas Canvas;

        public static RugeTableManager Create()
        {
            return new RugeTableManager();                      
        }

        public RugeTableManager Height(int height)
        {
            if (Canvas.Dimensions == null) Canvas.Dimensions = new XYPair();
            Canvas.Dimensions.Y = height;
            return this;
        }

        public RugeTableManager Width(int width)
        {
            if (Canvas.Dimensions == null) Canvas.Dimensions = new XYPair();
            Canvas.Dimensions.X = width;
            return this;
        }

        public RugeTableManager()
        {
            Canvas = new Canvas();
            TableEvent += TableEvent_Handler;
            DeckEvent += DeckEvent_Handler;
            CardEvent += CardEvent_Handler;

        }

        private void TableEvent_Handler(object sender, CardEngine.Logic.EventArgs.TableEventArgs e)
        {
            switch (e.TableEventType)
            {
                case CardEngine.Logic.Enums.TableEventTypes.TableClearing:
                    break;
                case CardEngine.Logic.Enums.TableEventTypes.TableCleared:
                    break;
                case CardEngine.Logic.Enums.TableEventTypes.DeckAddingToTable:
                    break;
                case CardEngine.Logic.Enums.TableEventTypes.DeckAddedToTable:
                    break;
                case CardEngine.Logic.Enums.TableEventTypes.DeckBeingRemoved:
                    break;
                case CardEngine.Logic.Enums.TableEventTypes.DeckRemovedFromTable:
                    break;
            }
        }

        private void DeckEvent_Handler(object sender, CardEngine.Logic.EventArgs.DeckEventArgs e)
        {
         
        }

        private void CardEvent_Handler(object sender, CardEngine.Logic.EventArgs.CardEventArgs e)
        {
         
        }
    }
}
