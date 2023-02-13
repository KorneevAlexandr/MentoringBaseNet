using Microsoft.EntityFrameworkCore;
using MvcTask.Models.DbModels;

namespace MvcTask.Infrastructure
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
