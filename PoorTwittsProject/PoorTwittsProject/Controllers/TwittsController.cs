using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoorTwittsProject.Controllers
{
    [ApiController]
    [Route("twitts")]
    public class TwittsController : ControllerBase
    {
        public TwittsController()
        {

        }

        [HttpGet]
        [Route("getTwitts")]
        public IActionResult GetTwitts()
        {
            return Ok();
        }

        [HttpPost]
        [Route("sendTwitt")]
        public IActionResult SendTwitt()
        {
            return Ok();
        }

    }
}
