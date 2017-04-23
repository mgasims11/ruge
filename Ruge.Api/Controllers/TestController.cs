using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JokerPoker1;
using System.Collections;
using ruge.lib.model.engine;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860


namespace Ruge.Api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        JokerPoker _game = new JokerPoker();
        Queue<EngineActionSet> _outputBuffer = new Queue<EngineActionSet>();
        EngineAction[] testset = new EngineAction[30];

        //// GET: api/values
        //[HttpGet]
        //public JsonResult Get()
        //{
        //    return new JsonResult(null);
        //}

        public TestController()
        {
            _game._canvasManager.EngineActionSetEvent += _canvasManager_EngineActionSetEvent;
        }

        private void _canvasManager_EngineActionSetEvent(object sender, EngineActionSetEventArgs e)
        {
            _outputBuffer.Enqueue(e.EngineActionSet);
            e.EngineActionSet.EngineActions.CopyTo(testset);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(string id)
        {
            switch(id)
            {
                case "start":
                    _game.Start();
                    break;
                case "1":
                    break;
            }
            return new JsonResult(_outputBuffer.Dequeue());
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{            
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
