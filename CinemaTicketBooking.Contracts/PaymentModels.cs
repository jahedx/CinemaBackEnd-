namespace CinemaTicketBooking.Contracts
{
    public class CreatePaymentRequest
    {
        public int ReservationId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }

    public class UpdatePaymentRequest
    {
        public int ReservationId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string? TransactionId { get; set; }
    }

    public class PaymentResponse
    {
        public int PaymentId { get; set; }
        public int ReservationId { get; set; }
        public string UserName { get; set; }
        public string MovieTitle { get; set; }
        public DateTime ScreeningTime { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string? TransactionId { get; set; }
        public DateTime PaymentDate { get; set; }
    }
} 