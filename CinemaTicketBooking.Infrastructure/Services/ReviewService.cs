using CinemaTicketBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketBooking.Infrastructure.Services
{
    public class ReviewService
    {
        private readonly ApplicationDbContext _context;
        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Review>> GetAllAsync() => await _context.Reviews.ToListAsync();
        public async Task<Review> GetByIdAsync(int id) => await _context.Reviews.FindAsync(id);
        public async Task<Review> CreateAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }
        public async Task<Review> UpdateAsync(Review review)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
            return review;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Reviews.FindAsync(id);
            if (entity == null) return false;
            _context.Reviews.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 