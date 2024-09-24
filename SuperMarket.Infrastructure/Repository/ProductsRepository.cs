using SuperMarket.Domain.Models;
using SuperMarket.Infrastructure.Data;
using SuperMarket.Application.Contracts.Presistence;
using Microsoft.EntityFrameworkCore;

namespace SuperMarket.Infrastructure.Repository
{
	public class ProductsRepository : IProductsRepository
	{
		private readonly ApplicationDbContext dbContext;
		public ProductsRepository(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<ProductModel?> Get(Guid id)
		{
			ProductModel? item =await dbContext.Products.FindAsync(id);
			return item;
		}

		public async Task<IEnumerable<ProductModel>> GetAll()
		{
			var productList= await dbContext.Products.ToListAsync();
			return productList;
		}

		public async Task Create(ProductModel product)
		{
			await dbContext.Products.AddAsync(product);
		}
		public async Task Update(ProductModel product)
		{
			var item =await dbContext.Products.FindAsync(product.id);
			if (item is not null)
			{
				item.Name = product.Name;
				item.Quantity = product.Quantity;
				item.Price = product.Price;
				item.Discount = product.Discount;
			}
		}

		public async Task Delete(Guid id)
		{
			var item = await dbContext.Products.FindAsync(id);
			if (item is not null)
			{
				dbContext.Products.Remove(item);
			}
		}
	}
}
