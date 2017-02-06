
namespace ruge.lib.logic {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ruge.lib.model;
    using ruge.lib.model.controls;
    using ruge.lib.model.controls.interfaces;
    using ruge.lib.model.engine;
    using ruge.lib.model.user;


    public class CanvasManager {
        public delegate void EngineActionEventHandler(object sender, EngineActionEventArgs e);
        public event EngineActionEventHandler EngineActionEvent;

        public delegate void EngineActionSetEventHandler(object sender, EngineActionSetEventArgs e);
        public event EngineActionSetEventHandler EngineActionSetEvent;

        public delegate void UserActionEventHandler(object sender, UserActionEventArgs e);
        public event UserActionEventHandler UserActionEvent;

        private EngineActionSet _engineActionSet = new EngineActionSet();

        private Canvas _canvas = null;

        private List<IControl> _controls = new List<IControl>();

        private void RaiseEngineActionEvent(object sender, EngineActionEventArgs args) {
            if (this.EngineActionEvent != null) {
                this.EngineActionEvent(sender,args);
            }
        }
        
        public void RaiseEngineActionEvent(IControl control, EngineActionType actionType) {
            var args = new EngineControlActionEventArgs(control.ControlId, actionType);
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
                    CanvasId = "C" + Guid.NewGuid().ToString().Replace("-", ""),
                    Dimensions = new XYPair(height,width)
            };
            _canvas = canvas;
            this.RaiseEngineActionEvent(_canvas, EngineActionType.Create);
            this.InitializeEngineActionSet();
                      
            return canvas;
        }

        public IControl GetControl(string controlId)
        {
            return _controls.FirstOrDefault<IControl>(c => c.ControlId == controlId);
        }

        public string AddControl(IControl control)
        {
            _controls.Add(control);
            RaiseEngineActionEvent(control, EngineActionType.Create);
            AddEngineAction(control, EngineActionType.Create);
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

        public void AddEngineAction(IControl control, EngineActionType actionType)
        {
            var engineAction = new EngineAction();
            engineAction.ActionType = actionType;
            engineAction.Control = control;
            _engineActionSet.EngineActions.Add(engineAction);
        }

        public void ReceiveUserActionSet(UserActionSet userActionSet)
        {
            foreach (var userAction in userActionSet.UserActions)
            {
                this.RaiseUserActionEvent(userAction);
            }
        }

        public void RaiseUserActionEvent(UserAction userAction)
        {
            var args = new UserActionEventArgs(userAction);
            if (this.UserActionEvent != null)
            {
                this.UserActionEvent(this, args);
            }
        }
    }
}