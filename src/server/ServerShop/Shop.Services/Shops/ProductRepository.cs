using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;
using Shop.Data.Contexts;
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
	}
}
