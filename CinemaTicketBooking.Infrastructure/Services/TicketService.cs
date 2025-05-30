using CinemaTicketBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketBooking.Infrastructure.Services
{
    public class TicketService
    {
        private readonly ApplicationDbContext _context;
        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Ticket>> GetAllAsync() => await _context.Tickets.ToListAsync();
        public async Task<Ticket> GetByIdAsync(int id) => await _context.Tickets.FindAsync(id);
        public async Task<Ticket> CreateAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }
        public async Task<Ticket> UpdateAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Tickets.FindAsync(id);
            if (entity == null) return false;
            _context.Tickets.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 