using SuperMarket.Domain.Models;

namespace SuperMarket.Application.Contracts.Presistence
{
    public interface IProductsRepository
    {
        Task<ProductModel?> Get(Guid id);
        Task<IEnumerable<ProductModel>> GetAll();
        void Create(ProductModel product);
        void Update(ProductModel product);
        void Delete(Guid id);
    }
}
