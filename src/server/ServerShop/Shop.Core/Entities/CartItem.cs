using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities
{
	public class CartItem
	{
        public int Id { get; set; }
        public int Quantity { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }

        public int SessionId { get; set; }
        public int ProductId { get; set; }

        public ShoppingSession ShoppingSession { get; set; }
        public Product Product { get; set; }
    }
}
