using System;
using System.Collections.Generic;

namespace CinemaTicketBooking.Infrastructure.Data;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int UserId { get; set; }

    public int ScreeningId { get; set; }

    public DateTime? ReservationDate { get; set; }

    public string? Status { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Screening Screening { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual User User { get; set; } = null!;
}
