using SuperMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.Repository
{
	public interface IProductsRepository
	{
		ProductModel Get(Guid id);
		IEnumerable<ProductModel> GetAll();
		Boolean Create(ProductModel product);
		ProductModel Update(ProductModel product);
		ProductModel Delete(int id);
	}
}
