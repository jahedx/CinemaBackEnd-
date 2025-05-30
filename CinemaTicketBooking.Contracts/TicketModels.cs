namespace CinemaTicketBooking.Contracts
{
    public class CreateTicketRequest
    {
        public int ReservationId { get; set; }
        public int SeatId { get; set; }
        public decimal Price { get; set; }
    }

    public class UpdateTicketRequest
    {
        public int ReservationId { get; set; }
        public int SeatId { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }

    public class TicketResponse
    {
        public int TicketId { get; set; }
        public int ReservationId { get; set; }
        public int SeatId { get; set; }
        public string SeatInfo { get; set; }
        public string MovieTitle { get; set; }
        public string CinemaName { get; set; }
        public string HallName { get; set; }
        public DateTime ScreeningTime { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
} 