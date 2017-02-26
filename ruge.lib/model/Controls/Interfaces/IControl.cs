using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ruge.lib.model.controls.interfaces
{
    public interface IElement
    {
        string ElementId { get; set; }
        EnableStates EnableState { get; set; }
        string ImageUri { get; set; }
        XYPair Location { get; set; }
        XYPair Size { get; set; }
    }
}
