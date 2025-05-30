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
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationResponse>>> Get()
        {
            var notifications = await _notificationService.GetAllAsync();
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationResponse>> Get(int id)
        {
            var notification = await _notificationService.GetByIdAsync(id);
            if (notification == null)
                return NotFound();

            return Ok(notification);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<NotificationResponse>>> GetUserNotifications(int userId)
        {
            var notifications = await _notificationService.GetUserNotificationsAsync(userId);
            return Ok(notifications);
        }

        [HttpPost]
        public async Task<ActionResult<NotificationResponse>> Post(CreateNotificationRequest request)
        {
            var notification = await _notificationService.CreateAsync(request);
            if (notification == null)
                return BadRequest();

            return CreatedAtAction(nameof(Get), new { id = notification.NotificationId }, notification);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NotificationResponse>> Put(int id, UpdateNotificationRequest request)
        {
            var notification = await _notificationService.UpdateAsync(id, request);
            if (notification == null)
                return NotFound();

            return Ok(notification);
        }

        [HttpPut("{id}/mark-as-read")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var result = await _notificationService.MarkAsReadAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _notificationService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
} 