﻿using SuperMarket.Domain.Models;
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
			return await dbContext.Products.ToListAsync();
		}

		public async void Create(ProductModel product)
		{
			if (product.Discount is null)
			{
				product.Discount = 0;
			}
			await dbContext.Products.AddAsync(product);
			dbContext.SaveChanges();
		}
		public async void Update(ProductModel product)
		{
			var item =await dbContext.Products.FindAsync(product.id);
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

		public async void Delete(Guid id)
		{
			var item = await dbContext.Products.FindAsync(id);
			if (item is not null)
			{
				dbContext.Products.Remove(item);
				dbContext.SaveChanges();
			}
		}
	}
}
