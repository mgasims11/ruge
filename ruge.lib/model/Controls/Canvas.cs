namespace ruge.lib.model.controls
{
    using System;
    using ruge.lib.model.controls.interfaces;
    public class Canvas: IElement
    {
        public string CanvasId {get;set;}

        public string ElementId
        {
            get { return "CANVAS"; }
            set {}
        }

        public EnableStates EnableState
        {
            get { return EnableStates.Enabled; }
            set {}
        }

        public XYPair Dimensions {get;set;}

        public string ImageUri { get; set; }

        public XYPair Location { get; set; }

        public XYPair Size { get; set; }

        public bool IsVisible { get; set; }

        public string Name { get; set; }
    }
}