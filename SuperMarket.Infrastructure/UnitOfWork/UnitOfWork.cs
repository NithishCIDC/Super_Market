using SuperMarket.Application.Contracts.Presistence;
using SuperMarket.Infrastructure.Data;
using SuperMarket.Infrastructure.Repository;

namespace SuperMarket.Infrastructure.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext dbContext;

		public UnitOfWork(ApplicationDbContext dbContext)
        {
			this.dbContext = dbContext;
			ProductsRepository = new ProductsRepository(dbContext);
		}

		public IProductsRepository ProductsRepository {  get; private set; }

		public async Task<int> SaveAsync()
		{
			return await dbContext.SaveChangesAsync();
		}
	}
}
