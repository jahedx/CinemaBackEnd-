using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Data;

namespace CinemaTicketBooking.Infrastructure.Mappers
{
    public static class CinemaMapper
    {
        public static CinemaResponse? ToResponse(Cinema? cinema)
        {
            if (cinema == null) return null;

            return new CinemaResponse
            {
                CinemaId = cinema.CinemaId,
                Name = cinema.Name,
                Address = cinema.Address,
                City = cinema.City,
                Phone = cinema.Phone,
                Email = cinema.Email,
                HallCount = cinema.Halls?.Count ?? 0
            };
        }

        public static Cinema? ToEntity(CreateCinemaRequest? request)
        {
            if (request == null) return null;

            return new Cinema
            {
                Name = request.Name,
                Address = request.Address,
                City = request.City,
                Phone = request.Phone,
                Email = request.Email
            };
        }

        public static void UpdateEntity(Cinema? cinema, UpdateCinemaRequest? request)
        {
            if (cinema == null || request == null) return;

            cinema.Name = request.Name;
            cinema.Address = request.Address;
            cinema.City = request.City;
            cinema.Phone = request.Phone;
            cinema.Email = request.Email;
        }
    }
} 