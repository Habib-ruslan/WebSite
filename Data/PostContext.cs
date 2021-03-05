using _1.Models;
using Microsoft.EntityFrameworkCore;

namespace _1.Data
{
    public class PostContext: DbContext
    {
        public PostContext(DbContextOptions<PostContext> options) : base(options) { }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<PostModel> PostModels { get; set; }

    }
}
