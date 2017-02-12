namespace ruge.lib.model.controls
{
    using System;
    using ruge.lib.model.controls.interfaces;
    public class Canvas: IControl
    {
        public string CanvasId {get;set;}

        public string ControlId
        {
            get { return "CANVAS"; }
            set {}
        }

        public ControlState ControlState
        {
            get { return ControlState.Enabled; }
            set {}
        }

        public XYPair Dimensions {get;set;}

        public string ImageUri { get; set; }

        public XYPair Location { get; set; }

        public XYPair Size { get; set; }
    }
}