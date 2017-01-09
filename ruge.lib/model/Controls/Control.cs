namespace ruge.lib.model.controls {
    using System;
    public class Control  {
        public string ControlId {get;set;}
        public ControlType ControlType {get;set;}
        public XYPair Location {get;set;}
        public XYPair Size {get;set;}
        public string VisualURIIdle {get;set;}
        public string VisualURIHover { get; set; }
        public string VisualURIDown { get; set; }
        public string VisualURIDisabled { get; set; }
        public string Text {get;set;}
    }   
}