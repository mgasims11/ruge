
namespace ruge.lib.logic {
    using System;
    using ruge.lib.model;
    public class CanvasManager {
        public delegate void EngineActionEventHandler(object sender, EngineActionEventArgs e);
        public event EngineActionEventHandler EngineActionEvent;
        private Canvas _canvas;
        public CanvasManager() {
            this.EngineActionEvent += OnEngineActionEvent;
            this.RaiseEngineActionEvent(_canvas, ActionType.Create);
        }
        private void OnEngineActionEvent(object sender, EngineActionEventArgs args) {
            if (this.EngineActionEvent != null) {
                this.EngineActionEvent(sender,args);
            }
        }

        public void RaiseEngineActionEvent(Control control, ActionType actionType) {
            var args = new EngineControlActionEventArgs(control, actionType);
        }

        public void RaiseEngineActionEvent(Canvas canvas, ActionType actionType) {
           var args = new EngineCanvasActionEventArgs(canvas, actionType);
        }   

        public Canvas CreateFactory(int height, int width) {
            var canvas = new Canvas() {
                    CanvasId = Guid.NewGuid(),
                    Dimensions = new XYPair() {
                        X = 1920,
                        Y = 1080
                    }
                };
            return canvas;
        }
    }
}