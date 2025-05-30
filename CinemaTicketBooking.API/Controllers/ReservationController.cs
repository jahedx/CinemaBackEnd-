using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationResponse>>> Get()
        {
            var reservations = await _reservationService.GetAllAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationResponse>> Get(int id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation == null)
                return NotFound();

            return Ok(reservation);
        }

        [HttpPost]
        public async Task<ActionResult<ReservationResponse>> Post(CreateReservationRequest request)
        {
            var reservation = await _reservationService.CreateAsync(request);
            if (reservation == null)
                return BadRequest();

            return CreatedAtAction(nameof(Get), new { id = reservation.ReservationId }, reservation);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReservationResponse>> Put(int id, UpdateReservationRequest request)
        {
            var reservation = await _reservationService.UpdateAsync(id, request);
            if (reservation == null)
                return NotFound();

            return Ok(reservation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _reservationService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
} 