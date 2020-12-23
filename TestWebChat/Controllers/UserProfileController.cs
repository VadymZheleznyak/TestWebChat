namespace TestWebChat.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TestWebChat.BusinessLogic.Services.Interfaces;

    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private IApplicationUserService _service;

        public UserProfileController(IApplicationUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _service.GetById(userId);
            return new
            {
                user.UserName,
                user.Email
            };
        }
    }
}
