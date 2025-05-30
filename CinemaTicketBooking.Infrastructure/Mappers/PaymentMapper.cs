using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Data;

namespace CinemaTicketBooking.Infrastructure.Mappers
{
    public static class PaymentMapper
    {
        public static PaymentResponse? ToResponse(Payment? payment)
        {
            if (payment == null) return null;

            return new PaymentResponse
            {
                PaymentId = payment.PaymentId,
                ReservationId = payment.ReservationId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                Status = payment.Status
            };
        }

        public static Payment? ToEntity(CreatePaymentRequest? request)
        {
            if (request == null) return null;

            return new Payment
            {
                ReservationId = request.ReservationId,
                Amount = request.Amount,
                PaymentMethod = request.PaymentMethod,
                Status = "Pending"
            };
        }

        public static void UpdateEntity(Payment? payment, UpdatePaymentRequest? request)
        {
            if (payment == null || request == null) return;

            payment.ReservationId = request.ReservationId;
            payment.Amount = request.Amount;
            payment.PaymentMethod = request.PaymentMethod;
            payment.Status = request.Status ?? payment.Status;
        }
    }
} 