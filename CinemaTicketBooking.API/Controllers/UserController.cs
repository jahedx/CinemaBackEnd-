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
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<User>> Get() => await _service.GetAllAsync();
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return item;
        }
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            var created = await _service.CreateAsync(user);
            return CreatedAtAction(nameof(Get), new { id = created.UserId }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {
            if (id != user.UserId) return BadRequest();
            await _service.UpdateAsync(user);
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