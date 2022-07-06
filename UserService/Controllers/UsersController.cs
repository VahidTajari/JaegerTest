using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using User.Models;
using User.Services;

namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITracer _tracer;

        public UsersController(IUserService userService, ITracer tracer)
        {
            _userService = userService;
            _tracer = tracer;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers() =>  Ok(await _userService.GetUsersAsync());

        [HttpPost]

        public async Task<ActionResult> AddUser(AddUserDto model)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            scope.Span.Log($"Add user log username {model.Username}");
            return Ok(await _userService.AddUserAsync(model.Username));
        }


    }
}
