namespace ruge.lib.model.engine
{
    using System;
    using ruge.lib.model;
    using ruge.lib.model.controls;
    public class EngineActionSetEventArgs
    {
        public Guid CanvasId { get; private set; }
        public EngineActionSet EngineActionSet { get; private set; }

        public EngineActionSetEventArgs(Canvas canvas, EngineActionSet engineActionSet)
        {
            this.CanvasId = canvas.CanvasId;
            this.EngineActionSet = engineActionSet;
        }
    }
}