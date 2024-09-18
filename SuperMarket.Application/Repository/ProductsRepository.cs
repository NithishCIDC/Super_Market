using SuperMarket.Domain.Models;
using SuperMarket.Infrastructure.Data;

namespace SuperMarket.Application.Repository
{
	public class ProductsRepository : IProductsRepository
	{
		private readonly ApplicationDbContext dbContext;
        public ProductsRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ProductModel Get(Guid id)
		{
				ProductModel item = dbContext.Products.Find(id)!;
				return item;
		}

		public IEnumerable<ProductModel> GetAll()
		{
			List<ProductModel> ProductList = dbContext.Products.ToList();
			return ProductList;
		}

		public Boolean Create(ProductModel product)
		{
			if (product.Discount is null)
			{
				product.Discount = 0;
			}
			dbContext.Products.AddAsync(product);
			dbContext.SaveChanges();
			return true;
		}
		public void Update(ProductModel product)
		{
			var item = dbContext.Products.Find(product.id);
			if (item is not null)
			{
				item.Name = product.Name;
				item.Quantity = product.Quantity;
				item.Price = product.Price;
				if (product.Discount is not null)
					item.Discount = product.Discount;
				else
					item.Discount = 0;
			}
			dbContext.SaveChanges();
		}

		public void Delete(Guid id)
		{
			var item = dbContext.Products.Find(id);
			if (item is not null)
			{
				dbContext.Products.Remove(item);
				dbContext.SaveChanges();
			}
		}

	}
}
