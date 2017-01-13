namespace FirstGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ruge.lib;

    using ruge.lib.logic;
    using ruge.lib.model.controls;
    using ruge.lib.model.engine;
    using ruge.lib.model.user;


    public class MyGame
    {
        public CanvasManager CanvasManager { get; set; }

        public MyGame()
        {
            CanvasManager = new CanvasManager();
            CanvasManager.UserActionEvent += CanvasManager_UserActionEvent;
        }

        private void CanvasManager_UserActionEvent(object sender, UserActionEventArgs e)
        {
            switch (e.UserAction.UserActionType)
            {
                case UserActionType.Click:
                    var c = CanvasManager.GetControl(e.UserAction.ControlId);
                    c.ImageUri = @"C:\data\ruge\SampleImages\GoogleNeg.png";
                    CanvasManager.AddEngineAction(c, EngineActionType.Update);
                    CanvasManager.SendEngineActionSet();
                    break;
            }
        }

        public void Start()
        {
            CanvasManager.CreateCanvas(100, 100);

            for (var i = 0; i <= 95; i += 5)
            {
                for (var j = 0; j <= 95; j += 5)
                {
                    CanvasManager.AddControl(new ClickableControl()
                           .ControlState(ControlState.Enabled)
                           .Height(5).Width(5)
                           .X(i).Y(j)
                           .ImageUri(@"C:\data\ruge\SampleImages\Google.png"));
                }
            }

        CanvasManager.AddControl(new TextInputControl()
            .ControlState(ControlState.Enabled)
            .Height(5).Width(15)
            .X(10).Y(10)
            .ImageUri(@"C:\data\ruge\SampleImages\Google.png"));

            CanvasManager.SendEngineActionSet();
        }
    }
}
