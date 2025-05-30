using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Data;

namespace CinemaTicketBooking.Infrastructure.Mappers
{
    public static class HallMapper
    {
        public static HallResponse? ToResponse(Hall? hall)
        {
            if (hall == null) return null;

            return new HallResponse
            {
                HallId = hall.HallId,
                CinemaId = hall.CinemaId,
                CinemaName = hall.Cinema?.Name,
                Name = hall.Name,
                Capacity = hall.Capacity
            };
        }

        public static Hall? ToEntity(CreateHallRequest? request)
        {
            if (request == null) return null;

            return new Hall
            {
                CinemaId = request.CinemaId,
                Name = request.Name,
                Capacity = request.Capacity
            };
        }

        public static void UpdateEntity(Hall? hall, UpdateHallRequest? request)
        {
            if (hall == null || request == null) return;

            hall.CinemaId = request.CinemaId;
            hall.Name = request.Name;
            hall.Capacity = request.Capacity;
        }
    }
} 