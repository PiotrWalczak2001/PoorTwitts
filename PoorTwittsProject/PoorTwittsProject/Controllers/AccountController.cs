using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoorTwittsProject.Controllers
{
    [Route("account/")]
    public class AccountController : ControllerBase
    {
        public AccountController()
        {

        }

        [HttpGet]
        [Route("getUser")]
        public async Task<IActionResult> GetUser()
        {
            return Ok();
        }

        [HttpPost]
        [Route("registerUser")]
        public async Task<IActionResult> RegisterUser()
        {
            return Ok();
        }


        [HttpPost]
        [Route("loginUser")]
        public async Task<IActionResult> LoginUser()
        {
            return Ok();
        }

    }
}
