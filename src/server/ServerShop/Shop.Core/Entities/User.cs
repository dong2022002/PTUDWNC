using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities
{
	public class User
	{
        public int Id { get; set; }
		public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set;}

		public IList<UserPayment> UserPayments { get; set; }

        public OrderDetail OrderDetail { get; set; }
        public ShoppingSession ShoppingSession { get; set; }

    }
}
