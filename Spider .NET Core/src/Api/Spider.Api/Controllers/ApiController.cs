using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spider.Helpers;
using Spider.App.Engine;
using Spider.App.Models;

namespace Spider.Api.Controllers
{
    [Route("api/[controller]")]
    public class ApiController : Controller
    {
        Engine engine = new Engine();

        public ApiController()
        {
        }
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "OK";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] VMRequestModel request)
        {
            var requestToProcess = new RequestModel()
            {
                Chanel = request.Chanel,
                Method = request.Method,
                Request = request.Request,
                Service = request.Service,
                Token = request.Token,
            };
            var result = engine.Process(requestToProcess);
            var response = JsonHelper.ToJson(result);
            return response;
        }
    }
}
