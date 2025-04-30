using Dependecy_injection.Models.Domain;
using Dependecy_injection.Repositories.Interfaces;
using Dependecy_injection.Repositories.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dependecy_injection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository notificationRepository;

        public NotificationController(INotificationRepository notificationRepository)
        {
            this.notificationRepository = notificationRepository;
        }

        [HttpPost]
        [Route("CreateNotification")]
        public async Task<IActionResult> CreateNotification([FromBody] Notification request)
        {

            var notification = await notificationRepository.CreateAsync(request);

            return Ok(request);
        }

        [HttpGet]
        [Route("GetAllNotifications")]
        public async Task<IActionResult> GetAllNotifications()
        {
            var notifications = await notificationRepository.GetAllAsync();

            var response = new List<Notification>();
            foreach (var notification in notifications)
            {
                response.Add(new Notification
                {
                    UserId = notification.UserId,
                    EventId = notification.EventId,
                    Message = notification.Message,
                    SentTimestamp = notification.SentTimestamp
                });
            }

            return Ok(response);
        }
    }
}
