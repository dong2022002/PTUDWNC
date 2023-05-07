using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.Core.Contracts;
using Shop.Core.dto;
using Shop.Core.Entities;
using Shop.Data.Contexts;
using Shop.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Shops
{
	public class DiscountRepository : IDiscountRepository
	{
		private readonly ShopDbContext _context;

		public DiscountRepository(ShopDbContext context)
		{
			_context = context;
		}
		public async Task<IList<DiscountItem>> GetDiscountsAsync(CancellationToken cancellationToken = default)
		{
			return await _context.Set<Discount>()
				.OrderBy(a => a.Name)
				.Select(a => new DiscountItem()
				{
					Id = a.Id,
					Name = a.Name,
					DiscountPercent = a.DiscountPercent,
					Description = a.Description,
					Active = a.Active,
					ProductCount = a.Products.Count(),
				})
				.ToListAsync(cancellationToken);
		}

		public async Task<IPagedList<T>> GetPagedDiscountAsync<T>(
			IPagingParams pagingParams, Func<IQueryable<Discount>,
				IQueryable<T>> mapper, DiscountQuery query, 
			CancellationToken cancellationToken = default)
		{
			var discountQuery = FilterDiscount(query);

			return await mapper(discountQuery)
				 .ToPagedListAsync(pagingParams, cancellationToken);
		}

		private IQueryable<Discount> FilterDiscount(DiscountQuery query)
		{
			IQueryable<Discount> discount = _context.Set<Discount>()
				.Include(x => x.Products);

			if (!query.Keyword.IsNullOrEmpty())
			{
				discount = discount.Where(x => x.Name.Contains(query.Keyword) ||
										 x.Description.Contains(query.Keyword));
			}
			return discount;
		}

		public async Task<bool> AddOrUpdateDiscountsAsync(
			Discount newDiscount,
			CancellationToken cancellationToken = default)
		{
			if (newDiscount.Id <= 0)
			{
				_context.Discounts.Add(newDiscount);

			}
			else
			{
				_context.Set<Discount>().Update(newDiscount);

			}
			return (await _context.SaveChangesAsync(cancellationToken)) > 0;
		}

		public async Task<Discount> GetDiscountById(int id, CancellationToken cancellationToken = default)
		{
			return await _context.Set<Discount>()
				.Include(x => x.Products)
				.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		}
		public async Task<bool> DeleteDiscountAsync(int idDiscount, CancellationToken cancellationToken = default)
		{
			var discount = _context.Set<Discount>()
			  .Where(t => t.Id == idDiscount);
			if (discount.IsNullOrEmpty()) return false;
			await discount.ExecuteDeleteAsync(cancellationToken);
			return true;
		}
	}
}
