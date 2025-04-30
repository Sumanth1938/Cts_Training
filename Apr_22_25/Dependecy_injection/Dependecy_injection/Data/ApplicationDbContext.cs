using Dependecy_injection.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dependecy_injection.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }

    }
}
