using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Data;
using CinemaTicketBooking.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketBooking.Infrastructure.Services
{
    public class NotificationService
    {
        private readonly ApplicationDbContext _context;

        public NotificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NotificationResponse>> GetAllAsync()
        {
            var notifications = await _context.Notifications
                .Include(n => n.User)
                .ToListAsync();
            return notifications.Select(n => NotificationMapper.ToResponse(n)!);
        }

        public async Task<NotificationResponse?> GetByIdAsync(int id)
        {
            var notification = await _context.Notifications
                .Include(n => n.User)
                .FirstOrDefaultAsync(n => n.NotificationId == id);
            return NotificationMapper.ToResponse(notification);
        }

        public async Task<NotificationResponse?> CreateAsync(CreateNotificationRequest request)
        {
            var notification = NotificationMapper.ToEntity(request);
            if (notification == null) return null;

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
            return NotificationMapper.ToResponse(notification);
        }

        public async Task<NotificationResponse?> UpdateAsync(int id, UpdateNotificationRequest request)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null) return null;

            NotificationMapper.UpdateEntity(notification, request);
            await _context.SaveChangesAsync();
            return NotificationMapper.ToResponse(notification);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null) return false;

            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<NotificationResponse>> GetUserNotificationsAsync(int userId)
        {
            var notifications = await _context.Notifications
                .Include(n => n.User)
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
            return notifications.Select(n => NotificationMapper.ToResponse(n)!);
        }

        public async Task<bool> MarkAsReadAsync(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null) return false;

            notification.IsRead = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 