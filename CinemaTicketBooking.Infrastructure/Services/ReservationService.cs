using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Data;
using CinemaTicketBooking.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketBooking.Infrastructure.Services
{
    public class ReservationService
    {
        private readonly ApplicationDbContext _context;
        private const decimal DEFAULT_TICKET_PRICE = 10.00m;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReservationResponse>> GetAllAsync()
        {
            var reservations = await _context.Reservations
                .Include(r => r.User)
                .Include(r => r.Screening)
                    .ThenInclude(s => s.Movie)
                .Include(r => r.Screening)
                    .ThenInclude(s => s.Hall)
                        .ThenInclude(h => h.Cinema)
                .Include(r => r.Tickets)
                    .ThenInclude(t => t.Seat)
                .ToListAsync();
            return reservations.Select(r => ReservationMapper.ToResponse(r)!);
        }

        public async Task<ReservationResponse?> GetByIdAsync(int id)
        {
            var reservation = await _context.Reservations
                .Include(r => r.User)
                .Include(r => r.Screening)
                    .ThenInclude(s => s.Movie)
                .Include(r => r.Screening)
                    .ThenInclude(s => s.Hall)
                        .ThenInclude(h => h.Cinema)
                .Include(r => r.Tickets)
                    .ThenInclude(t => t.Seat)
                .FirstOrDefaultAsync(r => r.ReservationId == id);
            return ReservationMapper.ToResponse(reservation);
        }

        public async Task<ReservationResponse?> CreateAsync(CreateReservationRequest request)
        {
            var reservation = ReservationMapper.ToEntity(request);
            if (reservation == null) return null;

            // Get the screening to verify it exists
            var screening = await _context.Screenings
                .Include(s => s.Hall)
                .FirstOrDefaultAsync(s => s.ScreeningId == request.ScreeningId);
            if (screening == null) return null;

            // Create tickets for each seat
            foreach (var seatId in request.SeatIds)
            {
                var seat = await _context.Seats.FindAsync(seatId);
                if (seat == null) continue;

                var ticket = new Ticket
                {
                    Reservation = reservation,
                    SeatId = seatId,
                    Price = DEFAULT_TICKET_PRICE,
                    Status = "Booked"
                };
                reservation.Tickets.Add(ticket);
            }

            // Calculate total price
            reservation.TotalPrice = reservation.Tickets.Sum(t => t.Price);
            reservation.ReservationDate = DateTime.UtcNow;

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return ReservationMapper.ToResponse(reservation);
        }

        public async Task<ReservationResponse?> UpdateAsync(int id, UpdateReservationRequest request)
        {
            var reservation = await _context.Reservations
                .Include(r => r.Tickets)
                .FirstOrDefaultAsync(r => r.ReservationId == id);
            if (reservation == null) return null;

            ReservationMapper.UpdateEntity(reservation, request);
            await _context.SaveChangesAsync();
            return ReservationMapper.ToResponse(reservation);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null) return false;

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 