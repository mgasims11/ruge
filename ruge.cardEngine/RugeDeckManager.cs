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

    public class RugeDeckManager : DeckManager
    {
        public List<XYPair> XYCardLocations;
        public RugeDeckManager()
        {
                
        }
    }
}
