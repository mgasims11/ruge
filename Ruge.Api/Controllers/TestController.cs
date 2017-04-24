using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JokerPoker1;
using System.Collections;
using ruge.lib.model.engine;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860


namespace Ruge.Api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        JokerPoker _game = new JokerPoker();
        Queue<List<EngineAction>> _outputBuffer = new Queue<List<EngineAction>>();
       

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
            _outputBuffer.Enqueue(e.EngineActionSet.EngineActions);
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
            
            var settings = new JsonSerializerSettings();
            settings.Error = (serializer, err) =>
            {
                err.ErrorContext.Handled = true;
            };


            var o = _outputBuffer.Dequeue();
            var z = Newtonsoft.Json.JsonConvert.SerializeObject(o,settings);
            var jr = new JsonResult(o,settings);
            return jr;
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
