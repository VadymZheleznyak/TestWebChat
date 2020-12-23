namespace TestWebChat.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TestWebChat.BusinessLogic.Models;
    using TestWebChat.BusinessLogic.Services.Interfaces;
    using TestWebChat.Infrastructure.Models;

    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllMessages(string roomName)
        {
            var rooms = _service.GetAllMessagesFromRoom(roomName);
            return Ok(rooms);
        }

        [HttpPost]
        public void PostMessage(CreateMessageModel model)
        {
            _service.Create(model);
        }
    }
}
