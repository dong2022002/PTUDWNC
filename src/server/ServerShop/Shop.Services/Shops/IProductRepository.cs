using Shop.Core.Contracts;
using Shop.Core.DTO;
using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Shops
{
	public interface IProductRepository
	{
		Task<IList<Product>> GetAllProducts(CancellationToken cancellationToken = default);
		//getProductId
		Task<Product> GetProductById(int id,CancellationToken cancellationToken =default);

		//getProductFeatured
		Task<IList<Product>> GetProductFeatured(int number = 0, CancellationToken cancellationToken= default);

		//getNewProducts
		Task<IList<Product>> GetNewProduct(int number = 0, CancellationToken cancellationToken=default);

		//getDiscountProducts
		Task<IList<Product>> GetDiscountProduct(int number =0, CancellationToken cancellationToken=default);

		//getProductbyCategory
	

		//getProductRandom
		Task<IList<Product>> getProductRandom(int number, CancellationToken cancellationToken=default);

		Task IncreaseViewCountAsync(
			int productId,
			CancellationToken cancellationToken = default);

		Task<IPagedList<Product>> GetPagedProductAsync(
			   IPagingParams pagingParams,
			   ProductQuery query,
			   CancellationToken cancellationToken = default);
	}
}
