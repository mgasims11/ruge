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
        public void Start()
        {            
            var _canvasManager = new CanvasManager();
            //_canvasManager.EngineActionEvent += _canvasManager_EngineActionEvent;
            _canvasManager.CreateCanvas(20, 20);
            for (var i = 0; i <= 19; i++)
                for (var j = 0; j <= 19; j++)
                {
                    _canvasManager.AddControl(
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
    }
        
}
