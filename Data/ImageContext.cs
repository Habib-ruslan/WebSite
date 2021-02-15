using _1.Models;
using Microsoft.EntityFrameworkCore;

namespace _1.Models
{
    public class ImageContext : DbContext
    {
        public DbSet<ImageModel> Images { get; set; }
        public ImageContext(DbContextOptions<ImageContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}