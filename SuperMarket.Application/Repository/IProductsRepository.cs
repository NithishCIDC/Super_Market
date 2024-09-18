using SuperMarket.Domain.Models;

namespace SuperMarket.Application.Repository
{
	public interface IProductsRepository
	{
		ProductModel Get(Guid id);
		IEnumerable<ProductModel> GetAll();
		Boolean Create(ProductModel product);
		void Update(ProductModel product);
		void Delete(Guid id);
	}
}
