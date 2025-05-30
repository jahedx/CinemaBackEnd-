using System;
using System.Collections.Generic;

namespace CinemaTicketBooking.Infrastructure.Data;

public partial class Seat
{
    public int SeatId { get; set; }

    public int HallId { get; set; }

    public string RowNumber { get; set; } = null!;

    public int SeatNumber { get; set; }

    public string? SeatType { get; set; }

    public virtual Hall Hall { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
