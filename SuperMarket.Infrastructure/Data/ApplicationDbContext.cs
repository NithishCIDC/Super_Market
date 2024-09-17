using Microsoft.EntityFrameworkCore;
using SuperMarket.Domain.Models;

namespace SuperMarket.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ProductModel> Products { get; set; }
    }
}
