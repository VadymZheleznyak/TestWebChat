namespace TestWebChat.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TestWebChat.BusinessLogic.Models;
    using TestWebChat.BusinessLogic.Services.Interfaces;

    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationUserController : ControllerBase
    {
        private IApplicationUserService _service;

        public ApplicationUserController(IApplicationUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> PostApplicationUser(User user)
        {
            var response = await _service.CreateUser(user);
            return Ok(response);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            var token = await _service.LoginUser(user);
            if (!string.IsNullOrEmpty(token))
            {
                return Ok(new { token = token, userName = user.UserName });
            }
            return BadRequest(new { message = "Username or password is incorrect." });
        }
    }
}
