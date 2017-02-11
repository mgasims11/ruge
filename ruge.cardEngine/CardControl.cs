using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ruge.lib.model;
using ruge.lib.model.controls;

namespace ruge.cardEngine
{
    public class CardControl : ClickableControl
    {
        public Guid DeckId { get; set; }
        public int Index { get; set; }        
    }
}
