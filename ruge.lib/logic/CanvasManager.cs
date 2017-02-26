
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

        private Dictionary<string, IElement> _iElements;

        public delegate void EngineActionEventHandler(object sender, EngineActionEventArgs e);
        public event EngineActionEventHandler EngineActionEvent;

        public delegate void EngineActionSetEventHandler(object sender, EngineActionSetEventArgs e);
        public event EngineActionSetEventHandler EngineActionSetEvent;

        public delegate void UserActionEventHandler(object sender, UserActionEventArgs e);
        public event UserActionEventHandler UserActionEvent;

        private EngineActionSet _engineActionSet = new EngineActionSet();

        public Canvas Canvas = null;

        private void RaiseEngineActionEvent(object sender, EngineActionEventArgs args) {
            if (this.EngineActionEvent != null) {
                this.EngineActionEvent(sender,args);
            }
        }
        
        public void RaiseEngineActionEvent(IElement control, EngineActionType actionType) {
            var args = new EngineControlActionEventArgs(control.ElementId, actionType);
            this.RaiseEngineActionEvent(this,args);
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

        public Canvas CreateCanvas(double height, double width) {
            var canvas = new Canvas() {
                    CanvasId = "C" + Guid.NewGuid().ToString().Replace("-", ""),
                    Dimensions = new XYPair(height,width)
            };
            Canvas = canvas;
            this.RaiseEngineActionEvent(Canvas, EngineActionType.Update);
            this.InitializeEngineActionSet();
            _iElements = null;
            Update(Canvas);

            return canvas;
        }

        public void SendEngineActionSet()
        {
            this.RaiseEngineActionSetEvent(this, _engineActionSet);
            InitializeEngineActionSet();
        }

        public void InitializeEngineActionSet()
        {

            _engineActionSet.CanvasId = Canvas.CanvasId;
            _engineActionSet.EngineActions.Clear();
        }

        public void AddEngineAction(IElement control, EngineActionType actionType)
        {
            var engineAction = new EngineAction();
            engineAction.ActionType = actionType;
            engineAction.Element = control;
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
            var args = new UserActionEventArgs(userAction, _iElements[userAction.ControlId]);
            if (this.UserActionEvent != null)
            {
                this.UserActionEvent(this, args);
            }
        }

        public void Update(IElement iElement)
        {
            if (_iElements == null) _iElements = new Dictionary<string, IElement>();

            if (!_iElements.ContainsKey(iElement.ElementId))
            {
                _iElements.Add(iElement.ElementId, iElement);
            }
            AddEngineAction(iElement, EngineActionType.Update);
        }
    }
}