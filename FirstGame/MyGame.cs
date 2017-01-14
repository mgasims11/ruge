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
                    c.ImageUri = @"C:\data\ruge\SampleImages\GoogleNeg_normal.png";
                    CanvasManager.AddEngineAction(c, EngineActionType.Update);
                    CanvasManager.SendEngineActionSet();
                    break;
            }
        }

        public void Start()
        {
            CanvasManager.CreateCanvas(5, 5);

            CanvasManager.AddControl(StaticImageControlMaker.Create().ImageUri(@"C:\data\ruge\SampleImages\Google_normal.png").Height(5).Width(5));

            CanvasManager.AddControl(TextControlMaker.Create().Height(1).Width(1).X(0).Y(0).Text("X"));
            CanvasManager.AddControl(TextControlMaker.Create().Height(1).Width(1).X(2).Y(0).Text("X"));
            CanvasManager.AddControl(TextControlMaker.Create().Height(1).Width(1).X(4).Y(0).Text("X"));

            CanvasManager.AddControl(TextControlMaker.Create().Height(1).Width(1).X(0).Y(2).Text("X"));
            CanvasManager.AddControl(TextControlMaker.Create().Height(1).Width(1).X(2).Y(2).Text("X"));
            CanvasManager.AddControl(TextControlMaker.Create().Height(1).Width(1).X(4).Y(2).Text("X"));

            CanvasManager.AddControl(TextControlMaker.Create().Height(1).Width(1).X(0).Y(4).Text("X"));
            CanvasManager.AddControl(TextControlMaker.Create().Height(1).Width(1).X(2).Y(4).Text("X"));
            CanvasManager.AddControl(TextControlMaker.Create().Height(1).Width(1).X(4).Y(4).Text("X"));

            CanvasManager.SendEngineActionSet();

        }
    }
}
