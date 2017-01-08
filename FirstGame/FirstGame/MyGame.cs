﻿namespace FirstGame
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
        }

        public void Start()
        {            
            
            CanvasManager = new CanvasManager();
            CanvasManager.EngineActionEvent += CanvasManager_EngineActionEvent;
            CanvasManager.CreateCanvas(20, 20);
            
            for (var i = 0; i <= 19; i++)
                for (var j = 0; j <= 19; j++)
                {
                    CanvasManager.AddControl(
                        ControlType.Clickable,
                        1, 1,
                        i, j,
                        @"C:\data\ruge\SampleImages\image.png",
                        @"C:\data\ruge\SampleImages\hover.png",
                        @"C:\data\ruge\SampleImages\down.png",
                        @"C:\data\ruge\SampleImages\disabled.png",
                        "");
                }
        }

        private void CanvasManager_EngineActionEvent(object sender, EngineActionEventArgs e)
        {
            throw new NotImplementedException();
        }
    }        
}
