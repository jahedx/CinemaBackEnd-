using CinemaTicketBooking.Contracts;
using CinemaTicketBooking.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentResponse>>> Get()
        {
            var payments = await _paymentService.GetAllAsync();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentResponse>> Get(int id)
        {
            var payment = await _paymentService.GetByIdAsync(id);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult<PaymentResponse>> Post(CreatePaymentRequest request)
        {
            var payment = await _paymentService.CreateAsync(request);
            if (payment == null) return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = payment.PaymentId }, payment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentResponse>> Put(int id, UpdatePaymentRequest request)
        {
            var payment = await _paymentService.UpdateAsync(id, request);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _paymentService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
} 