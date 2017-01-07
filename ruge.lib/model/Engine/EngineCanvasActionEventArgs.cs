namespace ruge.lib.model.engine {
    using ruge.lib.model;
    using ruge.lib.model.controls;
    public class EngineCanvasActionEventArgs : EngineActionEventArgs {
        public Canvas Canvas {get; private set;}
        public EngineActionType ActionType {get; private set;}
        public EngineCanvasActionEventArgs(Canvas canvas, EngineActionType actionType)
        {
            this.Canvas = canvas;
            this.ActionType = actionType;
        }
    }
}