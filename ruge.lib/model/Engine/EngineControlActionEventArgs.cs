namespace ruge.lib.model.engine {
    using ruge.lib.model;
    using ruge.lib.model.controls;
    public class EngineControlActionEventArgs : EngineActionEventArgs {
        public Control Control {get; private set;}
        public EngineActionType ActionType {get; private set;}
        public EngineControlActionEventArgs(Control control, EngineActionType actionType)
        {
            this.Control = control;
            this.ActionType = actionType;
        }
    }
}