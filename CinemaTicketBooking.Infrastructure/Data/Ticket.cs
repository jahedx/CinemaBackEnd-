using System;
using System.Collections.Generic;

namespace CinemaTicketBooking.Infrastructure.Data;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int ReservationId { get; set; }

    public int SeatId { get; set; }

    public decimal Price { get; set; }

    public string? Status { get; set; }

    public virtual Reservation Reservation { get; set; } = null!;

    public virtual Seat Seat { get; set; } = null!;
}
