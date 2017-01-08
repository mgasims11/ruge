
namespace ruge.lib.logic {
    using System;
    using System.Collections.Generic;
    using ruge.lib.model;
    using ruge.lib.model.controls;
    using ruge.lib.model.engine;

    public class CanvasManager {
        public delegate void EngineActionEventHandler(object sender, EngineActionEventArgs e);
        public event EngineActionEventHandler EngineActionEvent;

        public delegate void EngineActionSetEventHandler(object sender, EngineActionSetEventArgs e);
        public event EngineActionSetEventHandler EngineActionSetEvent;

        private EngineActionSet _engineActionSet = new EngineActionSet();

        private Canvas _canvas = null;

    private List<Control> _controls = new List<Control>();
        private void RaiseEngineActionEvent(object sender, EngineActionEventArgs args) {
            if (this.EngineActionEvent != null) {
                this.EngineActionEvent(sender,args);
            }
        }

        public void RaiseEngineActionEvent(Control control, EngineActionType actionType) {
            var args = new EngineControlActionEventArgs(control, actionType);
            this.RaiseEngineActionEvent(this,args);
            //var x = new ruge.lib.model.engine.EngineControlActionEventArgs(control, actionType);
        }

        public void RaiseEngineActionEvent(Canvas canvas, EngineActionType actionType) {
           var args = new EngineCanvasActionEventArgs(canvas, actionType);
           this.RaiseEngineActionEvent(this,args);
        }

        public void RaiseEngineActionSetEvent(CanvasManager canvasManager, EngineActionSet engineActionSet)
        {
            var args = new EngineActionSetEventArgs(this, engineActionSet);

            if (this.EngineActionSetEvent != null)
            {
                this.EngineActionSetEvent(this, args);
            }
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
            this.RaiseEngineActionEvent(_canvas, EngineActionType.Create);
            this.InitializeEngineActionSet();
                      
            return canvas;
        }

        public Guid AddControl(
            ControlType controlType,
            int height, int width,
            int x, int y,
            string uriIdle,
            string uriHover,
            string uriDown,
            string uriDisabled,
            string text)
        {
            var control = new Control();
            control.ControlId = Guid.NewGuid();
            control.ControlType = controlType;
            control.Location = new XYPair() {X=x,Y=y};
            control.Size = new XYPair() {X=height,Y=width};
            control.VisualURIIdle = uriIdle;
            control.VisualURIHover = uriHover;
            control.VisualURIDown = uriDown;
            control.VisualURIDisabled = uriDisabled;
            control.Text = text;

            RaiseEngineActionEvent(control,EngineActionType.Create);

            AddEngineAction(control);

            return control.ControlId;
        }

        public void SendEngineActionSet()
        {
            this.RaiseEngineActionSetEvent(this, _engineActionSet);
            InitializeEngineActionSet();
        }

        public void InitializeEngineActionSet()
        {

            _engineActionSet.CanvasId = _canvas.CanvasId;
            _engineActionSet.EngineActions = new List<EngineAction>();
        }

        public void AddEngineAction(Control control)
        {
            var engineAction = new EngineAction();
            engineAction.ActionType = EngineActionType.Create;
            engineAction.Control = control;

            _engineActionSet.EngineActions.Add(engineAction);
        }
    }
}