using Microsoft.AspNetCore.Mvc;
using Serilog;
using TravelAgencyAPI.Interfaces;
using TravelAgencyAPI.Models;
using TravelAgencyAPI.Services;

namespace TravelAgencyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // 1. Crear una nueva reserva
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdReservation = await _reservationService.CreateReservationAsync(reservation);

            if (createdReservation == null)
            {
                return StatusCode(500, "Error creating the reservation.");
            }

            return CreatedAtAction(nameof(GetReservationById), new { id = createdReservation.ReservationId }, createdReservation);
        }

        // 2. Obtener todas las reservas
        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllReservationsAsync();
            return Ok(reservations);
        }

        // 3. Obtener una reserva por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // 4. Modificar una reserva existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromBody] Reservation updatedReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingReservation = await _reservationService.GetReservationByIdAsync(id);
            if (existingReservation == null)
            {
                return NotFound("Reservation not found.");
            }

            var updated = await _reservationService.UpdateReservationAsync(id, updatedReservation);
            if (!updated)
            {
                return StatusCode(500, "Error updating the reservation.");
            }

            return NoContent();
        }

        // 5. Eliminar una reserva
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var existingReservation = await _reservationService.GetReservationByIdAsync(id);
            if (existingReservation == null)
            {
                return NotFound("Reservation not found.");
            }

            var deleted = await _reservationService.DeleteReservationAsync(id);
            if (!deleted)
            {
                return StatusCode(500, "Error deleting the reservation.");
            }

            return NoContent();
        }
    }
}
