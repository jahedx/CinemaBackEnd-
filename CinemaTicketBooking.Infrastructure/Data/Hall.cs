using System;
using System.Collections.Generic;

namespace CinemaTicketBooking.Infrastructure.Data;

public partial class Hall
{
    public int HallId { get; set; }

    public int CinemaId { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public string? Description { get; set; }

    public virtual Cinema Cinema { get; set; } = null!;

    public virtual ICollection<Screening> Screenings { get; set; } = new List<Screening>();

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
