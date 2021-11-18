using Microsoft.EntityFrameworkCore;
using OnlineShop2022.Models;

namespace OnlineShop2022.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
