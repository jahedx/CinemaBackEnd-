namespace CinemaTicketBooking.Contracts
{
    public class CreateNotificationRequest
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string NotificationType { get; set; }
    }

    public class UpdateNotificationRequest
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string NotificationType { get; set; }
        public bool IsRead { get; set; }
    }

    public class NotificationResponse
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string NotificationType { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
} 