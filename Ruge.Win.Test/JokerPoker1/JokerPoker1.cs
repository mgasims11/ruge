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
    public class JokerPoker1 : IGame
    {
        public CanvasManager CanvasManager { get; set; }

        public JokerPoker1()
        {
            CanvasManager = new CanvasManager();
            CanvasManager.UserActionEvent += UserActionEvent; ;
        }

        private void UserActionEvent(object sender, UserActionEventArgs e)
        {
        }

        public void Start()
        {
        }
    }
}
