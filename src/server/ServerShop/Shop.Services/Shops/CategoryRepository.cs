using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;
using Shop.Data.Contexts;
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

		
	}
}
