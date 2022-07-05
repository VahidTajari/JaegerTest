using Microsoft.AspNetCore.Mvc;
using User.Models;
using User.Services;

namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers() =>  Ok(await _userService.GetUsersAsync());

        [HttpPost]

        public async Task<ActionResult> AddUser(AddUserDto model) => Ok(await _userService.AddUserAsync(model.Username));


    }
}
