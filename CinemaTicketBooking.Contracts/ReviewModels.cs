namespace CinemaTicketBooking.Contracts
{
    public class CreateReviewRequest
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }

    public class UpdateReviewRequest
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public bool IsApproved { get; set; }
    }

    public class ReviewResponse
    {
        public int ReviewId { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ReviewDate { get; set; }
    }
} 