using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities
{
	public class ProductCategory
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Created_at { get; set; }
		public DateTime Modified_at { get; set; }
		public DateTime Deleted_at { get; set; }

        public IList<Product> Products { get; set; }
    }
}
