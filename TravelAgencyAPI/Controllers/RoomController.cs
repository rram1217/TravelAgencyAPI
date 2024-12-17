using Microsoft.AspNetCore.Mvc;
using TravelAgencyAPI.Interfaces;
using TravelAgencyAPI.Models;

namespace TravelAgencyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // 1. Crear una nueva habitación
        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdRoom = await _roomService.CreateRoomAsync(room);

            if (createdRoom == null)
            {
                return StatusCode(500, "Error creating the room.");
            }

            return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.RoomId }, createdRoom);
        }

        // 2. Obtener todas las habitaciones
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Ok(rooms);
        }

        // 3. Obtener una habitación por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // 4. Modificar una habitación existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] Room updatedRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingRoom = await _roomService.GetRoomByIdAsync(id);
            if (existingRoom == null)
            {
                return NotFound("Room not found.");
            }

            var updated = await _roomService.UpdateRoomAsync(id, updatedRoom);
            if (!updated)
            {
                return StatusCode(500, "Error updating the room.");
            }

            return NoContent();
        }

        // 5. Eliminar una habitación
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var existingRoom = await _roomService.GetRoomByIdAsync(id);
            if (existingRoom == null)
            {
                return NotFound("Room not found.");
            }

            var deleted = await _roomService.DeleteRoomAsync(id);
            if (!deleted)
            {
                return StatusCode(500, "Error deleting the room.");
            }

            return NoContent();
        }
    }
}
