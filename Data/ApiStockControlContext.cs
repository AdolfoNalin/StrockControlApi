using Microsoft.EntityFrameworkCore;
using StockControlApi.Models;

namespace StockControlApi.Data
{
    public class ApiStockControlContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<User> User{ get; set; }
        public DbSet<Brand> Brand{ get; set; }
        public ApiStockControlContext(
            DbContextOptions<ApiStockControlContext> options)
            : base(options)
        {
        }
    }
}