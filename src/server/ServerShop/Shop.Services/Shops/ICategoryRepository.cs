using Shop.Core.Contracts;
using Shop.Core.dto;
using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Shops
{
	public interface ICategoryRepository
	{
		Task<IList<CategoryItem>> GetCategoriesAsync(
		CancellationToken cancellationToken = default);
		Task<IPagedList<T>> GetPagedCategoriesAsync<T>(
			IPagingParams pagingParams,
			Func<IQueryable<ProductCategory>, IQueryable<T>> mapper,
			CategoryQuery query,
			CancellationToken cancellationToken = default);
		Task<bool> AddOrUpdateCategoryAsync(
			ProductCategory newCategory,
			CancellationToken cancellationToken = default);
		Task<bool> IsCateogrySlugExistedAsync(int idCategory, string slug, CancellationToken cancellationToken = default);
		Task<ProductCategory> GetcategoryById(int id, CancellationToken cancellationToken = default);
		Task<bool> DeleteCategoryAsync(int idCategory, CancellationToken cancellationToken = default);
		Task<ProductCategory> GetCategoryBySlug(string slug, CancellationToken cancellationToken = default);
		Task<IList<T>> GetAllCategoriesProduct<T>(Func<IQueryable<ProductCategory>, IQueryable<T>> mapper,CancellationToken cancellationToken = default);
		Task<IList<T>> GetRandomCategories<T>(int limit, Func<IQueryable<ProductCategory>, IQueryable<T>> mapper ,CancellationToken cancellationToken = default);
	}
}
