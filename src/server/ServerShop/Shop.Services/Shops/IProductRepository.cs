using Azure;
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
		Task<IList<T>> GetProductFeatured<T>(
			int number,
			Func<IQueryable<Product>, IQueryable<T>> mapper, 
			CancellationToken cancellationToken= default);

		//getNewProducts
		Task<IList<T>> GetNewProduct<T>(
			int number,
			Func<IQueryable<Product>, IQueryable<T>> mapper,
			CancellationToken cancellationToken =default);

		//getDiscountProducts
		Task<IList<T>> GetDiscountProduct<T>(
			int number,
			Func<IQueryable<Product>, IQueryable<T>> mapper,
			CancellationToken cancellationToken =default);

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

		Task<IPagedList<T>> GetPagedProductAsync<T>(
			 IPagingParams pagingParams,
			 Func<IQueryable<Product>, IQueryable<T>> mapper,
			 ProductQuery query,
			 CancellationToken cancellationToken = default);

		Task<bool> AddOrUpdateProductsAsync(
			Product newProduct,
			CancellationToken cancellationToken = default);

		Task<bool> DeleteProductAsync(
		int idProduct,
		CancellationToken cancellationToken = default);

		Task<bool> IsProductSlugExistedAsync(
		  int idProduct,
		  string slug,
		  CancellationToken cancellationToken = default);
	}
}
