using _1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1.Data
{
    public class ImageContext: DbContext
    {
        public ImageContext(DbContextOptions<ImageContext> options) : base(options) { }
        public DbSet<ImageModel> ImageModels{ get; set; }
    }
}
