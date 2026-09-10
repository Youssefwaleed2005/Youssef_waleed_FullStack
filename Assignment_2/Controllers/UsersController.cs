using Assignment_3.DTOs;
using Assignment_3.Models;
using Assignment_3.Services;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost ("register") ]
        public async Task<ActionResult> CreateUser(CreateUserRequest user)
        {
            return Created($"/api/user/{user.Id}", await _userService.CreateUser(user));
        }

        [HttpPost("login")]

        public async Task<ActionResult> Login(UserLoginRequestDto userLogin)
        {
            var token = await _userService.Login(userLogin);
            return Ok(new {accessToken=token}); 

        }


        [HttpGet ("api/admin/users")]
        [Authorize (Roles ="Admin")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }
    }
}
