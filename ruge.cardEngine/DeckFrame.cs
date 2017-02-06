using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ruge.lib.model;

namespace ruge.cardEngine
{
    public class DeckFrame
    {
        public Guid DeckId { get; set; }
        public List<XYPair> CardLocations { get; set; }
    }
}
