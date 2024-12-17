using Microsoft.AspNetCore.Mvc;
using TravelAgencyAPI.Interfaces;
using TravelAgencyAPI.Models;
using TravelAgencyAPI.Services;

namespace TravelAgency.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        // Endpoint para crear un Guest
        [HttpPost]
        public async Task<IActionResult> CreateGuest([FromBody] Guest guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdGuest = await _guestService.CreateGuestAsync(guest);

            if (createdGuest == null)
            {
                return StatusCode(500, "There was a problem creating the guest.");
            }

            return CreatedAtAction(nameof(GetGuestById), new { id = createdGuest.GuestId }, createdGuest);
        }

        // Endpoint para obtener un Guest por ID (referencia para el CreatedAtAction)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuestById(int id)
        {
            var guest = await _guestService.GetGuestByIdAsync(id);
            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }
    }
}
