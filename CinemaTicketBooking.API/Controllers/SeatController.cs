using CinemaTicketBooking.Infrastructure.Data;
using CinemaTicketBooking.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Cinema Manager")]
    public class SeatController : ControllerBase
    {
        private readonly SeatService _service;
        public SeatController(SeatService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<Seat>> Get() => await _service.GetAllAsync();
        [HttpGet("{id}")]
        public async Task<ActionResult<Seat>> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return item;
        }
        [HttpPost]
        public async Task<ActionResult<Seat>> Post(Seat seat)
        {
            var created = await _service.CreateAsync(seat);
            return CreatedAtAction(nameof(Get), new { id = created.SeatId }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Seat seat)
        {
            if (id != seat.SeatId) return BadRequest();
            await _service.UpdateAsync(seat);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 