using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PoorTwittsProject.Domain.Dtos;
using PoorTwittsProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoorTwittsProject.Controllers
{
    [Route("account/")]
    public class AccountController : ControllerBase
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route("getUser")]
        public async Task<IActionResult> GetUser()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user==null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("registerUser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto userRegisterDto)
        {
            var newUser = new ApplicationUser
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
            };
            var result = await _userManager.CreateAsync(newUser, userRegisterDto.Password);
            if(result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                await _userManager.ConfirmEmailAsync(newUser, token);
                return Ok();
            }
            return NotFound();
        }


        [HttpPost]
        [Route("loginUser")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userLoginDto.UserName);
            if(user == null)
            {
                return NotFound();
            }
            var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, true, false);
            if(result.Succeeded)
            {
                return Ok();
            }
            return NotFound();
        }

    }
}
