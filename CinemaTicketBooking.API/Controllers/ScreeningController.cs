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
    public class ScreeningController : ControllerBase
    {
        private readonly ScreeningService _service;
        public ScreeningController(ScreeningService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<Screening>> Get() => await _service.GetAllAsync();
        [HttpGet("{id}")]
        public async Task<ActionResult<Screening>> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return item;
        }
        [HttpPost]
        public async Task<ActionResult<Screening>> Post(Screening screening)
        {
            var created = await _service.CreateAsync(screening);
            return CreatedAtAction(nameof(Get), new { id = created.ScreeningId }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Screening screening)
        {
            if (id != screening.ScreeningId) return BadRequest();
            await _service.UpdateAsync(screening);
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