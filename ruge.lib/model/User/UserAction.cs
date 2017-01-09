namespace ruge.lib.model.user {
    using System;
    public class UserAction {
        public Guid ControlId {get;set;}
        public UserActionType UserActionType { get; set; }
    }
}