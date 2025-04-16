using HelloWorldWebApi_2.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldWebApi_2.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //public DbSet<BlogPost> BlogPosts { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}
