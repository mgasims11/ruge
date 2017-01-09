namespace ruge.lib.model.user
{
    using System;
    using ruge.lib.model;
    using ruge.lib.logic;
    using ruge.lib.model.controls;
    public class UserActionEventArgs
    {
        public Guid CanvasId { get; private set; }
        public UserAction UserAction { get; private set; }

        public UserActionEventArgs(Guid canvasId, UserAction userAction)
        {             
            this.CanvasId = 
            this.UserAction = userAction;
        }
    }
}