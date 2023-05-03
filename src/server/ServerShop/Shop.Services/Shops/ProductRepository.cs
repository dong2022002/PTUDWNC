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
using System.Threading;
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
				products = products.Where(x => x.Slug == query.TitleSlug);
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
				.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
		}

		

		public async Task<IList<T>> getProductRandom<T>(int number, Func<IQueryable<Product>, IQueryable<T>> mapper, CancellationToken cancellationToken = default)
		{
			var products=  _context.Set<Product>()
					.Include(x => x.ProductCategory)
					.Include(x => x.Discount)
					.OrderBy(x => Guid.NewGuid())
					.Take(number);
			return await mapper(products).ToListAsync(cancellationToken);
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

		public async Task<IPagedList<T>> GetPagedProductAsync<T>(IPagingParams pagingParams, Func<IQueryable<Product>, IQueryable<T>> mapper, ProductQuery query, CancellationToken cancellationToken = default)
		{
			var productQuery = FilterProducts(query);

			return await mapper(productQuery)
				 .ToPagedListAsync(pagingParams, cancellationToken);
		}

		public async Task<IList<T>> GetProductFeatured<T>(int number, Func<IQueryable<Product>, IQueryable<T>> mapper, CancellationToken cancellationToken = default)
		{
			var products = _context.Set<Product>()
				.Include(x => x.ProductCategory)
				.Include(x => x.Discount)
				.OrderByDescending(x => x.viewCount)
				.Take(number);
			return await mapper(products).ToListAsync(cancellationToken);
		}

		public async Task<bool> AddOrUpdateProductsAsync(Product newProduct, CancellationToken cancellationToken = default)
		{
			if (newProduct.Id <= 0)
			{
				_context.Products.Add(newProduct);

			}
			else
			{
				_context.Set<Product>().Update(newProduct);

			}
			return (await _context.SaveChangesAsync(cancellationToken)) > 0;
		}

		public async Task<bool> DeleteProductAsync(int idProduct, CancellationToken cancellationToken = default)
		{
			var product = _context.Set<Product>()
			  .Where(t => t.Id == idProduct);
			if (product.IsNullOrEmpty()) return false;
			await product.ExecuteDeleteAsync(cancellationToken);
			return true;
		}

		public async Task<IList<T>> GetNewProduct<T>(int number, Func<IQueryable<Product>, IQueryable<T>> mapper, CancellationToken cancellationToken = default)
		{
			var products = _context.Set<Product>()
				.Include(x => x.ProductCategory)
				.Include(x => x.Discount)
				.OrderByDescending(x => x.CreatedAt)
				.Take(number);
			return await mapper(products).ToListAsync(cancellationToken);
		}

		public async Task<IList<T>> GetDiscountProduct<T>(int number, Func<IQueryable<Product>, IQueryable<T>> mapper, CancellationToken cancellationToken = default)
		{
			var products = _context.Set<Product>()
				.Include(x => x.ProductCategory)
				.Include(x => x.Discount)
				.OrderByDescending(x => x.Discount.DiscountPercent)
				.Take(number);
			return await mapper(products).ToListAsync(cancellationToken);
		}

		public async Task<bool> IsProductSlugExistedAsync(int idProduct, string slug, CancellationToken cancellationToken = default)
		{
			return await _context.Set<Product>()
				.AnyAsync(x => x.Id != idProduct && x.Slug == slug,
				cancellationToken);
		}
	}
}
