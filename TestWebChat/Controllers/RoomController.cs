namespace TestWebChat.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using TestWebChat.BusinessLogic.Services.Interfaces;
    using TestWebChat.Infrastructure.Models;

    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllRooms()
        {
            var rooms = _service.GetAll();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom([FromRoute] Guid id)
        {
            var room = await _service.FindByIdAsync(id);
            if (room == null)
                return NotFound();
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> PostRoom([FromBody] Room room)
        {
            _service.Create(room);
            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom([FromRoute] Guid id)
        {
            var room = await _service.FindByIdAsync(id);
            if (room != null)
                return NotFound();
            _service.Remove(room);
            return Ok(room);
        }
    }
}
