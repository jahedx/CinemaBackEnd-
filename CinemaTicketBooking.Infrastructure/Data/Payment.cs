using System;
using System.Collections.Generic;

namespace CinemaTicketBooking.Infrastructure.Data;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int ReservationId { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string? TransactionId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? PaymentDate { get; set; }

    public virtual Reservation Reservation { get; set; } = null!;
}
