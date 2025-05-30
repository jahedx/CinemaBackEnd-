using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Data;

namespace CinemaTicketBooking.Infrastructure.Mappers
{
    public static class MovieMapper
    {
        public static MovieResponse? ToResponse(Movie? movie)
        {
            if (movie == null) return null;

            return new MovieResponse
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Description = movie.Description,
                Director = movie.Director,
                Cast = movie.Cast,
                Genre = movie.Genre,
                Duration = movie.Duration ?? 0,
                ReleaseDate = movie.ReleaseDate?.ToDateTime(TimeOnly.MinValue) ?? DateTime.MinValue,
                PosterUrl = movie.PosterUrl,
                IsActive = movie.IsActive ?? false,
                Rating = (double)(movie.Rating ?? 0),
                ScreeningCount = movie.Screenings?.Count ?? 0
            };
        }

        public static Movie? ToEntity(CreateMovieRequest? request)
        {
            if (request == null) return null;

            return new Movie
            {
                Title = request.Title,
                Description = request.Description,
                Director = request.Director,
                Cast = request.Cast,
                Genre = request.Genre,
                Duration = request.Duration,
                ReleaseDate = DateOnly.FromDateTime(request.ReleaseDate),
                PosterUrl = request.PosterUrl,
                IsActive = true
            };
        }

        public static void UpdateEntity(Movie? movie, UpdateMovieRequest? request)
        {
            if (movie == null || request == null) return;

            movie.Title = request.Title;
            movie.Description = request.Description;
            movie.Director = request.Director;
            movie.Cast = request.Cast;
            movie.Genre = request.Genre;
            movie.Duration = request.Duration;
            movie.ReleaseDate = DateOnly.FromDateTime(request.ReleaseDate);
            movie.PosterUrl = request.PosterUrl;
            movie.IsActive = request.IsActive;
        }
    }
} 