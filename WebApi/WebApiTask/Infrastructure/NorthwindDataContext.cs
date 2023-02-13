using Microsoft.EntityFrameworkCore;
using WebApiTask.Models.DbModels;

namespace WebApiTask.Infrastructure
{
    public class NorthwindDataContext : DbContext
    {
        public NorthwindDataContext(DbContextOptions<NorthwindDataContext> options)
            : base(options)
        { }

        public DbSet<Category> Categories { get; }

        public DbSet<Product> Products { get; }
    }
}
