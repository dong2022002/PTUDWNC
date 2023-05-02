using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.Core.Contracts;
using Shop.Core.DTO;
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
	public class ProductRepository : IProductRepository
	{
		private readonly ShopDbContext _context;

        public ProductRepository(ShopDbContext context)
        {
            _context = context;
        }

		public async Task<IList<Product>> GetAllProducts(CancellationToken cancellationToken = default)
		{
			IQueryable<Product> products = _context.Set<Product>();

			return await products
				.ToListAsync(cancellationToken);
		}

		public async Task<IList<Product>> GetDiscountProduct(int number = 0, CancellationToken cancellationToken = default)
		{
			IQueryable<Product> products = _context.Set<Product>()
														.Include(x => x.Discount)
														.OrderByDescending(x => x.Discount.DiscountPercent);
			if (number > 0)
			{
				products
				    .Take(number);
			}
			return await products.ToListAsync(cancellationToken);
        }

		public async Task<IList<Product>> GetNewProduct(int number = 0, CancellationToken cancellationToken = default)
		{
			IQueryable<Product> products = _context.Set<Product>()
														.OrderByDescending(x => x.CreatedAt);
			if (number > 0)
			{
				products
					.Take(number);
			}
			return await products.ToListAsync(cancellationToken);
		}

		public async Task<IPagedList<Product>> GetPagedProductAsync(IPagingParams pagingParams, ProductQuery query, CancellationToken cancellationToken = default)
		{
			var productQuery = FilterProducts(query);

			return await productQuery.ToPagedListAsync(pagingParams, cancellationToken);
		}

		private IQueryable<Product> FilterProducts(ProductQuery query)
		{
			IQueryable<Product> products = _context.Set<Product>()
													.Include(p => p.ProductCategory)
													.Include(p => p.Discount);
            if (query.TitleSlug != null)
            {
				products = products.Where(x => x.slug == query.TitleSlug);
            }
            if (query.CategorySlug != null)
            {
				products = products.Where(x => x.ProductCategory.Slug == query.CategorySlug);
			}

			if (query.CategoryId != null)
			{
				products = products.Where(x => x.ProductCategoryId == query.CategoryId);
			}
			if (!query.Keyword.IsNullOrEmpty())
			{
				products = products.Where(x => x.Name.Contains(query.Keyword) ||
										 x.Description.Contains(query.Keyword) ||
										 x.ProductCategory.Name.Contains(query.Keyword));
			}
			return products;
		}

		public async Task<Product> GetProductById(int id, CancellationToken cancellationToken = default)
		{
			return await _context.Set<Product>()
				.Include(x => x.Discount)
				.Include(x => x.ProductCategory)
				.FirstOrDefaultAsync(cancellationToken);
		}

		public async Task<IList<Product>> GetProductFeatured(int number = 0, CancellationToken cancellationToken = default)
		{
			IQueryable<Product> products = _context.Set<Product>()
														.OrderByDescending(x => x.viewCount);
			if (number > 0)
			{
				products
					.Take(number);
			}
			return await products.ToListAsync(cancellationToken);
		}

		public async Task<IList<Product>> getProductRandom(int number, CancellationToken cancellationToken = default)
		{
			return await _context.Set<Product>()
				.OrderBy(x => Guid.NewGuid())
				.Take(number)
				.ToListAsync(cancellationToken);
		}

		public async Task IncreaseViewCountAsync(
			int productId,
			CancellationToken cancellationToken = default)
		{
			await _context.Set<Product>()
				 .Where(x => x.Id == productId)
				 .ExecuteUpdateAsync(p =>
					 p.SetProperty(x => x.viewCount, x => x.viewCount + 1),
					 cancellationToken);
		}

	}
}
