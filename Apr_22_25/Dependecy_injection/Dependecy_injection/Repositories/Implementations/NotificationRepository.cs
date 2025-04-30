using Dependecy_injection.Data;
using Dependecy_injection.Models.Domain;
using Dependecy_injection.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dependecy_injection.Repositories.Implementations
{
    public class NotificationRepository: INotificationRepository
    {
        private readonly ApplicationDbContext dbContext;

        public NotificationRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Notification> CreateAsync(Notification notification)
        {
            await dbContext.Notifications.AddAsync(notification);
            await dbContext.SaveChangesAsync();
            return notification;
        }

        public async Task<IEnumerable<Notification>> GetAllAsync()
        {
            return await dbContext.Notifications.ToListAsync();
        }
    }
}
