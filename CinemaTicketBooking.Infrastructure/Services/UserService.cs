using CinemaTicketBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketBooking.Infrastructure.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllAsync() => await _context.Users.ToListAsync();
        public async Task<User> GetByIdAsync(int id) => await _context.Users.FindAsync(id);
        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Users.FindAsync(id);
            if (entity == null) return false;
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 