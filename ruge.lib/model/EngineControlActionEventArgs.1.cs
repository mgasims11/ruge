namespace ruge.lib.model {
    public class EngineControlActionEventArgs : EngineActionEventArgs {
        public Control Control {get; private set;}
        public ActionType ActionType {get; private set;}
        public EngineControlActionEventArgs(Control control, ActionType actionType)
        {
            this.Control = control;
            this.ActionType = actionType;
        }
    }
}