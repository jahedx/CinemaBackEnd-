using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Data;
using CinemaTicketBooking.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketBooking.Infrastructure.Services
{
    public class CinemaService
    {
        private readonly ApplicationDbContext _context;
        public CinemaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CinemaResponse>> GetAllAsync()
        {
            var cinemas = await _context.Cinemas
                .Include(c => c.Halls)
                .ToListAsync();

            return cinemas.Select(c => CinemaMapper.ToResponse(c)!).ToList();
        }

        public async Task<CinemaResponse?> GetByIdAsync(int id)
        {
            var cinema = await _context.Cinemas
                .Include(c => c.Halls)
                .FirstOrDefaultAsync(c => c.CinemaId == id);

            return CinemaMapper.ToResponse(cinema);
        }

        public async Task<CinemaResponse?> CreateAsync(CreateCinemaRequest request)
        {
            var cinema = CinemaMapper.ToEntity(request);
            if (cinema == null) return null;

            _context.Cinemas.Add(cinema);
            await _context.SaveChangesAsync();

            return CinemaMapper.ToResponse(cinema);
        }

        public async Task<CinemaResponse?> UpdateAsync(int id, UpdateCinemaRequest request)
        {
            var cinema = await _context.Cinemas
                .Include(c => c.Halls)
                .FirstOrDefaultAsync(c => c.CinemaId == id);

            if (cinema == null) return null;

            CinemaMapper.UpdateEntity(cinema, request);
            await _context.SaveChangesAsync();

            return CinemaMapper.ToResponse(cinema);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema == null) return false;

            _context.Cinemas.Remove(cinema);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 