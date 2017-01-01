namespace ruge.lib.model {
    public class EngineCanvasActionEventArgs : EngineActionEventArgs {
        public Canvas Canvas {get; private set;}
        public ActionType ActionType {get; private set;}
        public EngineCanvasActionEventArgs(Canvas canvas, ActionType actionType)
        {
            this.Canvas = canvas;
            this.ActionType = actionType;
        }
    }
}