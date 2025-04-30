using Dependecy_injection.Models.Domain;

namespace Dependecy_injection.Repositories.Interfaces
{
    public interface  INotificationRepository
    {
        Task<Notification> CreateAsync(Notification Notification);

        Task<IEnumerable<Notification>> GetAllAsync();
    }
}
