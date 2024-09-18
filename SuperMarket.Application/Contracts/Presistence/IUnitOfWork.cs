namespace SuperMarket.Application.Contracts.Presistence
{
	public interface IUnitOfWork
	{
		public IProductsRepository ProductsRepository { get; }
		Task<int> SaveAsync();
	}
}
