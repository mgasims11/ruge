namespace ruge.lib.model.engine {
    using System.Collections.Generic;
    using System;

    public class EngineActionSet
    {
        public string CanvasId { get; set; }
        public List<EngineAction> EngineActions { get; set; }

        public EngineActionSet()
        {
            this.EngineActions = new List<EngineAction>();
        }                
    }
}
