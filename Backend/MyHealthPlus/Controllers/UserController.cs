using MyHealthPlus.Entities;
using MyHealthPlus.ViewModels;
using MyHealthPlus.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Linq;
using System;

namespace MyHealthPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            if (_userService.GetUserByEmail(username) != null)
            {
                return BadRequest(new { message = "Email has already been registered. Please login" });
            }

            _userService.RegisterUser(username, password, "Client");
            return Ok(new { message = "Successfully Registered" });
        }

        [AdminAuthorize]
        [HttpPost]
        public IActionResult RegisterStaff(string username, string password, string userType)
        {
            if (_userService.GetUserByEmail(username) != null)
            {
                return BadRequest(new { message = "Email has already been registered. Please login" });
            }

            _userService.RegisterUser(username, password, userType);
            return Ok(new { message = "Successfully Registered" });
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateUser(UserDetails userDetails)
        {
            dynamic user = HttpContext.Items["User"];
            _userService.UpdateUserById(user.UserId, userDetails);
            return Ok(new { message = "Successfully Registered" });
        }

        [Authorize]
        [HttpPost]
        public IActionResult GetUserByToken()
        {
            dynamic user = HttpContext.Items["User"];            
            return Ok(new AuthenticateResponse(_userService.GetUserById(user.UserId), ""));
        }
    }
}
