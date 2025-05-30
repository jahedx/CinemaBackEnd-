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
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieResponse>>> Get()
        {
            var movies = await _movieService.GetAllAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieResponse>> Get(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<MovieResponse>> Post(CreateMovieRequest request)
        {
            var movie = await _movieService.CreateAsync(request);
            if (movie == null) return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = movie.MovieId }, movie);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieResponse>> Put(int id, UpdateMovieRequest request)
        {
            var movie = await _movieService.UpdateAsync(id, request);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _movieService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
} 