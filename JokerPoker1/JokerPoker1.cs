using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ruge.lib;
using ruge.lib.logic;
using ruge.lib.model.controls;
using ruge.lib.model.Controls.Interfaces;
using ruge.lib.model.engine;
using ruge.lib.model.user;

namespace JokerPoker1
{
    public class JokerPoker : IGame
    {
        public CanvasManager CanvasManager { get; set; }

        public JokerPoker()
        {
            CanvasManager = new CanvasManager();
            CanvasManager.UserActionEvent += UserActionEvent;
        }

        private void UserActionEvent(object sender, UserActionEventArgs e)
        {
        }

        public void Start()
        {

            CanvasManager.CreateCanvas(100,60);

            string[] hand = new string[5];

            int height = 15, width = 15, spacing = 2, xBlock = 20, y = 30;
            var x = xBlock;
            for (var i = 0; i <= 4; i++)
            {
                hand[i] = CanvasManager.AddControl(ClickableControlMaker.Create().X(x).Y(y).Width(width).Height(height).AllUris(@"C:\data\ruge\cardEngine.lib\images\02S.jpg"));
                x += width + spacing;
            }

            CanvasManager.SendEngineActionSet();
        }
    }
}
