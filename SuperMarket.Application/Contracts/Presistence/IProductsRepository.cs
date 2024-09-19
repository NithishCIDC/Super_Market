using SuperMarket.Domain.Models;

namespace SuperMarket.Application.Contracts.Presistence
{
    public interface IProductsRepository
    {
        Task<ProductModel?> Get(Guid id);
        Task<IEnumerable<ProductModel>> GetAll();
        Task Create(ProductModel product);
        Task Update(ProductModel product);
        Task Delete(Guid id);
    }
}
