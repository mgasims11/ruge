namespace ruge.lib.model.user {
    using System.Collections.Generic;
    using System;
    
    public class UserActionSet
    {
        public Guid CanvasId { get; set; }
        public List<UserAction> UserActions { get; set; }
    }
}
