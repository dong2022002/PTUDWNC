using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.Core.Contracts;
using Shop.Core.dto;
using Shop.Core.DTO;
using Shop.Core.Entities;
using Shop.Data.Contexts;
using Shop.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shop.Services.Shops
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ShopDbContext _context;

		public CategoryRepository(ShopDbContext context)
		{
			_context = context;
		}

		public async Task<IList<T>> GetAllCategoriesProduct<T>(Func<IQueryable<ProductCategory>, IQueryable<T>> mapper, CancellationToken cancellationToken = default)
		{
			var products = _context.Set<ProductCategory>();
			return await mapper(products).ToListAsync(cancellationToken);
		}

		public async Task<IList<T>> GetRandomCategories<T>(int limit, Func<IQueryable<ProductCategory>, IQueryable<T>> mapper , CancellationToken cancellationToken = default)
		{
			var products = _context.Set<ProductCategory>()
					.OrderBy(x => Guid.NewGuid())
					.Take(limit);
			return await mapper(products).ToListAsync(cancellationToken);
		}
		public async Task<IList<CategoryItem>> GetCategoriesAsync(
		CancellationToken cancellationToken = default)
		{
			return await _context.Set<ProductCategory>()
				.OrderBy(a => a.Name)
				.Select(a => new CategoryItem()
				{
					Id = a.Id,
					Name = a.Name,
					Slug = a.Slug,
					Description = a.Description,
					ProductCount = a.Products.Count(),
				})
				.ToListAsync(cancellationToken);
		}

		public async Task<IPagedList<T>> GetPagedCategoriesAsync<T>(
			IPagingParams pagingParams,
			Func<IQueryable<ProductCategory>, IQueryable<T>> mapper,
			CategoryQuery query, 
			CancellationToken cancellationToken = default)
		{
			var categoryQuery = FilterCategory(query);

			return await mapper(categoryQuery)
				 .ToPagedListAsync(pagingParams, cancellationToken);
		}

		private IQueryable<ProductCategory> FilterCategory(CategoryQuery query)
		{
			IQueryable<ProductCategory> categories = _context.Set<ProductCategory>()
				.Include(x => x.Products);
		
			if (!query.Keyword.IsNullOrEmpty())
			{
				categories = categories.Where(x => x.Name.Contains(query.Keyword) ||
										 x.Description.Contains(query.Keyword));
			}
			return categories;
		}
		

		

		public async Task<bool> AddOrUpdateCategoryAsync(
			ProductCategory newCategory,
			CancellationToken cancellationToken = default)
		{
			if (newCategory.Id <= 0)
			{
				_context.ProductCategories.Add(newCategory);

			}
			else
			{
				_context.Set<ProductCategory>().Update(newCategory);

			}
			return (await _context.SaveChangesAsync(cancellationToken)) > 0;
		}

		public async Task<bool> IsCateogrySlugExistedAsync(int idCategory, string slug, CancellationToken cancellationToken = default)
		{
			return await _context.Set<ProductCategory>()
				.AnyAsync(x => x.Id != idCategory && x.Slug == slug,
				cancellationToken);
		}

		public async Task<ProductCategory> GetcategoryById(int id, CancellationToken cancellationToken = default)
		{
			return await _context.Set<ProductCategory>()
				.Include(x => x.Products)
				.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		}

		public async Task<ProductCategory> GetCategoryBySlug(string slug, CancellationToken cancellationToken = default)
		{
			return await _context.Set<ProductCategory>()
				.Include(x => x.Products)
				.FirstOrDefaultAsync(x => x.Slug == slug, cancellationToken);

		}

		public async Task<bool> DeleteCategoryAsync(int idCategory, CancellationToken cancellationToken = default)
		{
			var category = _context.Set<ProductCategory>()
			  .Where(t => t.Id == idCategory);
			if (category.IsNullOrEmpty()) return false;
			await category.ExecuteDeleteAsync(cancellationToken);
			return true;
		}
	}
}
