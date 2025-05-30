using System;
using System.Collections.Generic;

namespace CinemaTicketBooking.Infrastructure.Data;

public partial class Screening
{
    public int ScreeningId { get; set; }

    public int MovieId { get; set; }

    public int HallId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public decimal Price { get; set; }

    public decimal? Discount { get; set; }

    public int AvailableSeats { get; set; }

    public virtual Hall Hall { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
