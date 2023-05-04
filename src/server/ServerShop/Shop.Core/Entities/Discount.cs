using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities
{
	public class Discount
	{
        public int Id { get; set; }
		public string Name { get; set; }	
		public string Description { get; set; }
        public double DiscountPercent { get; set; }
        public bool Active { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? ModifiedAt { get; set; }
		public DateTime? DeletedAt { get; set; }

        public IList<Product> Products { get; set; }
    }
}
