using CinemaTicketBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketBooking.Infrastructure.Services
{
    public class SeatService
    {
        private readonly ApplicationDbContext _context;
        public SeatService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Seat>> GetAllAsync() => await _context.Seats.ToListAsync();
        public async Task<Seat> GetByIdAsync(int id) => await _context.Seats.FindAsync(id);
        public async Task<Seat> CreateAsync(Seat seat)
        {
            _context.Seats.Add(seat);
            await _context.SaveChangesAsync();
            return seat;
        }
        public async Task<Seat> UpdateAsync(Seat seat)
        {
            _context.Seats.Update(seat);
            await _context.SaveChangesAsync();
            return seat;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Seats.FindAsync(id);
            if (entity == null) return false;
            _context.Seats.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 