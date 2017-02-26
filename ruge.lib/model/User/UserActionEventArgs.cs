namespace ruge.lib.model.user
{
    using System;
    using ruge.lib.model;
    using ruge.lib.logic;
    using ruge.lib.model.controls;
    using ruge.lib.model.controls.interfaces;

    public class UserActionEventArgs
    {
        public UserAction UserAction { get; private set; }
        public IElement Control { get; private set; }

        public UserActionEventArgs(UserAction userAction, IElement control)
        {
            UserAction = userAction;
            Control = control;
        }
    }
}