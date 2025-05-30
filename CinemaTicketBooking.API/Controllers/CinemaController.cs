using CinemaTicketBooking.Contracts;
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
    public class CinemaController : ControllerBase
    {
        private readonly CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CinemaResponse>>> Get()
        {
            var cinemas = await _cinemaService.GetAllAsync();
            return Ok(cinemas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CinemaResponse>> Get(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);
            if (cinema == null) return NotFound();
            return Ok(cinema);
        }

        [HttpPost]
        public async Task<ActionResult<CinemaResponse>> Post(CreateCinemaRequest request)
        {
            var cinema = await _cinemaService.CreateAsync(request);
            if (cinema == null) return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = cinema.CinemaId }, cinema);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CinemaResponse>> Put(int id, UpdateCinemaRequest request)
        {
            var cinema = await _cinemaService.UpdateAsync(id, request);
            if (cinema == null) return NotFound();
            return Ok(cinema);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cinemaService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
} 