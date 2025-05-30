using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Data;

namespace CinemaTicketBooking.Infrastructure.Mappers
{
    public static class ReservationMapper
    {
        public static ReservationResponse? ToResponse(Reservation? reservation)
        {
            if (reservation == null) return null;

            return new ReservationResponse
            {
                ReservationId = reservation.ReservationId,
                UserId = reservation.UserId,
                UserName = $"{reservation.User?.FirstName} {reservation.User?.LastName}",
                ScreeningId = reservation.ScreeningId,
                MovieTitle = reservation.Screening?.Movie?.Title,
                CinemaName = reservation.Screening?.Hall?.Cinema?.Name,
                HallName = reservation.Screening?.Hall?.Name,
                ScreeningTime = reservation.Screening?.StartTime ?? DateTime.UtcNow,
                Status = reservation.Status,
                TotalPrice = reservation.TotalPrice,
                ReservationDate = reservation.ReservationDate ?? DateTime.UtcNow,
                SeatInfo = reservation.Tickets
                    .Select(t => t.Seat?.SeatNumber.ToString())
                    .Where(s => s != null)
                    .ToList()!
            };
        }

        public static Reservation? ToEntity(CreateReservationRequest? request)
        {
            if (request == null) return null;

            return new Reservation
            {
                UserId = request.UserId,
                ScreeningId = request.ScreeningId,
                Status = "Pending"
            };
        }

        public static void UpdateEntity(Reservation? reservation, UpdateReservationRequest? request)
        {
            if (reservation == null || request == null) return;

            reservation.UserId = request.UserId;
            reservation.ScreeningId = request.ScreeningId;
            reservation.Status = request.Status ?? reservation.Status;
            reservation.TotalPrice = request.TotalPrice;
        }
    }
} 