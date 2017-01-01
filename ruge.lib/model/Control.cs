namespace ruge.lib.model {
    using System;
    public class Control  {
        public Guid ControlId {get;set;}
        public ControlType ControlType {get;set;}
        public XYPair Location {get;set;}
        public XYPair Size {get;set;}
        public string VisualURI {get;set;}
        public string Text {get;set;}
    }   
}