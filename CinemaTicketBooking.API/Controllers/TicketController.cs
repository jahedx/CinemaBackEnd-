using CinemaTicketBooking.Infrastructure.Data;
using CinemaTicketBooking.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _service;
        public TicketController(TicketService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<Ticket>> Get() => await _service.GetAllAsync();
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return item;
        }
        [HttpPost]
        public async Task<ActionResult<Ticket>> Post(Ticket ticket)
        {
            var created = await _service.CreateAsync(ticket);
            return CreatedAtAction(nameof(Get), new { id = created.TicketId }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Ticket ticket)
        {
            if (id != ticket.TicketId) return BadRequest();
            await _service.UpdateAsync(ticket);
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