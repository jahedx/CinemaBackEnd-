using CinemaTicketBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketBooking.Infrastructure.Services
{
    public class ScreeningService
    {
        private readonly ApplicationDbContext _context;
        public ScreeningService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Screening>> GetAllAsync() => await _context.Screenings.ToListAsync();
        public async Task<Screening> GetByIdAsync(int id) => await _context.Screenings.FindAsync(id);
        public async Task<Screening> CreateAsync(Screening screening)
        {
            _context.Screenings.Add(screening);
            await _context.SaveChangesAsync();
            return screening;
        }
        public async Task<Screening> UpdateAsync(Screening screening)
        {
            _context.Screenings.Update(screening);
            await _context.SaveChangesAsync();
            return screening;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Screenings.FindAsync(id);
            if (entity == null) return false;
            _context.Screenings.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 