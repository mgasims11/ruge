namespace ruge.lib.model.engine {
    using ruge.lib.model;
    using ruge.lib.model.controls;
    public class EngineControlActionEventArgs : EngineActionEventArgs {
        public string ElementId {get; private set;}
        public EngineActionType ActionType {get; private set;}
        public EngineControlActionEventArgs(string controlId, EngineActionType actionType)
        {
            this.ElementId = controlId;
            this.ActionType = actionType;
        }
    }
}