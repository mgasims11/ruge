using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ruge.lib.model.controls.interfaces
{
    public interface IElement
    {
        string Name { get; set; }
        string ElementId { get; set; }
        string ImageUri { get; set; }
        XYPair Location { get; set; }
        XYPair Size { get; set; }
        bool IsVisible {get;set;}
    }
}
