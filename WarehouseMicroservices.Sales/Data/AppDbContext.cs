using Microsoft.EntityFrameworkCore;
using WarehouseMicroservices.Sales.Models;

namespace WarehouseMicroservices.Sales.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
