using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ruge.lib.model.controls
{
    using controls;
    using ruge.lib.model.controls.interfaces;

    public abstract class Control : IControl
    {
        public string ControlId { get; set; }
        public ControlState ControlState { get; set; }        
        public string ImageUri { get; set; }
        public XYPair Location { get; set; }
        public XYPair Size { get; set; }        
    }
}
