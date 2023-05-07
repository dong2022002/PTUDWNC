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
	public interface IDiscountRepository
	{
		Task<IList<DiscountItem>> GetDiscountsAsync(
		CancellationToken cancellationToken = default);

		Task<IPagedList<T>> GetPagedDiscountAsync<T>(
			IPagingParams pagingParams,
			Func<IQueryable<Discount>, IQueryable<T>> mapper,
			DiscountQuery query,
			CancellationToken cancellationToken = default);

		Task<bool> AddOrUpdateDiscountsAsync(
			Discount newDiscount,
			CancellationToken cancellationToken = default);
		Task<bool> DeleteDiscountAsync(int idDiscount, CancellationToken cancellationToken = default);
		Task<Discount> GetDiscountById(int id, CancellationToken cancellationToken = default);
	}
}
