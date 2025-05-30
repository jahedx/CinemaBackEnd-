using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Data;

namespace CinemaTicketBooking.Infrastructure.Mappers
{
    public static class NotificationMapper
    {
        public static NotificationResponse? ToResponse(Notification? notification)
        {
            if (notification == null) return null;

            return new NotificationResponse
            {
                NotificationId = notification.NotificationId,
                UserId = notification.UserId,
                UserName = $"{notification.User?.FirstName} {notification.User?.LastName}",
                Title = notification.Title,
                Message = notification.Message,
                NotificationType = notification.NotificationType,
                IsRead = notification.IsRead ?? false,
                CreatedAt = notification.CreatedAt ?? DateTime.UtcNow
            };
        }

        public static Notification? ToEntity(CreateNotificationRequest? request)
        {
            if (request == null) return null;

            return new Notification
            {
                UserId = request.UserId,
                Title = request.Title,
                Message = request.Message,
                NotificationType = request.NotificationType,
                IsRead = false,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateEntity(Notification? notification, UpdateNotificationRequest? request)
        {
            if (notification == null || request == null) return;

            notification.Title = request.Title;
            notification.Message = request.Message;
            notification.NotificationType = request.NotificationType;
            notification.IsRead = request.IsRead;
        }
    }
} 