using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [ApiController]
    [Route("api/admin/rooms")]
    public class AdminController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public AdminController(IRoomService roomService) => _roomService = roomService;

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] Room room)
        {
            var created = await _roomService.CreateRoom(room);
            return Ok(created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var success = await _roomService.DeleteRoom(id);
            return success ? NoContent() : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms() =>
            Ok(await _roomService.GetRooms());
    }
}