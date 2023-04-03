using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Data.Contexts;

namespace Shop.Data.Seeders
{
	internal class DataSeeder : IDataSeeder
	{
		private readonly ShopDbContext _context;
        public DataSeeder(ShopDbContext context)
        {
			_context = context;
        }
        public void initialize()
		{
			_context.Database.EnsureCreated();
			if (_context.Products.Any()) return;
			var categories = createCategories();
			var productInventories = createProductInventories();
			var discounts = createDiscounts();

		}

		private object createDiscounts()
		{
			throw new NotImplementedException();
		}

		private object createProductInventories()
		{
			throw new NotImplementedException();
		}

		private object createCategories()
		{
			throw new NotImplementedException();
		}
	}
}
