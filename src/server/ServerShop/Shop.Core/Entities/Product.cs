using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities
{
	public class Product
	{
        public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
		public DateTime DeletedAt { get; set; }

        public int CategoryId { get; set; }
        public int InventoryId { get; set; }
        public int DiscountId { get; set; }

        public CartItem CartItem { get; set; }
        public ProductInventory ProductInventory { get; set; }
        public Discount Discount { get; set; }

        public OrderItem OrderItem { get; set; }
    }
}
