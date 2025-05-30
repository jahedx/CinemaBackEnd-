namespace CinemaTicketBooking.Contracts
{
    public class CreateReservationRequest
    {
        public int UserId { get; set; }
        public int ScreeningId { get; set; }
        public List<int> SeatIds { get; set; }
    }

    public class UpdateReservationRequest
    {
        public int UserId { get; set; }
        public int ScreeningId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }

    public class ReservationResponse
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ScreeningId { get; set; }
        public string MovieTitle { get; set; }
        public string CinemaName { get; set; }
        public string HallName { get; set; }
        public DateTime ScreeningTime { get; set; }
        public List<string> SeatInfo { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime ReservationDate { get; set; }
    }
} 