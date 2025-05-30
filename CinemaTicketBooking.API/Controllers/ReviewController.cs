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
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _service;
        public ReviewController(ReviewService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<Review>> Get() => await _service.GetAllAsync();
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return item;
        }
        [HttpPost]
        public async Task<ActionResult<Review>> Post(Review review)
        {
            var created = await _service.CreateAsync(review);
            return CreatedAtAction(nameof(Get), new { id = created.ReviewId }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Review review)
        {
            if (id != review.ReviewId) return BadRequest();
            await _service.UpdateAsync(review);
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