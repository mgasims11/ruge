using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ruge.lib.model;
using ruge.lib.model.controls;
using CardEngine.Model;

namespace ruge.cardEngine
{
    public class CardControl : ClickableControl
    {
        public Deck Deck { get; set; }
        public Card Card { get; set; }
        public int Index { get; set; }      
    }
}
