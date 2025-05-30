using System;
using System.Collections.Generic;

namespace CinemaTicketBooking.Infrastructure.Data;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public string? Director { get; set; }

    public string? Cast { get; set; }

    public string? Genre { get; set; }

    public int? Duration { get; set; }

    public string? Description { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public string? PosterUrl { get; set; }

    public decimal? Rating { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Screening> Screenings { get; set; } = new List<Screening>();
}
