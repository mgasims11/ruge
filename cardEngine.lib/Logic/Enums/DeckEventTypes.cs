using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardEngine.Logic.Enums
{
    public enum DeckEventTypes
    {
        DeckClearing,
        DeckCleared,
        DeckShuffling,
        DeckShuffled,
        DeckFilling,
        DeckFilled,
        CardAdding,
        CardAdded,
        CardRemoving,
        CardRemoved,      
    }
}
