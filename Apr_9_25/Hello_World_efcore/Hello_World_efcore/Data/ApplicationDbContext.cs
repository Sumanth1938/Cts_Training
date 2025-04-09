using Hello_World_efcore.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hello_World_efcore.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
