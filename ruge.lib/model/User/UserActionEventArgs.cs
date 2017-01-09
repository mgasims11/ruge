namespace ruge.lib.model.user
{
    using System;
    using ruge.lib.model;
    using ruge.lib.logic;
    using ruge.lib.model.controls;
    public class UserActionEventArgs
    {
        public UserAction UserAction { get; private set; }

        public UserActionEventArgs(UserAction userAction)
        {
            this.UserAction = userAction;
        }
    }
}