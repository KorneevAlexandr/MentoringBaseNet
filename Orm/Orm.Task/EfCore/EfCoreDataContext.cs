using Microsoft.EntityFrameworkCore;
using Orm.Task.Models;

namespace Orm.Task.EfCore
{
    public class EfCoreDataContext : DbContext
    {
        private readonly string _connectionString;

        public EfCoreDataContext(string connectionString)
        {
            _connectionString= connectionString;
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
