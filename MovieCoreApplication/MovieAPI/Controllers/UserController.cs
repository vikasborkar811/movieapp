using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Service;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("SelectUser")]
        public IActionResult SelectUser()
        {
            return Ok(_userService.SelctUser());
        }

        [HttpPost("Register")]
        public IActionResult Register(UserModel userModel)
        {
            return Ok(_userService.Register(userModel));
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(UserModel userModel)
        {
            return Ok(_userService.UpdateUser(userModel));

        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(_userService.deleteUser(id));
        }

        [HttpPost("Login")]
        public IActionResult Login(UserModel userModel)
        {
            return Ok(_userService.Login(userModel));
        }

        [HttpGet("findUserById")]
        public IActionResult findUserById(int UserId)
        {
            return Ok(_userService.findUserById(UserId));
        }
    }
}
