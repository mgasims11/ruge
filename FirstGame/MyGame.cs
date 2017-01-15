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
                    var c = CanvasManager.GetControl(e.UserAction.ControlId) as ClickableControl;
                    c.AllUris(@"C:\data\ruge\SampleImages\GoogleNeg_normal.png");
                    CanvasManager.AddEngineAction(c, EngineActionType.Update);
                    CanvasManager.SendEngineActionSet();
                    break;
            }
        }

        public void Start()
        {
            CanvasManager.CreateCanvas(14, 14);

            CanvasManager.AddControl(StaticImageControlMaker.Create().Height(14).Width(14).X(0).Y(0).ImageUri(@"C:\data\ruge\SampleImages\background.jpg"));

            CanvasManager.AddControl(ClickableControlMaker.Create().Height(4).Width(4).X(0).Y(0).ImageUri(@"C:\data\ruge\SampleImages\O.png"));
            CanvasManager.AddControl(ClickableControlMaker.Create().Height(4).Width(4).X(5).Y(0).ImageUri(@"C:\data\ruge\SampleImages\X.png"));
            CanvasManager.AddControl(ClickableControlMaker.Create().Height(4).Width(4).X(10).Y(0).ImageUri(@"C:\data\ruge\SampleImages\O.png"));

            CanvasManager.AddControl(ClickableControlMaker.Create().Height(4).Width(4).X(0).Y(5).ImageUri(@"C:\data\ruge\SampleImages\X.png"));
            CanvasManager.AddControl(ClickableControlMaker.Create().Height(4).Width(4).X(5).Y(5).ImageUri(@"C:\data\ruge\SampleImages\O.png"));
            CanvasManager.AddControl(ClickableControlMaker.Create().Height(4).Width(4).X(10).Y(5).ImageUri(@"C:\data\ruge\SampleImages\X.png"));

            CanvasManager.AddControl(ClickableControlMaker.Create().Height(4).Width(4).X(0).Y(10).ImageUri(@"C:\data\ruge\SampleImages\O.png"));
            CanvasManager.AddControl(ClickableControlMaker.Create().Height(4).Width(4).X(5).Y(10).ImageUri(@"C:\data\ruge\SampleImages\X.png"));
            CanvasManager.AddControl(ClickableControlMaker.Create().Height(4).Width(4).X(10).Y(10).ImageUri(@"C:\data\ruge\SampleImages\O.png"));

            CanvasManager.SendEngineActionSet();
        }
    }
}
