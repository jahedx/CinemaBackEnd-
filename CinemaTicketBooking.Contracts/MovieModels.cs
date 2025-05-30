namespace CinemaTicketBooking.Contracts
{
    public class CreateMovieRequest
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Director { get; set; }
        public required string Cast { get; set; }
        public required string Genre { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? PosterUrl { get; set; }
    }

    public class UpdateMovieRequest
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Director { get; set; }
        public required string Cast { get; set; }
        public required string Genre { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? PosterUrl { get; set; }
        public bool IsActive { get; set; }
    }

    public class MovieResponse
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? PosterUrl { get; set; }
        public bool IsActive { get; set; }
        public double Rating { get; set; }
        public int ScreeningCount { get; set; }
    }
} 