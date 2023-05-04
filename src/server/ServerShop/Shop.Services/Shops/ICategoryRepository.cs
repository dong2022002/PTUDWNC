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

		Task<IList<T>> GetAllCategoriesProduct<T>(Func<IQueryable<ProductCategory>, IQueryable<T>> mapper,CancellationToken cancellationToken = default);
		Task<IList<T>> GetRandomCategories<T>(int limit, Func<IQueryable<ProductCategory>, IQueryable<T>> mapper ,CancellationToken cancellationToken = default);
	}
}
