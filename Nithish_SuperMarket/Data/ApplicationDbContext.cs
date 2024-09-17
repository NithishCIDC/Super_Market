using Microsoft.EntityFrameworkCore;
using Nithish_SuperMarket.Models;

namespace Nithish_SuperMarket.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
        }
        public DbSet<ProductModel> Products { get; set; }
    }
}
