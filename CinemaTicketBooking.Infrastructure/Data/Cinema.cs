using System;
using System.Collections.Generic;

namespace CinemaTicketBooking.Infrastructure.Data;

public partial class Cinema
{
    public int CinemaId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Hall> Halls { get; set; } = new List<Hall>();
}
