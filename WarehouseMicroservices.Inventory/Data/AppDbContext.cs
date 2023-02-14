using Microsoft.EntityFrameworkCore;
using WarehouseMicroservices.Inventory.Models;

namespace WarehouseMicroservices.Inventory.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
