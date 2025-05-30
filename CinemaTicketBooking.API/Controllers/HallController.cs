using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Data;
using CinemaTicketBooking.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,Cinema Manager")]
    public class HallController : ControllerBase
    {
        private readonly HallService _service;
        private readonly ApplicationDbContext _context;

        public HallController(HallService service, ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<HallResponse>> Get()
        {
            var halls = await _context.Halls
                .Include(h => h.Cinema)
                .Select(h => new HallResponse
                {
                    HallId = h.HallId,
                    Name = h.Name,
                    Capacity = h.Capacity,
                    CinemaId = h.CinemaId,
                    CinemaName = h.Cinema.Name
                })
                .ToListAsync();
            return halls;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HallResponse>> Get(int id)
        {
            var hall = await _context.Halls
                .Include(h => h.Cinema)
                .Where(h => h.HallId == id)
                .Select(h => new HallResponse
                {
                    HallId = h.HallId,
                    Name = h.Name,
                    Capacity = h.Capacity,
                    CinemaId = h.CinemaId,
                    CinemaName = h.Cinema.Name
                })
                .FirstOrDefaultAsync();

            if (hall == null) return NotFound();
            return hall;
        }

        [HttpPost]
        public async Task<ActionResult<HallResponse>> Post(CreateHallRequest request)
        {
            var hall = new Hall
            {
                Name = request.Name,
                Capacity = request.Capacity,
                CinemaId = request.CinemaId
            };

            var created = await _service.CreateAsync(hall);
            var cinema = await _context.Cinemas.FindAsync(created.CinemaId);

            return CreatedAtAction(nameof(Get), new { id = created.HallId }, new HallResponse
            {
                HallId = created.HallId,
                Name = created.Name,
                Capacity = created.Capacity,
                CinemaId = created.CinemaId,
                CinemaName = cinema?.Name ?? string.Empty
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateHallRequest request)
        {
            var hall = await _service.GetByIdAsync(id);
            if (hall == null) return NotFound();

            hall.Name = request.Name;
            hall.Capacity = request.Capacity;
            hall.CinemaId = request.CinemaId;

            await _service.UpdateAsync(hall);
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