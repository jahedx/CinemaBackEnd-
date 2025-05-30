using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Data;
using CinemaTicketBooking.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketBooking.Infrastructure.Services
{
    public class MovieService
    {
        private readonly ApplicationDbContext _context;
        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MovieResponse>> GetAllAsync()
        {
            var movies = await _context.Movies
                .Include(m => m.Screenings)
                .ToListAsync();

            return movies.Select(m => MovieMapper.ToResponse(m)!).ToList();
        }

        public async Task<MovieResponse?> GetByIdAsync(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Screenings)
                .FirstOrDefaultAsync(m => m.MovieId == id);

            return MovieMapper.ToResponse(movie);
        }

        public async Task<MovieResponse?> CreateAsync(CreateMovieRequest request)
        {
            var movie = MovieMapper.ToEntity(request);
            if (movie == null) return null;

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return MovieMapper.ToResponse(movie);
        }

        public async Task<MovieResponse?> UpdateAsync(int id, UpdateMovieRequest request)
        {
            var movie = await _context.Movies
                .Include(m => m.Screenings)
                .FirstOrDefaultAsync(m => m.MovieId == id);

            if (movie == null) return null;

            MovieMapper.UpdateEntity(movie, request);
            await _context.SaveChangesAsync();

            return MovieMapper.ToResponse(movie);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) return false;

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 