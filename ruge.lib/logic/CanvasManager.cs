
namespace ruge.lib.logic {
    using System;
    using System.Collections.Generic;
    using ruge.lib.model;
    public class CanvasManager {
        public delegate void EngineActionEventHandler(object sender, EngineActionEventArgs e);
        public event EngineActionEventHandler EngineActionEvent;
        private Canvas _canvas = null;

    private List<Control> _controls = new List<Control>();
        private void RaiseEngineActionEvent(object sender, EngineActionEventArgs args) {
            if (this.EngineActionEvent != null) {
                this.EngineActionEvent(sender,args);
            }
        }

        public void RaiseEngineActionEvent(Control control, ActionType actionType) {
            var args = new EngineControlActionEventArgs(control, actionType);
            this.RaiseEngineActionEvent(this,args);
        }

        public void RaiseEngineActionEvent(Canvas canvas, ActionType actionType) {
           var args = new EngineCanvasActionEventArgs(canvas, actionType);
           this.RaiseEngineActionEvent(this,args);
        }   

        public Canvas CreateCanvas(int height, int width) {
            var canvas = new Canvas() {
                    CanvasId = Guid.NewGuid(),
                    Dimensions = new XYPair() {
                        X = height,
                        Y = width
                    }
                };
            _canvas = canvas;
            this.RaiseEngineActionEvent(_canvas, ActionType.Create);            
            return canvas;
        }

        public void AddControl(ControlType controlType, int height, int width, int x, int y, string uri,string uriHover, string uriPressed, string text)
        {
            var control = new Control();
            control.ControlId = Guid.NewGuid();
            control.ControlType = controlType;
            control.Location = new XYPair() {X=x,Y=y};
            control.Size = new XYPair() {X=height,Y=width};
            control.VisualURI = uri;
            control.VisualURIHover = uriHover;
            control.VisualURIPressed = uriPressed;
            control.Text = text;
            RaiseEngineActionEvent(control,ActionType.Create);
        }
    }
}