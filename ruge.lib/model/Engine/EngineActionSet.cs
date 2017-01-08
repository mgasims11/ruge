namespace ruge.lib.model.engine {
    using System.Collections.Generic;
    using System;

    public class EngineActionSet
    {
        public Guid CanvasId { get; set; }
        public List<EngineAction> EngineActions { get; set; }
    }
}
