namespace CinemaTicketBooking.Contracts
{
    public class CreateScreeningRequest
    {
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
    }

    public class UpdateScreeningRequest
    {
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public int AvailableSeats { get; set; }
    }

    public class ScreeningResponse
    {
        public int ScreeningId { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public int HallId { get; set; }
        public string HallName { get; set; }
        public string CinemaName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public int AvailableSeats { get; set; }
        public int TotalSeats { get; set; }
    }
} 