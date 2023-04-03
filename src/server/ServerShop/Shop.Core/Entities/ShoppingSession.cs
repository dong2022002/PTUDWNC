using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities
{
	public class ShoppingSession
	{
        public int Id { get; set; }
        public double total { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }

		public int UserId { get; set; }
        public User User { get; set; }

        public IList<CartItem> Carts { get; set; }

        public IList<ShoppingSession> ShoppingSessions { get; set; }
    }
}
