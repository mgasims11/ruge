namespace ruge.lib.model.user {
    using System.Collections.Generic;
    using System;
    
    public class UserActionSet
    {
        public List<UserAction> UserActions { get; set; }

        public UserActionSet()
        {
            this.UserActions = new List<UserAction>();
        }
    }
}
