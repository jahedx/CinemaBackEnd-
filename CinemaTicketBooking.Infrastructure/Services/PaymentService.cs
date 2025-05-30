using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Data;
using CinemaTicketBooking.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace CinemaTicketBooking.Infrastructure.Services
{
    public class PaymentService
    {
        private readonly ApplicationDbContext _context;

        public PaymentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaymentResponse>> GetAllAsync()
        {
            var payments = await _context.Payments.ToListAsync();
            return payments.Select(p => PaymentMapper.ToResponse(p)!);
        }

        public async Task<PaymentResponse?> GetByIdAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            return PaymentMapper.ToResponse(payment);
        }

        public async Task<PaymentResponse?> CreateAsync(CreatePaymentRequest request)
        {
            var payment = PaymentMapper.ToEntity(request);
            if (payment == null) return null;

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return PaymentMapper.ToResponse(payment);
        }

        public async Task<PaymentResponse?> UpdateAsync(int id, UpdatePaymentRequest request)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return null;

            PaymentMapper.UpdateEntity(payment, request);
            await _context.SaveChangesAsync();
            return PaymentMapper.ToResponse(payment);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return false;

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 