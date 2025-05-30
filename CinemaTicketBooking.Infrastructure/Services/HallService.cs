using CinemaTicketBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketBooking.Infrastructure.Services
{
    public class HallService
    {
        private readonly ApplicationDbContext _context;
        public HallService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Hall>> GetAllAsync() => await _context.Halls.ToListAsync();
        public async Task<Hall> GetByIdAsync(int id) => await _context.Halls.FindAsync(id);
        public async Task<Hall> CreateAsync(Hall hall)
        {
            _context.Halls.Add(hall);
            await _context.SaveChangesAsync();
            return hall;
        }
        public async Task<Hall> UpdateAsync(Hall hall)
        {
            _context.Halls.Update(hall);
            await _context.SaveChangesAsync();
            return hall;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Halls.FindAsync(id);
            if (entity == null) return false;
            _context.Halls.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 